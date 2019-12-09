using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace English_to_French_Translator
{
    public partial class ChoiceFeed : Form
    {
        public ChoiceFeed()
        {
            Thread trd = new Thread(new ThreadStart(formRun));
            trd.Start();
            Thread.Sleep(10000);
            InitializeComponent();
            trd.Abort();
        }

        
        private void formRun()
        {
            //throw new NotImplementedException();
            Application.Run(new TranslatePage());
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //Button to the database
            DatabaseCollection db = new DatabaseCollection();
            db.Show();
            this.Hide();
            db.Focus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Button to translation page
            TranslatePage tp = new TranslatePage();
            tp.Show();
            tp.Focus();
            this.Close();
        }
    }
}
