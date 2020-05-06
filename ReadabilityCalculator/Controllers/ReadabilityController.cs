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
        public ActionResult Index(ReadabilityInput_vm model, string btnSubmit)
        {

            
            if (string.IsNullOrWhiteSpace(model.InputText))
            {
                ModelState.AddModelError("InputText", "Text cannot be empty or white space.");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ReadabilityResults_vm viewModel = new ReadabilityResults_vm();
            

            switch (btnSubmit)
            {
                case "Flesch Reading Ease":

                var readingScore = new FleschReadingEase(model.InputText);

                    viewModel.InputText = model.InputText;
                    viewModel.NumberOfWords = Convert.ToString(readingScore.NumberOfWords);
                    viewModel.NumberOfSentences = Convert.ToString(readingScore.NumberOfSentences);
                    viewModel.NumberOfSyllables = Convert.ToString(readingScore.NumberOfSyllables);
                    viewModel.NumberOfCharacters = Convert.ToString(readingScore.NumberOfCharacters);
                    viewModel.ReadabilityScore = Convert.ToString(readingScore.ReadingScore);
                    ViewData["IndexUsed"] = "Flesch Reading Ease";

                break;
                case "Flesch Kincaid Grade Level":
                var readingScore2 = new FleschKincaidGradeLevel(model.InputText);

                    viewModel.InputText = model.InputText;
                    viewModel.NumberOfWords = Convert.ToString(readingScore2.NumberOfWords);
                    viewModel.NumberOfSentences = Convert.ToString(readingScore2.NumberOfSentences);
                    viewModel.NumberOfSyllables = Convert.ToString(readingScore2.NumberOfSyllables);
                    viewModel.NumberOfCharacters = Convert.ToString(readingScore2.NumberOfCharacters);
                    viewModel.ReadabilityScore = Convert.ToString(readingScore2.ReadingScore);
                    ViewData["IndexUsed"] = "Flesch Kincaid Grade Level";

                    break;
                case "Automated Readability Index":
                var readingScore3 = new AutomatedReadabilityIndex(model.InputText);

                    viewModel.InputText = model.InputText;
                    viewModel.NumberOfWords = Convert.ToString(readingScore3.NumberOfWords);
                    viewModel.NumberOfSentences = Convert.ToString(readingScore3.NumberOfSentences);
                    viewModel.NumberOfSyllables = Convert.ToString(readingScore3.NumberOfSyllables);
                    viewModel.NumberOfCharacters = Convert.ToString(readingScore3.NumberOfCharacters);
                    viewModel.ReadabilityScore = Convert.ToString(readingScore3.ReadingScore);
                    ViewData["IndexUsed"] = "Automated Readability Index";

                    break;
                case "Coleman-Liau Index":
                var readingScore4 = new ColemanLiauIndex(model.InputText);

                    viewModel.InputText = model.InputText;
                    viewModel.NumberOfWords = Convert.ToString(readingScore4.NumberOfWords);
                    viewModel.NumberOfSentences = Convert.ToString(readingScore4.NumberOfSentences);
                    viewModel.NumberOfSyllables = Convert.ToString(readingScore4.NumberOfSyllables);
                    viewModel.NumberOfCharacters = Convert.ToString(readingScore4.NumberOfCharacters);
                    viewModel.ReadabilityScore = Convert.ToString(readingScore4.ReadingScore);
                    ViewData["IndexUsed"] = "Coleman-Liau Index";

                    break;
                default:
                    break;
            }
            

            return View("ReadabilityResults", viewModel);

        }

        [HttpPost]
        public IActionResult ReadabilityResults(string button)
        {
            if (button.Equals("Return"))
            {
                return Index();
            }

            return Index();
        }
    }
}
