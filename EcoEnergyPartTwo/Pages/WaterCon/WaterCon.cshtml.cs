using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyPartTwo.Models;
using EcoEnergyPartTwo.Models.Utilities;
using System.Xml.Linq;
using EcoEnergyBBDD.Models.BD;
using EcoEnergyBBDD.CRUDs;
using EcoEnergyBBDD.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class WaterConModel : PageModel
    {
        public List<WaterConRecord> waterConsumptionsCsv { get; set; } = new(); // Per llegir el csv
        public List<ConsumsAigua> waterConsumptions { get; set; }

        private readonly ApplicationDbContext _context = new();

        public void OnGet()
        {
            const string CSVpath = "../EcoEnergyPartTwo/wwwroot/Resources/Files/consum_aigua_cat_per_comarques.csv";

            //La base de dades afegirà el csv si aquest existeix i la taula de consums d'aigua és buida
            if (System.IO.File.Exists(CSVpath) && ConsumsAiguaCRUD.SelectAll(_context).Count == 0)
            {
                using (var reader = new StreamReader(CSVpath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    waterConsumptionsCsv = csv.GetRecords<WaterConRecord>().ToList(); //Afegeix csv
                }
                Utilities.Seed(_context, waterConsumptionsCsv);
            }

            waterConsumptions = ConsumsAiguaCRUD.SelectAll(_context);
        }
        public IActionResult OnPostDelete(int id)
        {
            ConsumsAigua con = _context.ConsumsAigua.Find(id);
            if (con != null)
            {
                _context.ConsumsAigua.Remove(con);
                _context.SaveChanges();
                waterConsumptions = ConsumsAiguaCRUD.SelectAll(_context);
            }
            return RedirectToPage();
        }
    }
}