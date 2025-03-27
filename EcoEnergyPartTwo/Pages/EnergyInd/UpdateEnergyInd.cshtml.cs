using System.Text.Json;
using EcoEnergyBBDD.CRUDs;
using EcoEnergyBBDD.Data;
using EcoEnergyBBDD.Models.BD;
using EcoEnergyPartTwo.Models;
using EcoEnergyPartTwo.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class UpdateEnergyIndModel : PageModel
    {
        [BindProperty]
        public EnergyIndRecord EI { get; set; }

        [BindProperty(SupportsGet = true)] // Rep la ID per URL
        public int Id { get; set; }

        private readonly ApplicationDbContext _context = new();
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                IndicadorsEnergetics indicadorBD = Utilities.AssignEnergyIndForBD(EI);
                indicadorBD.Id = Id;
                IndicadorsEnergeticsCRUD.Update(_context, indicadorBD);
            }
            return RedirectToPage("/EnergyInd/EnergyInd");
        }
    }
}