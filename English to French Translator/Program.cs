﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace English_to_French_Translator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Where the first page is determined
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChoiceFeed());
        }
    }
}
