using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private static Random rnd = new Random();
        char[] chrConsonants = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
        char[] chrVowels = { 'A', 'E', 'I', 'O', 'U' };
        char[] chrSpecial = { '!','@','#','$','%','^','&','*','(',')','?'};

        private void button_Generate_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";

            if (checkBox_random.Checked)
            {
                if (checkBox_complex.Checked)
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        randomChar();
                    }
                }
                else
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        randomChar();
                    }
                }
            }
            else
            {
                if (checkBox_complex.Checked)
                {
                    textBox1.Text += chrConsonants[rnd.Next(0, 18)];
                    textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString().ToLower();
                    textBox1.Text += chrConsonants[rnd.Next(0, 18)].ToString().ToLower();
                    textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString().ToLower(); textBox1.Text += chrConsonants[rnd.Next(0, 18)].ToString().ToLower();
                    textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString().ToLower();
                    textBox1.Text += chrConsonants[rnd.Next(0, 18)].ToString().ToLower();
                    textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString().ToLower();
                    textBox1.Text += rnd.Next(0, 9);
                    textBox1.Text += rnd.Next(0, 9);
                    textBox1.Text += rnd.Next(0, 9);
                    textBox1.Text += rnd.Next(0, 9);
                    textBox1.Text += rnd.Next(0, 9);
                    textBox1.Text += rnd.Next(0, 9);
                }
                else
                {
                    textBox1.Text += chrConsonants[rnd.Next(0, 18)];
                    textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString().ToLower();
                    textBox1.Text += chrConsonants[rnd.Next(0, 18)].ToString().ToLower();
                    textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString().ToLower();
                    textBox1.Text += rnd.Next(0, 9);
                    textBox1.Text += rnd.Next(0, 9);
                    textBox1.Text += rnd.Next(0, 9);
                    textBox1.Text += rnd.Next(0, 9);
                }
            }
            if (checkBox_specialChar.Checked) {
                textBox1.Text += chrSpecial[rnd.Next(0, 11)];
            }
        }

        private void randomChar()
        {
            int x = rnd.Next(1, 6);
            switch (x)
            {
                case 1:
                    upperCaseVowel(); break;
                case 2:
                    lowerCaseVowel(); break;
                case 3:
                    upperCaseCons(); break;
                case 4:
                    lowerCaseCons(); break;
                case 5:
                    number(); break;
            }
        }

        private void upperCaseVowel()
        {
            textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString();
        }

        private void lowerCaseVowel()
        {
            textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString().ToLower();
        }

        private void upperCaseCons()
        {
            textBox1.Text += chrConsonants[rnd.Next(0, 20)].ToString();
        }

        private void lowerCaseCons()
        {
            textBox1.Text += chrConsonants[rnd.Next(0, 20)].ToString().ToLower();
        }

        private void number()
        {
            textBox1.Text += rnd.Next(0, 9);
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.Text, false, 5, 200);
        }
    }
}
