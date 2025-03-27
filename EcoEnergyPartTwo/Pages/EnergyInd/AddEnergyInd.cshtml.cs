using System.Text.Json;
using EcoEnergyPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class AddEnergyIndModel : PageModel
    {
        [BindProperty]
        public EnergyIndRecord EI { get; set; }

        public IActionResult OnPost()
        {

            return RedirectToPage("/EnergyInd/EnergyInd");
        }
    }
}