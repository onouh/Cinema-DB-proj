using System;
using System.Windows.Forms;

namespace CinemaDB_GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set up standard Windows Forms visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // If you are using .NET 6 or later, Visual Studio might auto-generate the line below instead:
            // ApplicationConfiguration.Initialize();

            // Launch the main dashboard (Form1)
            Application.Run(new Form1());
        }
    }
}