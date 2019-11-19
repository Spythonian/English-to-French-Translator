using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace English_to_French_Translator
{
    public partial class DatabaseCollection : Form
    {
        public DatabaseCollection()
        {
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ChoiceFeed tp = new ChoiceFeed();
            tp.Show();
            this.Hide();
            tp.Focus();
        }
    }
}
