using L4_14._Hotels.Interfaces;
using System.Collections.Specialized;
using System.Diagnostics;

namespace L4_14._Hotels
{
    internal static class IOUtils
    {
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

        public static void SaveLines<I>(string path, I lines) where I : IEnumerable<string>
        {
            Trace.TraceInformation($"Saving results at to the file located at {path}");
            
            using var file = new StreamWriter(path);
            
            foreach (var line in lines)
            {
                file.WriteLine(line);
            }
        }

        public static void DisplayHotels<I>(I hotels, string title, Action<string> output) where I : IEnumerable<Hotel>
        {
            var table = new FixedTableBuilder(new DoublyLinkedList<(string, uint)>() { ("Name", 15 ), ("Room", 10), ( "Price", 8 ) });
            table.WithTitle(title);
            table.InsertAnySeq(hotels);

            foreach (var row in table)
            {
                output(row);
            }
        }

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
