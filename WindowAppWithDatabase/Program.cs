﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowAppWithDatabase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Jitendra Kumar Lines
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RabbitMqReceiveData());
        }
    }
}
