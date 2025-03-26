using EcoEnergyBBDD.Data;
using EcoEnergyPartTwo.Models;

namespace EcoEnergyBBDD.CRUDs
{
    public class SimulacionsCRUD
    {
        public static void Insert(ApplicationDbContext context, Simulacions sim)
        {
            context.Simulacions.Add(sim);
            context.SaveChanges();
        }
        public static void DeleteById(ApplicationDbContext context, int id)
        {
            var simToDelete = context.Simulacions.Find(id); //Sempre fa el find per clau primària
            if (simToDelete != null)
            {
                context.Simulacions.Remove(simToDelete);
                context.SaveChanges();
            }
        }
        public static void Update(ApplicationDbContext context, Simulacions sim)
        {
            var simToUpdate = context.Simulacions.Find(sim.Id);
            if (simToUpdate != null)
            {
                simToUpdate = sim;
                context.SaveChanges();
            }
        }
        public static IList<Simulacions> SelectAll(ApplicationDbContext context)
        {
            return context.Simulacions.ToList();
        }
    }
}