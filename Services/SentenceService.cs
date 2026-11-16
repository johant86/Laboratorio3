using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace LibraryData
{
    // Contrato consumido por HomeController; el proyecto externo original no estaba incluido.
    public interface ISentenceService
    {
        string GeChartArt(string texto, int posicion);
        string ConcatLetters(string texto);
        string FindLeader(string texto, string patron);
        string IndexOfData(string texto, string dato);
        string WebScraping();
    }

    public sealed class SentenceService : ISentenceService
    {
        public string GeChartArt(string texto, int posicion)
        {
            ArgumentNullException.ThrowIfNull(texto);
            if (posicion < 0 || posicion >= texto.Length) throw new ArgumentOutOfRangeException(nameof(posicion));
            return texto[posicion].ToString();
        }

        public string ConcatLetters(string texto) => new string((texto ?? "").Where(char.IsLetter).ToArray());

        public string FindLeader(string texto, string patron)
        {
            if (String.IsNullOrEmpty(patron)) return "";
            return Regex.Split(texto ?? "", @"\s+").FirstOrDefault(p => p.Contains(patron, StringComparison.OrdinalIgnoreCase)) ?? "";
        }

        public string IndexOfData(string texto, string dato) =>
            (texto ?? "").IndexOf(dato ?? "", StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture);

        public string WebScraping()
        {
            string origen = Environment.GetEnvironmentVariable("LABORATORIO_URL");
            // La muestra local permite abrir el ejercicio sin conexión ni servicios ajenos.
            if (String.IsNullOrWhiteSpace(origen)) return "Visual Studio, 2022.";
            if (!Uri.TryCreate(origen, UriKind.Absolute, out Uri uri) || (uri.Scheme != "http" && uri.Scheme != "https"))
                throw new ArgumentException("LABORATORIO_URL debe ser una dirección HTTP o HTTPS");
            using var cliente = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
            string html = cliente.GetStringAsync(uri).GetAwaiter().GetResult();
            return WebUtility.HtmlDecode(Regex.Replace(html, "<[^>]+>", " "));
        }
    }
}
