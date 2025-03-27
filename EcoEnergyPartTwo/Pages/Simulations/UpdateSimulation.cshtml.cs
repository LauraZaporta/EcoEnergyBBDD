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
    public class UpdateSimulationModel : PageModel
    {
        [BindProperty]
		public SimulationForm Sim { get; set; }

        [BindProperty(SupportsGet = true)] // Rep la ID per URL
        public int Id { get; set; }

        private ApplicationDbContext context = new();

        public IActionResult OnPost()
        {
            Simulacions simForBDUpdate = new Simulacions();
            
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
                        simForBDUpdate = Utilities.AssignSolarForBD(solar);
                        break;
                    case "Hidroelèctrica":
                        SistemaHidroelectric hidro = Utilities.AssignSimulationToHidro(Sim);
                        simForBDUpdate = Utilities.AssignHidroForBD(hidro);
                        break;
                    default:
                        SistemaEolic eolic = Utilities.AssignSimulationToEolic(Sim);
                        simForBDUpdate = Utilities.AssignEolicForBD(eolic);
                        break;
                }
                simForBDUpdate.Id = Id;
                SimulacionsCRUD.Update(context, simForBDUpdate);
            }
            return RedirectToPage("/Simulations/Simulations");
        }
    }
}