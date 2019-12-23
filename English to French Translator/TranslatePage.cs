using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Data.SqlClient;

namespace English_to_French_Translator
{

    public partial class TranslatePage : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Spythonian\Documents\tldb.mdf;Integrated Security=True;Connect Timeout=30");

        SpeechSynthesizer speech;
        public TranslatePage()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
        }

        // Implementing the Speech Reference

        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        
        private void Button4_Click(object sender, EventArgs e)
        {
            ChoiceFeed tp = new ChoiceFeed();
            tp.Show();
            tp.Focus();
            this.Close();
            
        }

        private void TranslatePage_Load(object sender, EventArgs e)
        {
            foreach (var voice in speech.GetInstalledVoices())
            {
                languageSelection.Items.Add(voice.VoiceInfo.Name);
               // MessageBox.Show(speech.);
            }
        }
        

        private void Button3_Click(object sender, EventArgs e)
        {
            //Speak
            /*           
            pBuilder.ClearContent();
            pBuilder.AppendText(textBox2.Text);
            sSynth.Speak(pBuilder);
            */

            if (textBox2.Text != "")
            {
                speech.SelectVoice(languageSelection.Text);
                speech.SpeakAsync(textBox2.Text);
            }
           
        }

        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //MessageBox.Show("Speech Recognized" + e.Result.Text.ToString());
            if (e.Result.Text == "exit")
            {
                Application.Exit();
            }
            else
            {
                textBox1.Text = textBox1.Text + " " + e.Result.Text.ToString();
            }
        }

        /*
        private void Button5_Click(object sender, EventArgs e)
        {
            sRecognize.RecognizeAsyncStop();
            //button1.Enabled = true;
            //button5.Enabled = false;
            // Clearing Input
            textBox1.Text = "";
            textBox2.Text = "";

        } 
        
        */

        private void Button2_Click(object sender, EventArgs e)
        {
            //Connect to databse
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Spythonian\Documents\tldb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            if (textBox1.Text != "")
            {
                //Search database for english words
                SqlCommand cmd = new SqlCommand("SELECT french FROM [dbo].[Table] WHERE english='" + textBox1.Text + "'", con);
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    //Output the french
                    textBox2.Text = da.GetValue(0).ToString();

                }
                con.Close();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void LanguageSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        // [dbo].[Table]
    }
}


/*
  //RECORD BUTTON
           
            Choices sList = new Choices();
            sList.Add(new string[] { "hello", "how far", "Can you come tonight?" });
            Grammar gr = new Grammar(new GrammarBuilder(sList));
            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch
            {
                return;
            }
    // STOP BUTTON

        sRecognize.RecognizeAsyncStop();
            //button1.Enabled = true;
            //button5.Enabled = false;
            // Clearing Input
            textBox1.Text = "";
            textBox2.Text = "";
 */
