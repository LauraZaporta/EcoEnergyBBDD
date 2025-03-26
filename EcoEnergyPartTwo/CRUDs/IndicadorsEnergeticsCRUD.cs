using EcoEnergyBBDD.Data;
using EcoEnergyBBDD.Models.BD;
using EcoEnergyPartTwo.Models;

namespace EcoEnergyBBDD.CRUDs
{
    public class IndicadorsEnergeticsCRUD
    {
        public static void Insert(ApplicationDbContext context, IndicadorsEnergetics ind)
        {
            context.IndicadorsEnergetics.Add(ind);
            context.SaveChanges();
        }
        public static void DeleteById(ApplicationDbContext context, int id)
        {
            var indToDelete = context.IndicadorsEnergetics.Find(id); //Sempre fa el find per clau primària
            if (indToDelete != null)
            {
                context.IndicadorsEnergetics.Remove(indToDelete);
                context.SaveChanges();
            }
        }
        public static void Update(ApplicationDbContext context, IndicadorsEnergetics ind)
        {
            var indToUpdate = context.IndicadorsEnergetics.Find(ind.Id);
            if (indToUpdate != null)
            {
                indToUpdate = ind;
                context.SaveChanges();
            }
        }
        public static IList<IndicadorsEnergetics> SelectAll(ApplicationDbContext context)
        {
            return context.IndicadorsEnergetics.ToList();
        }
    }
}
