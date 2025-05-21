// Program.cs

namespace L4_14._Hotels
{
    /// <summary>
    /// The main entry point of the Hotels application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Configures application settings and runs the main form.
        /// </summary>
        /// <remarks>
        /// To customize application configuration such as setting high DPI settings or the default font,
        /// see <see href="https://aka.ms/applicationconfiguration"/>.
        /// </remarks>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
