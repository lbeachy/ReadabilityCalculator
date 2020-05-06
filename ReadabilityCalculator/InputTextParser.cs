using ReadabilityCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadabilityCalculator
{
    public class InputTextParser
    {
        private string inputText { get; }
        private MatchCollection Matches { get; set; }
        public InputTextParser(string _inputText)
        {
            inputText = _inputText;
        }

        public double GetNumberOfWords()
        {
            Matches = Regex.Matches(inputText, @"\b[^\s]+\b");
            return Matches.Count;
        }

        public double GetNumberOfSentences()
        {
            var sentenceCountFinder = Regex.Matches(inputText, @"\s+[^.!?]*[.!?]");
            return sentenceCountFinder.Count;
        }

        public double GetNumberOfSyllables()
        {
            double numberSyllables = 0;
            var syllableDictionary = new SyllableDictionary();
            foreach (Match word in Matches)
            {
                int syllablesInWord = syllableDictionary.GetNumberOfSyllables(Convert.ToString(word));
                if (syllablesInWord == 0)
                {
                    var syllableCountTemp = Regex.Matches(Convert.ToString(word), @"[aeiouy]+?\w*?[^e]");
                    numberSyllables += syllableCountTemp.Count();
                }

                numberSyllables += syllablesInWord;
            }
            return numberSyllables;
        }

        public double GetNumberOfCharacters()
        {
            double numberOfLetters = 0;
            char[] inputTextAsCharArray = inputText.ToCharArray();
            for (int i = 0; i < inputTextAsCharArray.Length; i++)
            {
                if (Char.IsLetterOrDigit(inputTextAsCharArray[i]))
                {
                    numberOfLetters++;
                }
            }

            return numberOfLetters;
        }


    }
}
