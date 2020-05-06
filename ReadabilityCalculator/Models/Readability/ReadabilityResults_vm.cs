using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ReadabilityCalculator.Models.Readability
{
    public class ReadabilityResults_vm
    {
        [DisplayName("Input Text:")]
        public string InputText { get; set; }

        [DisplayName("Words:")]
        public string NumberOfWords { get; set; }

        [DisplayName("Sentences:")]
        public string NumberOfSentences { get; set; }

        [DisplayName("Syllables:")]
        public string NumberOfSyllables { get; set; }

        [DisplayName("Characters")]
        public string NumberOfCharacters { get; set; }

        [DisplayName("Readability Score:")]
        public string ReadabilityScore { get; set; }


    }
}


