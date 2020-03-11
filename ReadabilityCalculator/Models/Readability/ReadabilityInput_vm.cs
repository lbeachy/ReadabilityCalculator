using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReadabilityCalculator.Models.Readability
{
    public class ReadabilityInput_vm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter text into the text area")]
        [MinLength(10)]
        [DisplayName("Input Text:")]
        public string InputText { get; set; }
    }
}
