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
        double NumberOfWords { get; }
        double NumberOfSentences { get; }
        double NumberOfSyllables { get; }
        double NumberOfCharacters { get; }
        double ReadingScore { get; }

        double CalculateScore()
        {
            return -99;
        }
    }

}
