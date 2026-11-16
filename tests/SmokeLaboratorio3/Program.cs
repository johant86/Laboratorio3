using LibraryData;
using Laboratorio3.Controllers;
using Laboratorio3.Models;
using Microsoft.AspNetCore.Mvc;

int checks = 0;
void Check(bool condition, string message)
{
    if (!condition) throw new Exception(message);
    checks++;
}
Environment.SetEnvironmentVariable("LABORATORIO_URL", null);
var service = new SentenceService();
Check(service.GeChartArt("árbol", 0) == "á", "Unicode character");
try { service.GeChartArt("a", -1); throw new Exception("Negative index accepted"); }
catch (ArgumentOutOfRangeException) { checks++; }
Check(service.ConcatLetters("Árbol 2022!") == "Árbol", "Letters filter");
Check(service.FindLeader("Hola VISUAL mundo", "i") == "VISUAL", "Case insensitive search");
Check(service.FindLeader("Hola mundo", "z") == "", "Missing word");
Check(service.IndexOfData("Visual Studio, 2022.", "s") == "2", "Character index");
Check(service.IndexOfData("abc", "z") == "-1", "Missing character index");
Check(service.WebScraping() == "Visual Studio, 2022.", "Offline sample");
var result = (ViewResult)new HomeController(service).Index();
var model = (Sentence)result.Model!;
Check(model.chain == "Carácter inicial: V | Palabra con i: Visual | Índice de s: 2", "Controller must preserve all three results");
Console.WriteLine($"PASS {checks} checks");
