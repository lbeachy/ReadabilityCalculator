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
        public string NumberWords { get; set; }

        [DisplayName("Sentences:")]
        public string NumberSentences { get; set; }

        [DisplayName("Syllables:")]
        public string NumberSyllables { get; set; }

        [DisplayName("Readability Score:")]
        public string ReadabilityScore { get; set; }


    }
}


