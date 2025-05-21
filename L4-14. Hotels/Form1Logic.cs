using L3_14.Public_transport;
using System.Diagnostics;

namespace L4_14._Hotels
{
    public partial class Form1
    {
        private DoublyLinkedList<Traveler> travelers = [];
        private DoublyLinkedList<Hotel> hotels = [];
        private Logs logs = new Logs();

        private void Setup()
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;

            Trace.Listeners.Add(new DelegateTraceListner(message => toolStripStatusLabel1.Text = message));
            Trace.Listeners.Add(new DelegateTraceListner(message => logs.Record(message)));
        }

        private DoublyLinkedList<Hotel> GetHotelsChosenByTravelers()
        {
            var chosenHotelNames = travelers.Select(traveler => traveler.HotelName).ToHashSet();

            return hotels.Where(h => chosenHotelNames.Contains(h.Name)).ToHashSet().ToDoublyLinkedList();
        }

        private DoublyLinkedList<Hotel> GetHotelsNotChosenByTravelers()
        {
            var chosenHotelNames = travelers.Select(traveler => traveler.HotelName).ToHashSet();

            return hotels.ToHashSet().ExceptBy(chosenHotelNames, h => h.Name).ToDoublyLinkedList();
        }

        private DoublyLinkedList<Traveler> GetTravelersSpendingMostNightsInHotels()
        {
            var max = travelers.Select(t => t.Nights).DefaultIfEmpty().Max();

            return travelers.Where(t => t.Nights == max).Order().ToDoublyLinkedList();
        }

        private DoublyLinkedList<(Traveler, decimal)> GetTravelersWithExpensesNoMoreThan(decimal M)
        {
            var hotels = new Dictionary<string, Hotel>();

            foreach (var hotel in this.hotels)
            {
                if (!hotels.ContainsKey(hotel.Name))
                    hotels.Add(hotel.Name, hotel);
            }

            var res = new DoublyLinkedList<(Traveler, decimal)>();

            foreach (var t in travelers)
            {
                if (hotels.ContainsKey(t.HotelName)) {
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
