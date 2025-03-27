using EcoEnergyBBDD.Data;
using EcoEnergyBBDD.Models.BD;
using EcoEnergyPartTwo.Models;

namespace EcoEnergyBBDD.CRUDs
{
    public class ConsumsAiguaCRUD
    {
        public static void Insert(ApplicationDbContext context, ConsumsAigua con)
        {
            context.ConsumsAigua.Add(con);
            context.SaveChanges();
        }
        public static void DeleteById(ApplicationDbContext context, int id)
        {
            var conToDelete = context.ConsumsAigua.Find(id); //Sempre fa el find per clau primària
            if (conToDelete != null)
            {
                context.ConsumsAigua.Remove(conToDelete);
                context.SaveChanges();
            }
        }
        public static void Update(ApplicationDbContext context, ConsumsAigua con)
        {
            var conToUpdate = context.ConsumsAigua.Find(con.Id);
            if (conToUpdate != null)
            {
                context.Entry(conToUpdate).CurrentValues.SetValues(con);
                context.SaveChanges();
            }
        }
        public static List<ConsumsAigua> SelectAll(ApplicationDbContext context)
        {
            return context.ConsumsAigua.ToList();
        }
    }
}
