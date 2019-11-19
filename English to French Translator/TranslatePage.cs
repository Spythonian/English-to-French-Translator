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
           
        }
    }
}
