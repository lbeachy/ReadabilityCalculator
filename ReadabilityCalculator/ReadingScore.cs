using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ReadabilityCalculator.Models;

namespace ReadabilityCalculator
{
    public class ReadingScore : IReadingScore
    {
        public string InputText { get; }
        public double NumberWords { get; }
        public double NumberSentences { get; }
        public double NumberSyllables { get; }

        public MatchCollection Matches { get; set; }


        public ReadingScore(string inputText)
        {
            InputText = inputText;
            NumberWords = GetWordCount();
            NumberSentences = GetSentenceCount();
            double numberSyllablesTemp = 0;
            var syllableDictionary = new SyllableDictionary();
            foreach (Match word in Matches)
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

        public double GetWordCount()
        {
            Matches = Regex.Matches(InputText, @"\b[^\s]+\b");
            return Matches.Count;
        }

        public double GetSentenceCount()
        {
            var sentenceCountFinder = Regex.Matches(InputText, @"\s+[^.!?]*[.!?]");
            return sentenceCountFinder.Count;
        }

        public double CalculateScore()
        {
            return 206.835 - (1.015 * (NumberWords / NumberSentences)) - (84.6 * (NumberSyllables / NumberWords));
        }
    }
}
