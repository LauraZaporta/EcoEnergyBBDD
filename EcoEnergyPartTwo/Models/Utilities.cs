using System.Drawing;
using System.Text.RegularExpressions;
using EcoEnergyBBDD.CRUDs;
using EcoEnergyBBDD.Data;
using EcoEnergyBBDD.Models.BD;

namespace EcoEnergyPartTwo.Models.Utilities
{
    public class Utilities
    {
        /// <summary>
        /// Comprova si un número no està dins d'un rang mínim.
        /// </summary>
        /// <param name="num">El número que es vol comprovar.</param>
        /// <param name="min">El valor mínim del rang.</param>
        /// <returns>Retorna true si el número és menor que el valor mínim; sinó, retorna false.</returns>
        public static bool CheckNotInRange(double num, double min)
        {
            return num < min;
        }

        /// <summary>
        /// Comprova si una string està tota en majúscules.
        /// </summary>
        /// <param name="word">La paraula que es vol analitzar.</param>
        /// <returns>Retorna true si la string està tota en majúscules; sinó, retorna false.</returns>
        public static bool IsAllUpper(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (!Char.IsUpper(word[i]) && word[i] != ' ')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Passa els valors d'un formulari a un objecte SistemaSolar i el retorna.
        /// </summary>
        /// <param name="form">El formulari del qual es volen prendre els paràmetres.</param>
        /// <returns>Retorna un objecte SistemaSolar amb els valors del formulari.</returns>
        public static SistemaSolar AssignSimulationToSolar(SimulationForm form)
        {
            SistemaSolar solar = new SistemaSolar
            {
                SimulationType = form.SimulationType,
                SimulationDate = DateTime.Now,
                Rati = form.Rati,
                HoursOfSun = form.SpecificField,
                CostkWh = form.CostkWh,
                PricekWh = form.PricekWh
            };
            solar.GeneratedEnergy = solar.CalcularEnergia();
            solar.AssignTotalCost();
            solar.AssignTotalPrice();
            return solar;
        }

        /// <summary>
        /// Passa els valors d'un SistemaSolar a un objecte Simulacions per a la introducció a una BBDD.
        /// </summary>
        /// <param name="solar">El SistemaSolar que es vol emmagatzemar a la BBDD.</param>
        /// <returns>Retorna un objecte Simulacions llest per ser emmagatzemat.</returns>
        public static Simulacions AssignSolarForBD(SistemaSolar solar)
        {
            Simulacions sim = new Simulacions
            {
                SpecificField = solar.HoursOfSun,
                SimulationType = solar.SimulationType,
                SimulationDate = solar.SimulationDate,
                Rati = solar.Rati,
                GeneratedEnergy = solar.GeneratedEnergy,
                CostkWh= solar.CostkWh,
                PricekWh = solar.PricekWh,
                TotalCostkWh = solar.CostTotal,
                TotalPricekWh = solar.PriceTotal
            };
            return sim;
        }

        /// <summary>
        /// Passa els valors d'un formulari a un objecte SistemaHidroelectric i el retorna.
        /// </summary>
        /// <param name="form">El formulari del qual es volen prendre els paràmetres.</param>
        /// <returns>Retorna un objecte SistemaHidroelectric amb els valors del formulari.</returns>
        public static SistemaHidroelectric AssignSimulationToHidro(SimulationForm form)
        {
            SistemaHidroelectric hidro = new SistemaHidroelectric
            {
                SimulationType = form.SimulationType,
                SimulationDate = DateTime.Now,
                Rati = form.Rati,
                WaterFlow = form.SpecificField,
                CostkWh = form.CostkWh,
                PricekWh = form.PricekWh
            };
            hidro.GeneratedEnergy = hidro.CalcularEnergia();
            hidro.AssignTotalCost();
            hidro.AssignTotalPrice();
            return hidro;
        }

        /// <summary>
        /// Passa els valors d'un SistemaHidroelèctric a un objecte Simulacions per a la introducció a una BBDD.
        /// </summary>
        /// <param name="hidro">El SistemaHidroelèctric que es vol emmagatzemar a la BBDD.</param>
        /// <returns>Retorna un objecte Simulacions llest per ser emmagatzemat.</returns>
        public static Simulacions AssignHidroForBD(SistemaHidroelectric hidro)
        {
            Simulacions sim = new Simulacions
            {
                SpecificField = hidro.WaterFlow,
                SimulationType = hidro.SimulationType,
                SimulationDate = hidro.SimulationDate,
                Rati = hidro.Rati,
                GeneratedEnergy = hidro.GeneratedEnergy,
                CostkWh = hidro.CostkWh,
                PricekWh = hidro.PricekWh,
                TotalCostkWh = hidro.CostTotal,
                TotalPricekWh = hidro.PriceTotal
            };
            return sim;
        }

        /// <summary>
        /// Passa els valors d'un formulari a un objecte SistemaEolic i el retorna.
        /// </summary>
        /// <param name="form">El formulari del qual es volen prendre els paràmetres.</param>
        /// <returns>Retorna un objecte SistemaEolic amb els valors del formulari.</returns>
        public static SistemaEolic AssignSimulationToEolic(SimulationForm form)
        {
            SistemaEolic eolic = new SistemaEolic
            {
                SimulationType = form.SimulationType,
                SimulationDate = DateTime.Now,
                Rati = form.Rati,
                WindSpeed = form.SpecificField,
                CostkWh = form.CostkWh,
                PricekWh = form.PricekWh
            };
            eolic.GeneratedEnergy = eolic.CalcularEnergia();
            eolic.AssignTotalCost();
            eolic.AssignTotalPrice();
            return eolic;
        }

        /// <summary>
        /// Passa els valors d'un SistemaEòlic a un objecte Simulacions per a la introducció a una BBDD.
        /// </summary>
        /// <param name="hidro">El SistemaEòlic que es vol emmagatzemar a la BBDD.</param>
        /// <returns>Retorna un objecte Simulacions llest per ser emmagatzemat.</returns>
        public static Simulacions AssignEolicForBD(SistemaEolic eolic)
        {
            Simulacions sim = new Simulacions
            {
                SpecificField = eolic.WindSpeed,
                SimulationType =eolic.SimulationType,
                SimulationDate = eolic.SimulationDate,
                Rati = eolic.Rati,
                GeneratedEnergy = eolic.GeneratedEnergy,
                CostkWh = eolic.CostkWh,
                PricekWh = eolic.PricekWh,
                TotalCostkWh = eolic.CostTotal,
                TotalPricekWh = eolic.PriceTotal
            };
            return sim;
        }

        /// <summary>
        /// Passa els valors d'un WaterConRecord (formulari) a un objecte ConsumsAigua per a la introducció a una BBDD.
        /// </summary>
        /// <param name="con">El WaterConRecord que es vol emmagatzemar a la BBDD.</param>
        /// <returns>Retorna un objecte ConsumsAigua llest per ser emmagatzemat.</returns>
        public static ConsumsAigua AssignWaterConForBD(WaterConRecord con)
        {
            ConsumsAigua conBD = new ConsumsAigua
            {
                Year = con.Year,
                CodeComarca = con.CodeComarca,
                Comarca = con.Comarca,
                Pobl = con.Pobl,
                DomXarxa = con.DomXarxa,
                AltresActivitats = con.AltresActivitats,
                Total = con.Total,
                ConsumDom = con.ConsumDom
            };
            return conBD;
        }

        /// <summary>
        /// Comprova si una string compleix un format de data concret (mm/yyyy) i no supera l'any actual
        /// </summary>
        /// <param name="data">String que representa una data en formaat mes/any.</param>
        /// <returns>Retorna true si la data concorda amb el format i no supera l'any actual; sinó, retorna false.</returns>
        public static bool IsValidDate(string data)
        {
            int anyActual = DateTime.Now.Year;

            if (Regex.IsMatch(data, @"^(0[1-9]|1[0-2])\/\d{4}$"))
            {
                int any = int.Parse(data.Substring(3, 4));
                return any <= anyActual;
            }
            return false;
        }

        /// <summary>
        /// Fa el seeding del csv de consums d'aigua a la base de dades
        /// </summary>
        /// <param name="context">El context de la base de dades</param>
        /// <param name="waterConCsv">La llista de registres del csv</param>
        /// <returns>Retorna void.</returns>
        public static void Seed(ApplicationDbContext context, List<WaterConRecord> waterConCsv)
        {
            foreach(WaterConRecord row in waterConCsv)
            {
                ConsumsAigua consum = new ConsumsAigua
                {
                    Year = row.Year,
                    CodeComarca = row.CodeComarca,
                    Comarca = row.Comarca,
                    Pobl = row.Pobl,
                    DomXarxa = row.DomXarxa,
                    AltresActivitats = row.AltresActivitats,
                    Total = row.Total,
                    ConsumDom = row.ConsumDom
                };
                ConsumsAiguaCRUD.Insert(context, consum);
            }
        }
    }
}