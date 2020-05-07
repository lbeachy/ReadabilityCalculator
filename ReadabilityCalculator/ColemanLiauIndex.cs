using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ReadabilityCalculator
{
    public class ColemanLiauIndex : IReadingScore
    {
        public string InputText { get; }
        public double NumberOfWords { get; }
        public double NumberOfSentences { get; }
        public double NumberOfSyllables { get; }
        public double NumberOfCharacters { get; }
        public double ReadingScore { get; }
        public MatchCollection Matches { get; set; }

        public ColemanLiauIndex(string inputText)
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
            double score = .0588 * (NumberOfCharacters / (NumberOfWords/100)) - .296 * (NumberOfSentences / (NumberOfWords / 100)) - 15.8;
            return Math.Round(score, 2);
        }
    }
}
