using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadabilityCalculator.Models.Readability;
using ReadabilityCalculator.Models;

namespace ReadabilityCalculator.Controllers
{
    public class ReadabilityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ReadabilityInput_vm model)
        {


            if (string.IsNullOrWhiteSpace(model.InputText))
            {
                ModelState.AddModelError("InputText", "Text cannot be empty or white space.");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var readingScore = new ReadingScore(model.InputText);

            ReadabilityResults_vm viewModel = new ReadabilityResults_vm()
            {
                InputText = model.InputText,
                NumberWords = Convert.ToString(readingScore.NumberWords),
                NumberSentences = Convert.ToString(readingScore.NumberSentences),
                NumberSyllables = Convert.ToString(readingScore.NumberSyllables),
                ReadabilityScore = Convert.ToString(Math.Round(readingScore.CalculateScore(), 2))
            };

            return View("ReadabilityResults", viewModel);

        }
    }
}
