using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace IPAddressManager
{
    internal static class Program
    {
    

// Inside Main method
static void Main()
    {
        bool createdNew;
        using (Mutex mutex = new Mutex(true, "UniqueAppName", out createdNew)) // Replace UniqueAppName with a unique name for your application
        {
            if (!createdNew)
            {
                // Another instance is already running
                MessageBox.Show("An instance of the application is already running.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}
}
