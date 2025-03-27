using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyPartTwo.Models;
using EcoEnergyPartTwo.Models.Utilities;
using System.Xml.Linq;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class WaterConModel : PageModel
    {
        public List<WaterConRecord> waterConsumptions { get; set; } = new(); //Unir� el csv i l'xml

        public void OnGet()
        {
            const string CSVpath = "../EcoEnergyPartTwo/wwwroot/Resources/Files/consum_aigua_cat_per_comarques.csv";
            const string XMLpath = "../EcoEnergyPartTwo/wwwroot/Resources/Files/consum_aigua_cat_per_comarques.xml";

            if (System.IO.File.Exists(CSVpath))
            {
                using (var reader = new StreamReader(CSVpath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    waterConsumptions = csv.GetRecords<WaterConRecord>().ToList(); //Afegeix csv
                }
            }
           
            if (System.IO.File.Exists(XMLpath))
            {
                XElement root = XElement.Load(XMLpath);
                var xmlRecords = root.Elements("consum")
                .Where(x => x.Element("year")?.Value != "Any") // Comen�a a llegir despr�s del header
                .Select(x => new WaterConRecord
                {
                    Year = int.Parse(x.Element("year")?.Value ?? "0"),
                    CodeComarca = int.Parse(x.Element("codeComarca")?.Value ?? "0"),
                    Comarca = x.Element("comarca")?.Value ?? "",
                    Pobl = int.Parse(x.Element("pobl")?.Value ?? "0"),
                    DomXarxa = int.Parse(x.Element("domXarxa")?.Value ?? "0"),
                    AltresActivitats = int.Parse(x.Element("altresActivitats")?.Value ?? "0"),
                    Total = int.Parse(x.Element("total")?.Value ?? "0"),
                    ConsumDom = double.Parse(x.Element("consumDom")?.Value ?? "0")
                })
                .ToList();
                waterConsumptions.AddRange(xmlRecords); //Afegeix xml
            }
        }
    }
}