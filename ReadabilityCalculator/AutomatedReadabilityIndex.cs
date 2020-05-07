using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadabilityCalculator
{
    public class AutomatedReadabilityIndex : IReadingScore
    {
        public string InputText { get; }
        public double NumberOfWords { get; }
        public double NumberOfSentences { get; }
        public double NumberOfSyllables { get; }
        public double NumberOfCharacters { get; }
        public double ReadingScore { get; }
        public MatchCollection Matches { get; set; }


        public AutomatedReadabilityIndex(string inputText)
        {
            InputTextParser parser = new InputTextParser(inputText);
            InputText = inputText;
            NumberOfWords = parser.GetNumberOfWords();
            NumberOfSentences = parser.GetNumberOfSentences();
            NumberOfSyllables = parser.GetNumberOfSyllables();
            NumberOfCharacters = parser.GetNumberOfCharacters();
            ReadingScore = CalculateScore();
        }

        double CalculateScore()
        {
            double score = 4.71 * (NumberOfCharacters / NumberOfWords) + .5 * (NumberOfWords / NumberOfSentences) - 21.43;
            return Math.Round(score, 2);
        }


    }
}
