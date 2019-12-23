using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace English_to_French_Translator
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ("admin"))
            {
                if(textBox2.Text == ("password"))
                {
                    DatabaseCollection st = new DatabaseCollection();
                    st.Show();
                    this.Hide();
                    st.Focus();
                }
            } else if (textBox1.Text == "" && textBox1.Text == "")
            {
                MessageBox.Show("One or all the text field is empty");
            } else
            {
                MessageBox.Show("Incorrect username or password. Kindly provide correct login details");
            }
        }
    }
}
