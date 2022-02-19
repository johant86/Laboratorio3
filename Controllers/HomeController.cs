using Laboratorio3.Models;
using LibraryData;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISentenceService _sentence;

        public HomeController(ISentenceService sentence)
        {
            _sentence = sentence;
        }

        public IActionResult Index()
        {
            Sentence sentence = new Sentence();
            string one =  _sentence.GeChartArt("Visual Studio, 2022.", 0);
            sentence.chain = _sentence.ConcatLetters(one);

            string word = _sentence.WebScraping();
            string two = _sentence.FindLeader(word, "i");
            sentence.chain = _sentence.ConcatLetters(two);

            string three = _sentence.IndexOfData("Visual Studio, 2022.", "s");
            sentence.chain = _sentence.ConcatLetters(three);

            return View(sentence);
        }

    }
}
