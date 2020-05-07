using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ReadabilityCalculator.Models;

namespace ReadabilityCalculator
{
    public class FleschKincaidGradeLevel : IReadingScore
    {
        public string InputText { get; }
        public double NumberOfWords { get; }
        public double NumberOfSentences { get; }
        public double NumberOfSyllables { get; }
        public double NumberOfCharacters { get; }
        public double ReadingScore { get; }

        public MatchCollection Matches { get; set; }


        public FleschKincaidGradeLevel(string inputText)
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
            double score = .39 * (NumberOfWords / NumberOfSentences) + 11.8 * (NumberOfSyllables / NumberOfWords) - 15.59;
            return Math.Round(score, 2);
        }
    }
}
