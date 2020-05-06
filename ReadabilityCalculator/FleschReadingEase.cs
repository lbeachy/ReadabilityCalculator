using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ReadabilityCalculator.Models;

namespace ReadabilityCalculator
{
    public class FleschReadingEase : IReadingScore
    {
        public string InputText { get; }
        public double NumberOfWords { get; }
        public double NumberOfSentences { get; }
        public double NumberOfSyllables { get; }
        public double NumberOfCharacters { get; }
        public double ReadingScore { get; }

        public FleschReadingEase(string inputText)
        {
            InputTextParser parser = new InputTextParser(inputText);
            InputText = inputText;
            NumberOfWords = parser.GetNumberOfWords();
            NumberOfSentences = parser.GetNumberOfSentences();
            NumberOfSyllables = parser.GetNumberOfSyllables();
            NumberOfCharacters = parser.GetNumberOfCharacters();
            ReadingScore = CalculateScore();
        }

        
        public double CalculateScore()
        {
            double score = 206.835 - (1.015 * (NumberOfWords / NumberOfSentences)) - 84.6 * (NumberOfSyllables / NumberOfWords);
            if (score > 100)
            {
                score = 100;
            }
            return Math.Round(score, 2);
        }
    }
}
