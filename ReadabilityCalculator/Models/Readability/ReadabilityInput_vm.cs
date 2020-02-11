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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Silly Rabbit, empty input boxes are for kids!")]
        [MinLength(50)]
        [MaxLength(2000)]
        [DisplayName("Input Text:")]
        public string InputText { get; set; }
    }
}
