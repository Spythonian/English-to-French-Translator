using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace English_to_French_Translator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            panelSlide.Width += 2;

            if(panelSlide.Width> 208)
            {
                panelSlide.Width = 0;
            }
            if (panelSlide.Width < 0)
            {
                move = 2;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }
    }
}
