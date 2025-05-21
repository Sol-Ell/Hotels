// Form1Logic.cs

using L3_14.Public_transport;
using System.Diagnostics;

namespace L4_14._Hotels
{
    public partial class Form1
    {
        /// <summary>
        /// Stores the list of travelers loaded from a file.
        /// </summary>
        private DoublyLinkedList<Traveler> travelers = [];

        /// <summary>
        /// Stores the list of hotels loaded from a file.
        /// </summary>
        private DoublyLinkedList<Hotel> hotels = [];

        /// <summary>
        /// Manages logging of trace messages.
        /// </summary>
        private Logs logs = new Logs();

        /// <summary>
        /// Performs initial setup of the form components such as file dialogs and trace listeners.
        /// </summary>
        private void Setup()
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;

            Trace.Listeners.Add(new DelegateTraceListner(message => toolStripStatusLabel1.Text = message));
            Trace.Listeners.Add(new DelegateTraceListner(message => logs.Record(message)));
        }

        /// <summary>
        /// Retrieves the hotels that have been chosen by at least one traveler.
        /// </summary>
        /// <returns>
        /// A doubly linked list containing the hotels chosen by travelers.
        /// </returns>
        private DoublyLinkedList<Hotel> GetHotelsChosenByTravelers()
        {
            var chosenHotelNames = travelers.Select(traveler => traveler.HotelName).ToHashSet();

            return hotels.Where(h => chosenHotelNames.Contains(h.Name)).ToHashSet().ToDoublyLinkedList();
        }

        /// <summary>
        /// Retrieves the hotels that have not been chosen by any traveler.
        /// </summary>
        /// <returns>
        /// A doubly linked list containing the hotels not chosen by travelers.
        /// </returns>
        private DoublyLinkedList<Hotel> GetHotelsNotChosenByTravelers()
        {
            var chosenHotelNames = travelers.Select(traveler => traveler.HotelName).ToHashSet();

            return hotels.ToHashSet().ExceptBy(chosenHotelNames, h => h.Name).ToDoublyLinkedList();
        }

        /// <summary>
        /// Retrieves the travelers who plan to spend the most nights in hotels.
        /// </summary>
        /// <returns>
        /// A doubly linked list containing travelers who plan to spend the maximum number of nights, ordered based on the default ordering.
        /// </returns>
        private DoublyLinkedList<Traveler> GetTravelersSpendingMostNightsInHotels()
        {
            var max = travelers.Select(t => t.Nights).DefaultIfEmpty().Max();

            return travelers.Where(t => t.Nights == max).Order().ToDoublyLinkedList();
        }

        /// <summary>
        /// Retrieves travelers whose hotel expenses do not exceed the specified amount.
        /// </summary>
        /// <param name="M">The maximum allowable expense.</param>
        /// <returns>
        /// A doubly linked list of tuples, each containing a traveler and their calculated expense, where the expense is not more than <paramref name="M"/>.
        /// </returns>
        private DoublyLinkedList<(Traveler, decimal)> GetTravelersWithExpensesNoMoreThan(decimal M)
        {
            var hotels = new Dictionary<string, Hotel>();

            // Build a dictionary of hotels using the hotel name as key.
            foreach (var hotel in this.hotels)
            {
                if (!hotels.ContainsKey(hotel.Name))
                    hotels.Add(hotel.Name, hotel);
            }

            var res = new DoublyLinkedList<(Traveler, decimal)>();

            // Calculate expense for each traveler and add to result if expense does not exceed M.
            foreach (var t in travelers)
            {
                if (hotels.ContainsKey(t.HotelName))
                {
                    var expense = hotels[t.HotelName].PricePerNight * t.Nights;
                    if (expense > M)
                        continue;
                    res.Add((t, expense));
                }
            }

            return res;
        }
    }
}
