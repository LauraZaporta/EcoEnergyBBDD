using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyPartTwo.Models;
using CsvHelper;
using System.Globalization;
using EcoEnergyBBDD.CRUDs;
using EcoEnergyBBDD.Data;
using EcoEnergyBBDD.Models.BD;
using EcoEnergyPartTwo.Models.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyPartTwo.Pages.EnergyInd
{
    public class EnergyIndModel : PageModel
    {
        public List<EnergyIndRecord> energyIndicatorsCsv { get; set; } = new(); // Per llegir el csv
        public List<IndicadorsEnergetics> energyIndicators { get; set; }

        private readonly ApplicationDbContext _context = new();

        public void OnGet()
        {
            const string CSVpath = "../EcoEnergyPartTwo/wwwroot/Resources/Files/indicadors_energetics_cat.csv";

            if (System.IO.File.Exists(CSVpath) && IndicadorsEnergeticsCRUD.SelectAll(_context).Count == 0)
            {
                using (var reader = new StreamReader(CSVpath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    energyIndicatorsCsv = csv.GetRecords<EnergyIndRecord>().ToList();
                }
                Utilities.Seed(_context, energyIndicatorsCsv);
            }

            energyIndicators = IndicadorsEnergeticsCRUD.SelectAll(_context);
        }
        public IActionResult OnPostDelete(int id)
        {
            IndicadorsEnergeticsCRUD.DeleteById(_context, id);
            energyIndicators = IndicadorsEnergeticsCRUD.SelectAll(_context);
            return RedirectToPage();
        }
    }
}