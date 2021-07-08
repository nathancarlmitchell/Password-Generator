using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private static readonly Random rnd = new Random();
        private readonly char[] chrConsonants = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly char[] chrVowels = { 'A', 'E', 'I', 'O', 'U' };
        private readonly char[] chrSpecial = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '?' };
        private readonly List<string> words = new List<string>();

        private void button_Generate_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";

            if (checkBox_random.Checked)
            {
                if (checkBox_complex.Checked)
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        RandomChar();
                    }
                }
                else
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        RandomChar();
                    }
                }
            }

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

            else if (checkBox_dictionary.Checked)
            {
                string filename = "4000-most-common-english-words-csv.csv";
                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string csvLocation = Path.Combine(executableLocation, filename);

                using (StreamReader reader = new StreamReader(csvLocation))
                {
                    while (!reader.EndOfStream)
                    {
                        var word = reader.ReadLine();
                        if (word.Length <= 6 && word.Length >= 4)
                        {
                            words.Add(word);
                        }
                    }
                };

                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                textBox1.Text += textInfo.ToTitleCase(words[rnd.Next(words.Count)]);
                textBox1.Text += textInfo.ToTitleCase(words[rnd.Next(words.Count)]);
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


            if (checkBox_specialChar.Checked) {
                textBox1.Text += chrSpecial[rnd.Next(0, 11)];
            }
        }

        private void RandomChar()
        {
            int x = rnd.Next(1, 6);
            switch (x)
            {
                case 1:
                    UpperCaseVowel(); break;
                case 2:
                    LowerCaseVowel(); break;
                case 3:
                    UpperCaseCons(); break;
                case 4:
                    LowerCaseCons(); break;
                case 5:
                    Number(); break;
            }
        }

        private void UpperCaseVowel()
        {
            textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString();
        }

        private void LowerCaseVowel()
        {
            textBox1.Text += chrVowels[rnd.Next(0, 5)].ToString().ToLower();
        }

        private void UpperCaseCons()
        {
            textBox1.Text += chrConsonants[rnd.Next(0, 20)].ToString();
        }

        private void LowerCaseCons()
        {
            textBox1.Text += chrConsonants[rnd.Next(0, 20)].ToString().ToLower();
        }

        private void Number()
        {
            textBox1.Text += rnd.Next(0, 9);
        }

        private void Button_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.Text, false, 5, 200);
        }
    }
}
