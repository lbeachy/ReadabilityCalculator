using ReadabilityCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadabilityCalculator
{
    interface IReadingScore
    {
        string InputText { get; }
        double NumberWords { get; }
        double NumberSentences { get; }
        double NumberSyllables { get; }
        MatchCollection Matches { get; set; }

        double GetWordCount()
        {
            Matches = Regex.Matches(InputText, @"\b[^\s]+\b");
            return Matches.Count;
        }

        double GetSentenceCount()
        {
            var sentenceCountFinder = Regex.Matches(InputText, @"\s+[^.!?]*[.!?]");
            return sentenceCountFinder.Count;
        }

        double GetSyllableCount()
        {
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
            return numberSyllablesTemp;
        }

        double CalculateScore()
        {
            return -99;
        }
    }

}
