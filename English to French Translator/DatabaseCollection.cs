﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace English_to_French_Translator
{
    public partial class DatabaseCollection : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Spythonian\Documents\tldb.mdf;Integrated Security=True;Connect Timeout=30");
        public DatabaseCollection()
        {
            InitializeComponent();
        }
        //HOME BUTTON
        private void Button5_Click(object sender, EventArgs e)
        {
            ChoiceFeed tp = new ChoiceFeed();
            tp.Show();
            this.Hide();
            tp.Focus();
        }

        private void DatabaseCollection_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        // ADD/SAVE LANGUAGE
        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length == 0 || this.textBox1.Text.Length == 0)
            {
                MessageBox.Show("All fileds are compulsory!");
            } else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [dbo].[Table] VALUES('" + textBox1.Text + "', '" + textBox2.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                disp_data();

                MessageBox.Show("record inserted successfully!");
            }
            
        }

        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Table]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        //DELETE BUTTON

        private void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM [dbo].[Table] WHERE english='" + textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();

            MessageBox.Show("record deleted successfully!");
        }

        // EDIT BUTTON
        private void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE [dbo].[Table] SET english='" + textBox2.Text+ "' WHERE english='" + textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();

            MessageBox.Show("record updated successfully!");
        }

        // SEARCH BUTTON
        private void Button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Table] WHERE english='" + textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }
    }
}
