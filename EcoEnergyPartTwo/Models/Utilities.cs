﻿using System.Drawing;
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
        /// Passa els valors d'un EnergyIndRecord (formulari) a un objecte IndicadorsEnergètics per a la introducció a una BBDD.
        /// </summary>
        /// <param name="ind">El EnergyIndRecord que es vol emmagatzemar a la BBDD.</param>
        /// <returns>Retorna un objecte ConsumsAigua llest per ser emmagatzemat.</returns>
        public static IndicadorsEnergetics AssignEnergyIndForBD(EnergyIndRecord ind)
        {
            IndicadorsEnergetics indBD = new IndicadorsEnergetics
            {
                Data = ind.Data,
                PBEEHidroelectr = ind.PBEEHidroelectr,
                PBEECarbo = ind.PBEECarbo,
                PBEEGasNat = ind.PBEEGasNat,
                PBEEFuelOil = ind.PBEEFuelOil,
                PBEECiclComb = ind.PBEECiclComb,
                PBEENuclear = ind.PBEENuclear,
                CDEEBCProdBruta = ind.CDEEBCProdBruta,
                CDEEBCConsumAux = ind.CDEEBCConsumAux,
                CDEEBCProdNeta = ind.CDEEBCProdNeta,
                CDEEBCConsumBomb = ind.CDEEBCConsumBomb,
                CDEEBCProdDisp = ind.CDEEBCProdDisp,
                CDEEBCTotVendesXarxaCentral = ind.CDEEBCTotVendesXarxaCentral,
                CDEEBCSaldoIntercanviElectr = ind.CDEEBCSaldoIntercanviElectr,
                CDEEBCDemandaElectr = ind.CDEEBCDemandaElectr,
                CDEEBCPercentMercatRegulat = ind.CDEEBCPercentMercatRegulat,
                CDEEBCPercentMercatLliure = ind.CDEEBCPercentMercatLliure,
                FEEIndustria = ind.FEEIndustria,
                FEETerciari = ind.FEETerciari,
                FEEDomestic = ind.FEEDomestic,
                FEEPrimari = ind.FEEPrimari,
                FEEEnergetic = ind.FEEEnergetic,
                FEEIConsObrPub = ind.FEEIConsObrPub,
                FEEISiderFoneria = ind.FEEISiderFoneria,
                FEEIMetalurgia = ind.FEEIMetalurgia,
                FEEIIndusVidre = ind.FEEIIndusVidre,
                FEEICimentsCalGuix = ind.FEEICimentsCalGuix,
                FEEIAltresMatConstr = ind.FEEIAltresMatConstr,
                FEEIQuimPetroquim = ind.FEEIQuimPetroquim,
                FEEIConstrMedTrans = ind.FEEIConstrMedTrans,
                FEEIRestaTransforMetal = ind.FEEIRestaTransforMetal,
                FEEIAlimBegudaTabac = ind.FEEIAlimBegudaTabac,
                FEEITextilConfecCuirCalcat = ind.FEEITextilConfecCuirCalcat,
                FEEIPastaPaperCartro = ind.FEEIPastaPaperCartro,
                FEEIAltresIndus = ind.FEEIAltresIndus,
                DGGNPuntFrontEnagas = ind.DGGNPuntFrontEnagas,
                DGGNDistrAlimGNL = ind.DGGNDistrAlimGNL,
                DGGNConsumGNCentrTerm = ind.DGGNConsumGNCentrTerm,
                CCACGasolinaAuto = ind.CCACGasolinaAuto,
                CCACGasoilA = ind.CCACGasoilA
            };
            return indBD;
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
        /// <returns>Retorna void</returns>
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

        /// <summary>
        /// Fa el seeding del csv d'indicadors energètics a la base de dades
        /// </summary>
        /// <param name="context">El context de la base de dades</param>
        /// <param name="energyIndCsv">La llista de registres del csv</param>
        /// <returns>Retorna void</returns>
        public static void Seed(ApplicationDbContext context, List<EnergyIndRecord> energyIndCsv)
        {
            foreach (EnergyIndRecord row in energyIndCsv)
            {
                IndicadorsEnergetics indicador = new IndicadorsEnergetics
                {
                    Data = row.Data,
                    PBEEHidroelectr = row.PBEEHidroelectr,
                    PBEECarbo = row.PBEECarbo,
                    PBEEGasNat = row.PBEEGasNat,
                    PBEEFuelOil = row.PBEEFuelOil,
                    PBEECiclComb = row.PBEECiclComb,
                    PBEENuclear = row.PBEENuclear,
                    CDEEBCProdBruta = row.CDEEBCProdBruta,
                    CDEEBCConsumAux = row.CDEEBCConsumAux,
                    CDEEBCProdNeta = row.CDEEBCProdNeta,
                    CDEEBCConsumBomb = row.CDEEBCConsumBomb,
                    CDEEBCProdDisp = row.CDEEBCProdDisp,
                    CDEEBCTotVendesXarxaCentral = row.CDEEBCTotVendesXarxaCentral,
                    CDEEBCSaldoIntercanviElectr = row.CDEEBCSaldoIntercanviElectr,
                    CDEEBCDemandaElectr = row.CDEEBCDemandaElectr,
                    CDEEBCPercentMercatRegulat = row.CDEEBCPercentMercatRegulat,
                    CDEEBCPercentMercatLliure = row.CDEEBCPercentMercatLliure,
                    FEEIndustria = row.FEEIndustria,
                    FEETerciari = row.FEETerciari,
                    FEEDomestic = row.FEEDomestic,
                    FEEPrimari = row.FEEPrimari,
                    FEEEnergetic = row.FEEEnergetic,
                    FEEIConsObrPub = row.FEEIConsObrPub,
                    FEEISiderFoneria = row.FEEISiderFoneria,
                    FEEIMetalurgia = row.FEEIMetalurgia,
                    FEEIIndusVidre = row.FEEIIndusVidre,
                    FEEICimentsCalGuix = row.FEEICimentsCalGuix,
                    FEEIAltresMatConstr = row.FEEIAltresMatConstr,
                    FEEIQuimPetroquim = row.FEEIQuimPetroquim,
                    FEEIConstrMedTrans = row.FEEIConstrMedTrans,
                    FEEIRestaTransforMetal = row.FEEIRestaTransforMetal,
                    FEEIAlimBegudaTabac = row.FEEIAlimBegudaTabac,
                    FEEITextilConfecCuirCalcat = row.FEEITextilConfecCuirCalcat,
                    FEEIPastaPaperCartro = row.FEEIPastaPaperCartro,
                    FEEIAltresIndus = row.FEEIAltresIndus,
                    DGGNPuntFrontEnagas = row.DGGNPuntFrontEnagas,
                    DGGNDistrAlimGNL = row.DGGNDistrAlimGNL,
                    DGGNConsumGNCentrTerm = row.DGGNConsumGNCentrTerm,
                    CCACGasolinaAuto = row.CCACGasolinaAuto,
                    CCACGasoilA = row.CCACGasoilA
                };
                IndicadorsEnergeticsCRUD.Insert(context, indicador);
            }
        }
    }
}