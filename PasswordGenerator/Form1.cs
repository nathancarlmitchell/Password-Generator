using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Pulls the icon already baked into this .exe (ApplicationIcon
            // in the .csproj) instead of embedding/loading a second copy —
            // keeps the taskbar/title-bar icon guaranteed in sync with the
            // one .ico file. Fully qualified: "Icon" alone would resolve to
            // Form's own instance property of that name, not the type.
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            LoadSettings();
            FormClosing += Form1_FormClosing;
        }

        // Restores whichever mode/options were checked last session. Values
        // come from the user.config LocalFileSettingsProvider writes under
        // %LOCALAPPDATA% (see Form1_FormClosing) — a fresh install (or a
        // BatchCount outside the NumericUpDown's own Minimum/Maximum, e.g.
        // from an older version) just falls back to the control's designer
        // defaults instead of throwing.
        private void LoadSettings()
        {
            var settings = Properties.Settings.Default;

            checkBox_specialChar.Checked = settings.IncludeSpecialChar;
            checkBox_mangle.Checked = settings.Mangle;
            checkBox_complex.Checked = settings.IncreasedComplexity;
            checkBox_random.Checked = settings.MoreRandom;
            radioButton_dictionary.Checked = settings.UseDictionary;

            // Default has no setting of its own — it's just "not
            // Dictionary". Setting a RadioButton's own Checked to true
            // auto-unchecks the rest of its group, but setting it to
            // false doesn't auto-check anything else, so this still needs
            // to be set explicitly rather than assuming the group sorts
            // itself out.
            radioButton_default.Checked = !settings.UseDictionary;

            decimal batchCount = settings.BatchCount;
            if (
                batchCount >= numericUpDown_batchCount.Minimum
                && batchCount <= numericUpDown_batchCount.Maximum
            )
            {
                numericUpDown_batchCount.Value = batchCount;
            }

            decimal complexLength = settings.ComplexLength;
            if (
                complexLength >= numericUpDown_complexLength.Minimum
                && complexLength <= numericUpDown_complexLength.Maximum
            )
            {
                numericUpDown_complexLength.Value = complexLength;
            }

            decimal minWordLength = settings.MinWordLength;
            if (
                minWordLength >= numericUpDown_minWordLength.Minimum
                && minWordLength <= numericUpDown_minWordLength.Maximum
            )
            {
                numericUpDown_minWordLength.Value = minWordLength;
            }

            decimal maxWordLength = settings.MaxWordLength;
            if (
                maxWordLength >= numericUpDown_maxWordLength.Minimum
                && maxWordLength <= numericUpDown_maxWordLength.Maximum
                && maxWordLength >= numericUpDown_minWordLength.Value
            )
            {
                numericUpDown_maxWordLength.Value = maxWordLength;
            }

            // Reflects the restored checkbox state immediately — setting
            // Checked above only raises CheckedChanged when the value
            // actually flips from the designer default, so a restored
            // value equal to that default (true) would otherwise leave
            // this unsynced (harmlessly, since true is also the correct
            // enabled state — but relying on that coincidence is fragile).
            UpdateWordLengthControlsEnabled();
            UpdateComplexityRandomEnabled();
            UpdateComplexLengthEnabled();
        }

        // Character length only matters while Increased complexity itself
        // is checked — same "disable the dependent control" treatment as
        // Min/Max word length under Use Dictionary.
        private void checkBox_complex_CheckedChanged(object sender, EventArgs e)
        {
            UpdateComplexLengthEnabled();
        }

        private void UpdateComplexLengthEnabled()
        {
            bool enabled = checkBox_complex.Checked;
            label_complexLength.Enabled = enabled;
            numericUpDown_complexLength.Enabled = enabled;
        }

        // Default and Use Dictionary are RadioButtons in the same group
        // (the Form itself — there's no GroupBox), so WinForms already
        // guarantees exactly one of them is checked; no manual cross-
        // unchecking needed. Checking either one fires this exact same
        // event on radioButton_dictionary too (its own Checked flips as
        // the side effect of the other one being selected), so this one
        // handler is enough to catch every selection change regardless of
        // which radio button the user actually clicked.
        //
        // Min/Max word length, and Increased complexity/More random, only
        // matter outside/inside Dictionary mode respectively, so each is
        // disabled the rest of the time — makes the dependency visible
        // instead of just letting a user fiddle with settings that
        // silently do nothing under the current mode.
        private void radioButton_dictionary_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWordLengthControlsEnabled();
            UpdateComplexityRandomEnabled();
        }

        private void UpdateWordLengthControlsEnabled()
        {
            bool enabled = radioButton_dictionary.Checked;
            label_minWordLength.Enabled = enabled;
            numericUpDown_minWordLength.Enabled = enabled;
            label_maxWordLength.Enabled = enabled;
            numericUpDown_maxWordLength.Enabled = enabled;
        }

        // Increased complexity/More random both take priority over
        // Dictionary in GenerateOnePassword()'s if/else-if chain — left
        // merely disabled (not also unchecked) while still checked, they'd
        // keep silently winning over Dictionary despite being greyed out,
        // which is exactly the "why isn't Use Dictionary doing anything"
        // confusion this whole feature exists to avoid. So Dictionary
        // becoming active force-unchecks them too, not just disables them.
        private void UpdateComplexityRandomEnabled()
        {
            bool dictionaryActive = radioButton_dictionary.Checked;

            if (dictionaryActive)
            {
                checkBox_complex.Checked = false;
                checkBox_random.Checked = false;
            }

            checkBox_complex.Enabled = !dictionaryActive;
            checkBox_random.Enabled = !dictionaryActive;
        }

        // Keeps the pair from crossing — the eligible-word filter in
        // GenerateOnePassword() trusts Min <= Max rather than re-checking
        // it, so that invariant needs to hold at the UI layer instead.
        private void numericUpDown_minWordLength_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_minWordLength.Value > numericUpDown_maxWordLength.Value)
            {
                numericUpDown_maxWordLength.Value = numericUpDown_minWordLength.Value;
            }
        }

        private void numericUpDown_maxWordLength_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_maxWordLength.Value < numericUpDown_minWordLength.Value)
            {
                numericUpDown_minWordLength.Value = numericUpDown_maxWordLength.Value;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = Properties.Settings.Default;

            settings.IncludeSpecialChar = checkBox_specialChar.Checked;
            settings.Mangle = checkBox_mangle.Checked;
            settings.IncreasedComplexity = checkBox_complex.Checked;
            settings.MoreRandom = checkBox_random.Checked;
            settings.UseDictionary = radioButton_dictionary.Checked;
            settings.BatchCount = (int)numericUpDown_batchCount.Value;
            settings.ComplexLength = (int)numericUpDown_complexLength.Value;
            settings.MinWordLength = (int)numericUpDown_minWordLength.Value;
            settings.MaxWordLength = (int)numericUpDown_maxWordLength.Value;

            settings.Save();
        }

        private readonly char[] chrConsonants =
        {
            'B',
            'C',
            'D',
            'F',
            'G',
            'H',
            'J',
            'K',
            'L',
            'M',
            'N',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'V',
            'W',
            'X',
            'Y',
            'Z',
        };
        private readonly char[] chrVowels = { 'A', 'E', 'I', 'O', 'U' };
        private readonly char[] chrSpecial =
        {
            '!',
            '@',
            '#',
            '$',
            '%',
            '^',
            '&',
            '*',
            '(',
            ')',
            '?',
        };
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

        private void button_Generate_Click(object sender, EventArgs e)
        {
            int count = (int)numericUpDown_batchCount.Value;
            var passwords = new string[count];

            for (int i = 0; i < count; i++)
            {
                passwords[i] = GenerateOnePassword();
            }

            textBox1.Text = string.Join(Environment.NewLine, passwords);
        }

        // Builds one password according to whichever mode is currently
        // checked, independent of the textbox — so a batch (see
        // numericUpDown_batchCount above) can call this in a loop instead
        // of the generator only ever being able to produce one password
        // per click.
        private string GenerateOnePassword()
        {
            var sb = new StringBuilder();

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
                    AppendRandomChar(sb);
                }
            }
            else if (checkBox_complex.Checked)
            {
                // Alternating consonant/vowel, same as before (first letter
                // upper, rest lower) — just for however many letters
                // numericUpDown_complexLength says instead of a hardcoded
                // 8. Digit count stays fixed at 6, mirroring how Use
                // Dictionary's Min/Max word length only scale the word
                // portion, not the trailing digit suffix.
                int letterLength = (int)numericUpDown_complexLength.Value;
                for (int i = 0; i < letterLength; i++)
                {
                    bool isVowel = i % 2 != 0;
                    char[] alphabet = isVowel ? chrVowels : chrConsonants;
                    char c = alphabet[SecureRandom.Next(0, alphabet.Length)];
                    sb.Append(i == 0 ? c : char.ToLower(c));
                }
                for (int i = 0; i < 6; i++)
                {
                    sb.Append((char)('0' + SecureRandom.Next(0, 10)));
                }
            }
            else if (radioButton_dictionary.Checked)
            {
                EnsureWordsLoaded();

                int minLength = (int)numericUpDown_minWordLength.Value;
                int maxLength = (int)numericUpDown_maxWordLength.Value;
                List<string> eligibleWords = words.FindAll(w =>
                    w.Length >= minLength && w.Length <= maxLength
                );

                // Guards against an empty result (shouldn't happen with
                // word-list.csv's actual length range, but the NumericUpDown
                // bounds are only as trustworthy as that assumption) —
                // falls back to the full list rather than crashing on
                // SecureRandom.Next(0, 0).
                if (eligibleWords.Count == 0)
                {
                    eligibleWords = words;
                }

                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                sb.Append(
                    textInfo.ToTitleCase(eligibleWords[SecureRandom.Next(0, eligibleWords.Count)])
                );
                sb.Append(
                    textInfo.ToTitleCase(eligibleWords[SecureRandom.Next(0, eligibleWords.Count)])
                );
                sb.Append((char)('0' + SecureRandom.Next(0, 10)));
                sb.Append((char)('0' + SecureRandom.Next(0, 10)));
            }
            else
            {
                sb.Append(chrConsonants[SecureRandom.Next(0, chrConsonants.Length)]);
                sb.Append(char.ToLower(chrVowels[SecureRandom.Next(0, chrVowels.Length)]));
                sb.Append(char.ToLower(chrConsonants[SecureRandom.Next(0, chrConsonants.Length)]));
                sb.Append(char.ToLower(chrVowels[SecureRandom.Next(0, chrVowels.Length)]));
                for (int i = 0; i < 4; i++)
                {
                    sb.Append((char)('0' + SecureRandom.Next(0, 10)));
                }
            }

            if (checkBox_specialChar.Checked)
            {
                sb.Append(chrSpecial[SecureRandom.Next(0, chrSpecial.Length)]);
            }

            string password = sb.ToString();
            return checkBox_mangle.Checked ? Mangle(password) : password;
        }

        // Loads the word list once and caches it — previously this ran on
        // every single Generate click without ever clearing `words` first,
        // so the list (and the redundant file read) grew unbounded for the
        // life of the app session. Length filtering used to happen here
        // too, but Min/Max word length are now user-adjustable controls
        // (see numericUpDown_minWordLength/maxWordLength), so the full
        // list is kept and GenerateOnePassword() filters it per-generate
        // against whatever range is currently set.
        //
        // word-list.csv is the EFF long wordlist for dice-generated
        // passphrases (https://www.eff.org/dice, CC BY 3.0 US), with a
        // handful of words removed (crazy, fool, hate, racism, badass) to
        // match this app's own dictionary-word policy — see README.md.
        private void EnsureWordsLoaded()
        {
            if (wordsLoaded)
                return;

            string filename = "word-list.csv";
            string executableLocation = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location
            );
            string csvLocation = Path.Combine(executableLocation, filename);

            using (StreamReader reader = new StreamReader(csvLocation))
            {
                while (!reader.EndOfStream)
                {
                    words.Add(reader.ReadLine());
                }
            }

            wordsLoaded = true;
        }

        private void AppendRandomChar(StringBuilder sb)
        {
            int x = SecureRandom.Next(1, 6);
            switch (x)
            {
                case 1:
                    sb.Append(chrVowels[SecureRandom.Next(0, chrVowels.Length)]);
                    break;
                case 2:
                    sb.Append(char.ToLower(chrVowels[SecureRandom.Next(0, chrVowels.Length)]));
                    break;
                case 3:
                    sb.Append(chrConsonants[SecureRandom.Next(0, chrConsonants.Length)]);
                    break;
                case 4:
                    sb.Append(
                        char.ToLower(chrConsonants[SecureRandom.Next(0, chrConsonants.Length)])
                    );
                    break;
                case 5:
                    sb.Append((char)('0' + SecureRandom.Next(0, 10)));
                    break;
            }
        }

        // Every occurrence of a, e, i, s, and o gets its leet-speak
        // stand-in in one pass — one click now applies the whole set
        // instead of needing repeated clicks to work through it one
        // category at a time. The 5 substitutions target disjoint
        // characters, so applying them in a fixed order (rather than the
        // old random, one-per-click selection) produces the same result
        // regardless of order.
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
            foreach (MangleRule rule in MangleRules)
            {
                text = text.Replace(rule.From.ToString(), rule.To.ToString());
            }

            return text;
        }

        private void Button_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.Text, false, 5, 200);
        }
    }
}
