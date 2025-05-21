// IOUtils.cs

using L4_14._Hotels.Interfaces;
using System.Diagnostics;

namespace L4_14._Hotels
{
    /// <summary>
    /// Provides utility methods for reading from and writing to files as well as displaying data
    /// in a formatted table for the Hotels application.
    /// </summary>
    internal static class IOUtils
    {
        /// <summary>
        /// Processes a file at the specified path and deserializes each line into an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of objects to deserialize, which must implement the <see cref="IDeserializable{T}"/> interface.
        /// </typeparam>
        /// <param name="path">The path of the file to process.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the deserialized objects.
        /// </returns>
        public static IEnumerable<T> ProcessFile<T>(string path)
            where T : IDeserializable<T>
        {
            Trace.TraceInformation($"Parsing file located at {path}");

            using var file = new StreamReader(path);

            var line = file.ReadLine();
            var list = new DoublyLinkedList<T>();

            var i = 0;
            while (line != null)
            {
                i++;

                var des = new LineDeserializer(line);

                try
                {
                    var elem = T.Deserialize(des);
                    list.PushBack(elem);
                }
                catch (Exception ex)
                {
                    var rem = des.Remaining();
                    Trace.TraceWarning($"    Failed to parse line {i} at {des.CursorPosition} - `{rem.AsSpan(0, Math.Min(rem.Length, 20))}`. Error: {ex.Message}");
                }

                line = file.ReadLine();
            }
            return list;
        }

        /// <summary>
        /// Saves a collection of strings to a file, writing each string on a new line.
        /// </summary>
        /// <typeparam name="I">
        /// A type that implements <see cref="IEnumerable{String}"/>.
        /// </typeparam>
        /// <param name="path">The path of the file where the data will be saved.</param>
        /// <param name="lines">The collection of strings to write to the file.</param>
        public static void SaveLines<I>(string path, I lines) where I : IEnumerable<string>
        {
            Trace.TraceInformation($"Saving results to the file located at {path}");

            using var file = new StreamWriter(path);

            foreach (var line in lines)
            {
                file.WriteLine(line);
            }
        }

        /// <summary>
        /// Displays hotel data in a formatted table with columns for hotel name, room type, and price.
        /// </summary>
        /// <typeparam name="I">
        /// A type that implements <see cref="IEnumerable{Hotel}"/>.
        /// </typeparam>
        /// <param name="hotels">The collection of hotels to display.</param>
        /// <param name="title">The title of the displayed table.</param>
        /// <param name="output">An action delegate which specifies how each row of the table is output.</param>
        public static void DisplayHotels<I>(I hotels, string title, Action<string> output) where I : IEnumerable<Hotel>
        {
            var table = new FixedTableBuilder(new DoublyLinkedList<(string, uint)>() { ("Name", 15), ("Room", 10), ("Price", 8) });
            table.WithTitle(title);
            table.InsertAnySeq(hotels);

            foreach (var row in table)
            {
                output(row);
            }
        }

        /// <summary>
        /// Displays only the hotel names in a formatted table.
        /// </summary>
        /// <typeparam name="I">
        /// A type that implements <see cref="IEnumerable{Hotel}"/>.
        /// </typeparam>
        /// <param name="hotels">The collection of hotels whose names are to be displayed.</param>
        /// <param name="title">The title of the displayed table.</param>
        /// <param name="output">An action delegate which specifies how each row of the table is output.</param>
        public static void DisplayHotelName<I>(I hotels, string title, Action<string> output) where I : IEnumerable<Hotel>
        {
            var table = new FixedTableBuilder(new DoublyLinkedList<(string, uint)>() { ("Name", 15) });
            table.WithTitle(title);
            table.InsertAnySeq(hotels.Select(h => h.Name));

            foreach (var row in table)
            {
                output(row);
            }
        }

        /// <summary>
        /// Displays traveler data in a formatted table with columns for surname, name, hotel, room, and nights.
        /// </summary>
        /// <typeparam name="I">
        /// A type that implements <see cref="IEnumerable{Traveler}"/>.
        /// </typeparam>
        /// <param name="travelers">The collection of travelers to display.</param>
        /// <param name="title">The title of the displayed table.</param>
        /// <param name="output">An action delegate which specifies how each row of the table is output.</param>
        public static void DisplayTravelers<I>(I travelers, string title, Action<string> output) where I : IEnumerable<Traveler>
        {
            var table = new FixedTableBuilder(new DoublyLinkedList<(string, uint)>() { ("Surname", 10), ("Name", 10), ("Hotel", 15), ("Room", 10), ("Nights", 8) });
            table.WithTitle(title);
            table.InsertAnySeq(travelers);

            foreach (var row in table)
            {
                output(row);
            }
        }

        /// <summary>
        /// Displays only the full names (surname and name) of travelers in a formatted table.
        /// </summary>
        /// <typeparam name="I">
        /// A type that implements <see cref="IEnumerable{Traveler}"/>.
        /// </typeparam>
        /// <param name="travelers">The collection of travelers whose full names are to be displayed.</param>
        /// <param name="title">The title of the displayed table.</param>
        /// <param name="output">An action delegate which specifies how each row of the table is output.</param>
        public static void DisplayTravelersFullName<I>(I travelers, string title, Action<string> output) where I : IEnumerable<Traveler>
        {
            var table = new FixedTableBuilder(new DoublyLinkedList<(string, uint)>() { ("Surname", 10), ("Name", 10) });
            table.WithTitle(title);
            table.InsertAnySeq(travelers.Select(t => (t.Surname, t.Name)));

            foreach (var row in table)
            {
                output(row);
            }
        }

        /// <summary>
        /// Displays traveler data along with the amount paid in a formatted table.
        /// </summary>
        /// <typeparam name="I">
        /// A type that implements <see cref="IEnumerable{(Traveler, decimal)}"/>.
        /// </typeparam>
        /// <param name="travelers">The collection of tuples, each containing a traveler and the associated expense.</param>
        /// <param name="title">The title of the displayed table.</param>
        /// <param name="output">An action delegate which specifies how each row of the table is output.</param>
        public static void DisplayTravelersFullNameAndMoney<I>(I travelers, string title, Action<string> output) where I : IEnumerable<(Traveler, decimal)>
        {
            var table = new FixedTableBuilder(new DoublyLinkedList<(string, uint)>() { ("Surname", 10), ("Name", 10), ("Paid", 8) });
            table.WithTitle(title);
            table.InsertAnySeq(travelers.Select(t => (t.Item1.Surname, t.Item1.Name, t.Item2)));

            foreach (var row in table)
            {
                output(row);
            }
        }
    }
}
