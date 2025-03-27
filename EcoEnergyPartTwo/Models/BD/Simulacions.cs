using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace EcoEnergyPartTwo.Models
{
    public class Simulacions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Specific field depèn del tipus de simulació (solar - hores de sol,
        // hidroelèctrica - cabal d'aigua, eòlica - velocitat del vent)
        public double SpecificField { get; set; }
        public string? SimulationType { get; set; }
        public DateTime SimulationDate { get; set; }
        public double Rati { get; set; }
        public double GeneratedEnergy { get; set; }
        public double CostkWh { get; set; }
        public double PricekWh { get; set; }
        public double TotalCostkWh { get; set; }
        public double TotalPricekWh { get; set; }
    }
}