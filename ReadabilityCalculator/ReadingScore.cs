using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ReadabilityCalculator.Models;

namespace ReadabilityCalculator
{
    public class ReadingScore
    {
        private string _inputText { get; set; }
        public double NumberWords { get; }
        public double NumberSentences { get; }
        public double NumberSyllables { get; }
        private MatchCollection matches;
        

        public ReadingScore(string inputText)
        {
            _inputText = inputText;
            NumberWords = GetWordCount(_inputText);
            NumberSentences = GetSentenceCount(_inputText);
            double numberSyllablesTemp = 0;
            var syllableDictionary = new SyllableDictionary();
            foreach (Match word in matches)
            {
                int syllablesInWord = syllableDictionary.GetSyllableCount(Convert.ToString(word));
                if (syllablesInWord == 0)
                {
                    var syllableCountTemp = Regex.Matches(Convert.ToString(word), @"[aeiouy]+?\w*?[^e]");
                    numberSyllablesTemp += syllableCountTemp.Count();
                }

                numberSyllablesTemp += syllablesInWord;
            }
            NumberSyllables = numberSyllablesTemp;

            
        }

        public double GetWordCount(string text)
        {
            matches = Regex.Matches(text, @"\b[^\s]+\b");
            return matches.Count;
        }

        public double GetSentenceCount(string text)
        {
            var sentenceCountFinder = Regex.Matches(text, @"\s+[^.!?]*[.!?]");
            return sentenceCountFinder.Count;
        }

        public double CalculateScore(double words, double sentences, double syllables)
        {
            return 206.835 - (1.015 * (words / sentences)) - (84.6 * (syllables / words));
        }
    }
}
