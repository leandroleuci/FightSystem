using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;


namespace Fight.Tablero
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Formularios.Tablero());
            SingleInstance.SingleApplication.Run(new Formularios.Tablero());
        }

    }
}
