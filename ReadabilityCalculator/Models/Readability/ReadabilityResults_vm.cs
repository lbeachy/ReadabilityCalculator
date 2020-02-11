using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadabilityCalculator.Models.Readability
{
    public class ReadabilityResults_vm
    {
        public string InputText { get; set; }
        public string Words { get; set; }
        public string Sentences { get; set; }
        public string Syllables { get; set; }
        public string Score { get; set; }

    }
}
