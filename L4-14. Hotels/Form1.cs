using System.Diagnostics;

namespace L4_14._Hotels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void OpenTravelers(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                travelers = IOUtils.ProcessFile<Traveler>(openFileDialog1.FileName).ToDoublyLinkedList();
                DisplayTravelers();
            }
        }

        private void OpenHotels(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                hotels = IOUtils.ProcessFile<Hotel>(openFileDialog1.FileName).ToDoublyLinkedList();
                DisplayHotels();
            }
        }

        private void Save(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IOUtils.SaveLines(saveFileDialog1.FileName, listBox1.Items.Cast<string>());
            }
        }

        private void LoadedTravelersData(object sender, EventArgs e)
        {
            DisplayTravelers();
        }

        private void LoadedHotelsData(object sender, EventArgs e)
        {
            DisplayHotels();
        }

        private void Logs(object sender, EventArgs e)
        {
            logs.ShowDialog();
        }

        private void HotelsChosenByTravelers(object sender, EventArgs e)
        {
            var list = GetHotelsChosenByTravelers();

            Trace.TraceInformation("Diplaying hotels chosen by travelers.");

            listBox1.Items.Clear();
            IOUtils.DisplayHotelName(
                list,
                "A separate list of hotels chosen by travellers.",
                line => listBox1.Items.Add(line)
            );
        }

        private void HotelsNotChosenByTravelers(object sender, EventArgs e)
        {
            var list = GetHotelsNotChosenByTravelers();

            Trace.TraceInformation("Diplaying hotels not chosen by travelers.");

            listBox1.Items.Clear();
            IOUtils.DisplayHotelName(
                list,
                "A separate list of hotels not chosen by travellers.",
                line => listBox1.Items.Add(line)
            );
        }

        private void TravellersWhoPlanToSpendTheMostNightsInHotels(object sender, EventArgs e)
        {
            var list = GetTravelersSpendingMostNightsInHotels();

            listBox1.Items.Clear();
            IOUtils.DisplayTravelersFullName(
                list,
                "A list of travellers who plan to spend the most nights in hotels.",
                line => listBox1.Items.Add(line)
            );
        }

        private void TravelersWhoSpentNoMoreThanM(object sender, EventArgs e)
        {
            decimal M = 0;
            try
            {
                M = Convert.ToDecimal(textBox1.Text.Trim());
                if (M < 0)
                    throw new InvalidDataException();
            }
            catch
            {
                Trace.TraceInformation("Invalid traveler expenditure limit, enter non-negative number.");
                MessageBox.Show("Enter non-negative number.");
                return;
            }

            var list = GetTravelersWithExpensesNoMoreThan(M);

            Trace.TraceInformation($"Displaying travelers who spent not more than {M}");

            listBox1.Items.Clear();
            IOUtils.DisplayTravelersFullNameAndMoney(
                list,
                $"A list of travellers who paid a sum of money for hotels that does not exceed the amount indicated {M}.",
                line => listBox1.Items.Add(line)
            );
        }

        private void DisplayTravelers()
        {
            listBox1.Items.Clear();
            IOUtils.DisplayTravelers(travelers, "Extracted information about travellers.", line => listBox1.Items.Add(line));
        }

        private void DisplayHotels()
        {
            listBox1.Items.Clear();
            IOUtils.DisplayHotels(hotels, "Extracted information about hotels.", line => listBox1.Items.Add(line));
        }
    }
}
