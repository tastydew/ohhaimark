using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OhHaiMark
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool multiInstance = false;
            Mutex m = new Mutex(true, "OhHaiMark", out multiInstance);
            if (!multiInstance)
            {
                MessageBox.Show("You are tearing me apart Lisa!");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmhaimark());
            GC.KeepAlive(m);
        }
    }
}
