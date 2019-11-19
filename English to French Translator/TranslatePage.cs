using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace English_to_French_Translator
{
    public partial class TranslatePage : Form
    {
        public TranslatePage()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ChoiceFeed tp = new ChoiceFeed();
            tp.Show();
            this.Hide();
            tp.Focus();
        }
    }
}
