using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Auto_Correct
{
    public partial class Form1 : Form
    {
        private List<string> dictionary = File.ReadLines(@"C:\Users\Nicky\Desktop\wordDict.txt").ToList();

        private StringBuilder currentWord = new StringBuilder();
        private bool inWord = false;
        private int wordStartIndex = -1; // -1 will be the default value

        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength == 0)
            {
                wordStartIndex = -1;
                currentWord.Clear();
                return;
            }

            if (richTextBox1.Text[richTextBox1.TextLength - 1] != ' ')
            {
                if (wordStartIndex == -1)
                    wordStartIndex = richTextBox1.TextLength - 1;

                currentWord.Append(richTextBox1.Text[richTextBox1.TextLength - 1]);
                inWord = true;
            }
            else
            {
                if (inWord)
                {
                    char lastChar = currentWord.ToString()[currentWord.Length - 1];
                    while (lastChar == '.' || lastChar == ',' || lastChar == ';' || lastChar == '!' || lastChar == '?')
                        currentWord.Remove(currentWord.Length - 1, 1);  // removing any punctuation marks

                    AutoCorrectWord(currentWord.ToString().ToLower());    // checking for the word in the dictionary
                }
                    

                inWord = false;
                wordStartIndex = -1;
            }

        }

        private void AutoCorrectWord(string wordToCheck)
        {
            if (!dictionary.Contains(wordToCheck))
            {
                double commonLetters = 0, curCommonRatio = 0, bestCommonRatio = 0;
                string closestWord = string.Empty;
                foreach (var word in dictionary)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (wordToCheck.Length <= i)
                            break;
                        if (word[i] == wordToCheck[i])
                            commonLetters++;
                    }
                    curCommonRatio = commonLetters / wordToCheck.Length;
                    if (curCommonRatio > bestCommonRatio)
                    {
                        closestWord = word;
                        bestCommonRatio = curCommonRatio;
                    }
                    commonLetters = 0;
                }

                richTextBox1.Text = richTextBox1.Text.Remove(wordStartIndex, richTextBox1.TextLength - wordStartIndex);
                richTextBox1.AppendText(closestWord);
            }
           
            currentWord.Clear();
        }

        private void clearTextButton_Click(object sender, EventArgs e)
        {
            richTextBox1.ResetText();

            wordStartIndex = -1;
            currentWord.Clear();
        }
    }
}