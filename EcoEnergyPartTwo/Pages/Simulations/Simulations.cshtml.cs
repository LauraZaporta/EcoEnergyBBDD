using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyPartTwo.Models;
using EcoEnergyBBDD.CRUDs;
using EcoEnergyBBDD.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyPartTwo.Pages.Simulations
{
	public class SimulationModel : PageModel
	{
        public List<Simulacions> Simulations { get; set; }
        private readonly ApplicationDbContext _context = new();

        public void OnGet()
        {
            Simulations = SimulacionsCRUD.SelectAll(_context);
        }
        public IActionResult OnPostDelete(int id)
        {
            SimulacionsCRUD.DeleteById(_context, id);
            Simulations = SimulacionsCRUD.SelectAll(_context);
            return RedirectToPage();
        }
    }
}