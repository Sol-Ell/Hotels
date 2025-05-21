// Form1.cs

using System.Diagnostics;

namespace L4_14._Hotels
{
    /// <summary>
    /// Represents the main form for the Hotels application.
    /// Handles user interactions including opening files, displaying data, and logging.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Sets up the initial UI and state.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        /// <summary>
        /// Opens a file containing traveler information, processes the file,
        /// converts the data to a doubly linked list, and displays the travelers.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void OpenTravelers(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                travelers = IOUtils.ProcessFile<Traveler>(openFileDialog1.FileName).ToDoublyLinkedList();
                DisplayTravelers();
            }
        }

        /// <summary>
        /// Opens a file containing hotel information, processes the file,
        /// converts the data to a doubly linked list, and displays the hotels.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void OpenHotels(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                hotels = IOUtils.ProcessFile<Hotel>(openFileDialog1.FileName).ToDoublyLinkedList();
                DisplayHotels();
            }
        }

        /// <summary>
        /// Saves the currently displayed data in the list box to a file.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void Save(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IOUtils.SaveLines(saveFileDialog1.FileName, listBox1.Items.Cast<string>());
            }
        }

        /// <summary>
        /// Handler invoked when traveler data has been loaded.
        /// Refreshes the traveler display.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void LoadedTravelersData(object sender, EventArgs e)
        {
            DisplayTravelers();
        }

        /// <summary>
        /// Handler invoked when hotel data has been loaded.
        /// Refreshes the hotel display.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void LoadedHotelsData(object sender, EventArgs e)
        {
            DisplayHotels();
        }

        /// <summary>
        /// Displays the logs in a modal dialog.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void Logs(object sender, EventArgs e)
        {
            logs.ShowDialog();
        }

        /// <summary>
        /// Displays a list of hotels chosen by travelers in the list box.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        /// Displays a list of hotels not chosen by travelers in the list box.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        /// Displays a list of travelers who plan to spend the most nights in hotels in the list box.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        /// Displays a list of travelers whose expenses do not exceed the specified limit.
        /// Validates the limit and shows an error if the input is invalid.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        /// Refreshes and displays the travelers information in the list box.
        /// </summary>
        private void DisplayTravelers()
        {
            listBox1.Items.Clear();
            IOUtils.DisplayTravelers(travelers, "Extracted information about travellers.", line => listBox1.Items.Add(line));
        }

        /// <summary>
        /// Refreshes and displays the hotels information in the list box.
        /// </summary>
        private void DisplayHotels()
        {
            listBox1.Items.Clear();
            IOUtils.DisplayHotels(hotels, "Extracted information about hotels.", line => listBox1.Items.Add(line));
        }

        /// <summary>
        /// Opens the About form to display application details.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">The event data.</param>
        private void About(object sender, EventArgs e)
        {
            new About().Show();
        }
    }
}
