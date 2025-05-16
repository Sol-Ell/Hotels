// LogsView.cs
using System.Windows.Forms;

namespace L3_14.Public_transport
{
    /// <summary>
    /// A form used to display log messages within the application.
    /// </summary>
    public partial class LogsView : Form
    {
        /// <summary>
        /// Initializes a new instance of the LogsView class.
        /// </summary>
        public LogsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Records a log message by adding it to the list box.
        /// </summary>
        /// <param name="message">The log message to display.</param>
        public void Record(string message)
        {
            listBox1.Items.Add(message);
        }

        /// <summary>
        /// Clears all log messages from the view.
        /// </summary>
        public void Clear()
        {
            listBox1.Items.Clear();
        }
    }
}
