using System.Text.Json;
using EcoEnergyBBDD.CRUDs;
using EcoEnergyBBDD.Data;
using EcoEnergyBBDD.Models.BD;
using EcoEnergyPartTwo.Models;
using EcoEnergyPartTwo.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class AddEnergyIndModel : PageModel
    {
        [BindProperty]
        public EnergyIndRecord EI { get; set; }
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
                IndicadorsEnergeticsCRUD.Insert(_context, indicadorBD);
            }
            return RedirectToPage("/EnergyInd/EnergyInd");
        }
    }
}