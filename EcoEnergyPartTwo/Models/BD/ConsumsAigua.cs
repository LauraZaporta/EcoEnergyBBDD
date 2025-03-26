using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoEnergyBBDD.Models.BD
{
    public class ConsumsAigua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Year { get; set; }
        public int CodeComarca { get; set; }
        public string? Comarca { get; set; }
        public int Pobl { get; set; }
        public int DomXarxa { get; set; }
        public int AltresActivitats { get; set; }
        public int Total { get; set; }
        public double ConsumDom { get; set; }
    }
}
