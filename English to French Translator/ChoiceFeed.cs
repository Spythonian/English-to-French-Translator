using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace English_to_French_Translator
{
    public partial class ChoiceFeed : Form
    {
        public ChoiceFeed()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DatabaseCollection db = new DatabaseCollection();
            db.Show();
            this.Hide();
            db.Focus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TranslatePage tp = new TranslatePage();
            tp.Show();
            this.Hide();
            tp.Focus();
        }
    }
}
