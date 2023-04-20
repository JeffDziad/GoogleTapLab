using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace GoogleTapLab
{
    public partial class MainPage : ContentPage
    {

        private string bufferOne = "";
        private string bufferTwo = "";

        private string[] buffers = new string[2];

        public MainPage()
        {
            InitializeComponent();
            
        }

        public void dotOneClick(object sender, EventArgs e)
        {
            bufferOne += ".";
            updateBufferLabel(MorseBufferOne, bufferOne);
        }

        public void dotTwoClick(object sender, EventArgs e)
        {
            bufferTwo += ".";
            updateBufferLabel(MorseBufferTwo, bufferTwo);
        }

        public void dashOneClick(object sender, EventArgs e)
        {
            bufferOne += "-";
            updateBufferLabel(MorseBufferOne, bufferOne);
        }

        public void dashTwoClick(object sender, EventArgs e)
        {
            bufferTwo += "-";
            updateBufferLabel(MorseBufferTwo, bufferTwo);
        }

        public void spaceOneClick(object sender, EventArgs e)
        {
            if(bufferOne.Length <= 0)
            {
                // New word.
                resultOne.Text += " ";
                ErrorBox.Text = "";
            } else
            {
                // New letter.
                char letter = Morse.decodeMorse(bufferOne);
                if(letter == '?')
                {
                    bufferOne = "";
                    ErrorBox.Text = "Unabled to decode, please try again.";
                } else
                {
                    resultOne.Text += letter;
                    bufferOne = "";
                    ErrorBox.Text = "";
                }
            }
            updateBufferLabel(MorseBufferOne, bufferOne);
        }

        public void spaceTwoClick(object sender, EventArgs e)
        {
            if (bufferTwo.Length <= 0)
            {
                // New word.
                resultTwo.Text += " ";
                ErrorBox.Text = "";
            } else
            {
                // New letter.
                char letter = Morse.decodeMorse(bufferTwo);
                if (letter == '?')
                {
                    bufferTwo = "";
                    ErrorBox.Text = "Unabled to decode, please try again.";
                } else
                {
                    resultTwo.Text += letter;
                    bufferTwo = "";
                    ErrorBox.Text = "";
                }
            }
            updateBufferLabel(MorseBufferTwo, bufferTwo);
        }

        private void updateBufferLabel(Label label, string buffer)
        {
            label.Text = buffer;
        }

        public void DeleteOneBtnClicked(object sender, EventArgs args)
        {
            if(resultOne.Text != null && resultOne.Text.Length > 0) resultOne.Text = resultOne.Text.Remove(resultOne.Text.Length - 1, 1);

        }

        public void DeleteTwoBtnClicked(object sender, EventArgs args)
        {
            if(resultTwo.Text != null && resultTwo.Text.Length > 0 & resultTwo.Text.Length > 0) resultTwo.Text = resultTwo.Text.Remove(resultTwo.Text.Length - 1, 1);
        }

    }
}
