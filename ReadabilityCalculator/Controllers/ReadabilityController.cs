using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadabilityCalculator.Models.Readability;
using System.Text.RegularExpressions;

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
            //throw an if statement about ModelState.IsValid property
            if (string.IsNullOrWhiteSpace(model.InputText))
            {
                ModelState.AddModelError("InputText", "Silly Rabbit. Empty text boxes are for kids!");
                return View(model);
            }


            var wordCountFinder = Regex.Matches(model.InputText, @"\b[^\s]+\b");
            double wordCount = wordCountFinder.Count;
            var sentenceCountFinder = Regex.Matches(model.InputText, @"\s+[^.!?]*[.!?]");
            double sentenceCount = sentenceCountFinder.Count;
            var syllableCountFinder = Regex.Matches(model.InputText, @"[aeiouy]+?\w*?[^e]");
            double syllableCount = syllableCountFinder.Count;

            double readingLevel = .39 * (wordCount / sentenceCount)
                + 11.8 * (syllableCount / wordCount)
                - 15.59;

            var viewModel = new ReadabilityResults_vm()
            {
                InputText = model.InputText,
                Words = Convert.ToString(wordCount),
                Sentences = Convert.ToString(sentenceCount),
                Syllables = Convert.ToString(syllableCount),
                Score = Convert.ToString(readingLevel)
            };
            return View("ReadabilityResults", viewModel);
        }
       
    }
}