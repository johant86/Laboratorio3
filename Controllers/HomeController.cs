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
            string character = _sentence.GeChartArt("Visual Studio, 2022.", 0);
            string leader = _sentence.FindLeader(_sentence.WebScraping(), "i");
            string index = _sentence.IndexOfData("Visual Studio, 2022.", "s");
            var sentence = new Sentence
            {
                chain = $"Carácter inicial: {character} | Palabra con i: {leader} | Índice de s: {index}"
            };

            return View(sentence);
        }

    }
}
