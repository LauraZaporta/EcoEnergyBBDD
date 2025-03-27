using EcoEnergyPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyBBDD.CRUDs;
using EcoEnergyBBDD.Data;
using EcoEnergyBBDD.Models.BD;
using EcoEnergyPartTwo.Models.Utilities;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class AddWaterConModel : PageModel
    {
        [BindProperty]
        public WaterConRecord WC { get; set; }
        private readonly ApplicationDbContext _context = new();

        public IActionResult OnPost()
        {
            // Comprovem si el formulari és vàlid
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                ConsumsAigua consumsAiguaBD = Utilities.AssignWaterConForBD(WC);
                ConsumsAiguaCRUD.Insert(_context, consumsAiguaBD);
            }
            return RedirectToPage("/WaterCon/WaterCon");
        }
    }
}