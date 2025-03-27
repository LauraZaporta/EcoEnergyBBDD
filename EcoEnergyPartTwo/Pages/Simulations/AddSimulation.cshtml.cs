using EcoEnergyPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyPartTwo.Models.Utilities;
using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using EcoEnergyBBDD.Data;
using EcoEnergyBBDD.CRUDs;

namespace EcoEnergyPartTwo.Pages.Simulations
{
    public class AddSimulationModel : PageModel
    {
        [BindProperty]
		public SimulationForm Sim { get; set; }

        private readonly ApplicationDbContext _context = new();
        private Simulacions simForBD = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                switch (Sim.SimulationType)
                {
                    case "Solar":
                        SistemaSolar solar = Utilities.AssignSimulationToSolar(Sim);
                        simForBD = Utilities.AssignSolarForBD(solar);
                        break;
                    case "Hidroelèctrica":
                        SistemaHidroelectric hidro = Utilities.AssignSimulationToHidro(Sim);
                        simForBD = Utilities.AssignHidroForBD(hidro);
                        break;
                    default:
                        SistemaEolic eolic = Utilities.AssignSimulationToEolic(Sim);
                        simForBD = Utilities.AssignEolicForBD(eolic);
                        break;
                }
                SimulacionsCRUD.Insert(_context, simForBD);
            }
            return RedirectToPage("/Simulations/Simulations");
        }
    }
}