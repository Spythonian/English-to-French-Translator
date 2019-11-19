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

namespace English_to_French_Translator
{
    public partial class TranslatePage : Form
    {
        public TranslatePage()
        {
            InitializeComponent();
        }

        // Implementing the Speech Reference
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        private void Button4_Click(object sender, EventArgs e)
        {
            ChoiceFeed tp = new ChoiceFeed();
            tp.Show();
            this.Hide();
            tp.Focus();
        }

        private void TranslatePage_Load(object sender, EventArgs e)
        {

        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            //Record
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
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Speak
           
            pBuilder.ClearContent();
            pBuilder.AppendText(textBox1.Text);
            sSynth.Speak(pBuilder);
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
    }
}
