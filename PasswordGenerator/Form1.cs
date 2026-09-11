using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private readonly char[] chrConsonants = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly char[] chrVowels = { 'A', 'E', 'I', 'O', 'U' };
        private readonly char[] chrSpecial = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '?' };
        private readonly List<string> words = new List<string>();
        private bool wordsLoaded = false;

        // Uses a CSPRNG (RNGCryptoServiceProvider) rather than System.Random —
        // System.Random is seeded from the clock and its output sequence is
        // predictable, which is a real weakness for a tool whose whole job is
        // generating unguessable passwords.
        private static class SecureRandom
        {
            private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // [minInclusive, maxExclusive), matching System.Random.Next(min, max).
            // Uses rejection sampling to avoid modulo bias.
            public static int Next(int minInclusive, int maxExclusive)
            {
                if (maxExclusive <= minInclusive)
                    throw new ArgumentOutOfRangeException(nameof(maxExclusive));

                uint range = (uint)(maxExclusive - minInclusive);
                uint limit = uint.MaxValue - (uint.MaxValue % range);
                byte[] buffer = new byte[4];
                uint value;
                do
                {
                    rng.GetBytes(buffer);
                    value = BitConverter.ToUInt32(buffer, 0);
                } while (value >= limit);

                return minInclusive + (int)(value % range);
            }
        }

        private void button_Generate_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";

            // These four branches are mutually exclusive modes, not
            // independent toggles — each one fully decides the base
            // password on its own, so this must be an if/else-if chain.
            // ("More random" previously ran as a separate standalone `if`
            // alongside this chain, so checking it silently glued its own
            // 8-12 random characters onto whatever the complex/dictionary/
            // default branch also produced.)
            if (checkBox_random.Checked)
            {
                int length = checkBox_complex.Checked ? 12 : 8;
                for (int i = 0; i < length; i++)
                {
                    RandomChar();
                }
            }
            else if (checkBox_complex.Checked)
            {
                textBox1.Text += chrConsonants[SecureRandom.Next(0, chrConsonants.Length)];
                textBox1.Text += chrVowels[SecureRandom.Next(0, chrVowels.Length)].ToString().ToLower();
                textBox1.Text += chrConsonants[SecureRandom.Next(0, chrConsonants.Length)].ToString().ToLower();
                textBox1.Text += chrVowels[SecureRandom.Next(0, chrVowels.Length)].ToString().ToLower();
                textBox1.Text += chrConsonants[SecureRandom.Next(0, chrConsonants.Length)].ToString().ToLower();
                textBox1.Text += chrVowels[SecureRandom.Next(0, chrVowels.Length)].ToString().ToLower();
                textBox1.Text += chrConsonants[SecureRandom.Next(0, chrConsonants.Length)].ToString().ToLower();
                textBox1.Text += chrVowels[SecureRandom.Next(0, chrVowels.Length)].ToString().ToLower();
                for (int i = 0; i < 6; i++)
                {
                    textBox1.Text += SecureRandom.Next(0, 10);
                }
            }
            else if (checkBox_dictionary.Checked)
            {
                EnsureWordsLoaded();

                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                textBox1.Text += textInfo.ToTitleCase(words[SecureRandom.Next(0, words.Count)]);
                textBox1.Text += textInfo.ToTitleCase(words[SecureRandom.Next(0, words.Count)]);
                textBox1.Text += SecureRandom.Next(0, 10);
                textBox1.Text += SecureRandom.Next(0, 10);
            }
            else
            {
                textBox1.Text += chrConsonants[SecureRandom.Next(0, chrConsonants.Length)];
                textBox1.Text += chrVowels[SecureRandom.Next(0, chrVowels.Length)].ToString().ToLower();
                textBox1.Text += chrConsonants[SecureRandom.Next(0, chrConsonants.Length)].ToString().ToLower();
                textBox1.Text += chrVowels[SecureRandom.Next(0, chrVowels.Length)].ToString().ToLower();
                for (int i = 0; i < 4; i++)
                {
                    textBox1.Text += SecureRandom.Next(0, 10);
                }
            }


            if (checkBox_specialChar.Checked) {
                textBox1.Text += chrSpecial[SecureRandom.Next(0, chrSpecial.Length)];
            }

        }

        // Loads and filters the word list once and caches it — previously
        // this ran on every single Generate click without ever clearing
        // `words` first, so the list (and the redundant file read) grew
        // unbounded for the life of the app session.
        private void EnsureWordsLoaded()
        {
            if (wordsLoaded)
                return;

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
            }

            wordsLoaded = true;
        }

        private void RandomChar()
        {
            int x = SecureRandom.Next(1, 6);
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
            textBox1.Text += chrVowels[SecureRandom.Next(0, chrVowels.Length)].ToString();
        }

        private void LowerCaseVowel()
        {
            textBox1.Text += chrVowels[SecureRandom.Next(0, chrVowels.Length)].ToString().ToLower();
        }

        private void UpperCaseCons()
        {
            textBox1.Text += chrConsonants[SecureRandom.Next(0, chrConsonants.Length)].ToString();
        }

        private void LowerCaseCons()
        {
            textBox1.Text += chrConsonants[SecureRandom.Next(0, chrConsonants.Length)].ToString().ToLower();
        }

        private void Number()
        {
            textBox1.Text += SecureRandom.Next(0, 10);
        }

        // One substitution per call (a, e, i, s, or o -> a leet-speak
        // stand-in), picked in random order and applied the first one
        // whose character is actually present in the text — repeated
        // clicks progressively mangle more of the password. Previously
        // this picked a *random* category up to 25 times without ever
        // excluding one already tried, wrapped in an outer "retry" loop
        // that unconditionally exited after one pass regardless of
        // success — so it never actually retried, and on unlucky rolls
        // (or text containing none of a/e/i/s/o) it could silently return
        // the text unmangled. Checking each of the 5 categories at most
        // once removes both problems.
        private struct MangleRule
        {
            public readonly char From;
            public readonly char To;

            public MangleRule(char from, char to)
            {
                From = from;
                To = to;
            }
        }

        private static readonly MangleRule[] MangleRules =
        {
            new MangleRule('a', '@'),
            new MangleRule('e', '3'),
            new MangleRule('i', '1'),
            new MangleRule('s', '$'),
            new MangleRule('o', '0'),
        };

        private string Mangle(string text)
        {
            var rules = new List<MangleRule>(MangleRules);

            while (rules.Count > 0)
            {
                int index = SecureRandom.Next(0, rules.Count);
                MangleRule rule = rules[index];
                rules.RemoveAt(index);

                if (text.IndexOf(rule.From) >= 0)
                {
                    return text.Replace(rule.From.ToString(), rule.To.ToString());
                }
            }

            return text;
        }

        private void Button_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.Text, false, 5, 200);
        }

        private void button_Mangle_MouseClick(object sender, EventArgs e)
        {
            textBox1.Text = Mangle(textBox1.Text);
        }
    }
}
