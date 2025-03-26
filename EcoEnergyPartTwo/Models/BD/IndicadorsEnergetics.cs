using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoEnergyBBDD.Models.BD
{
    public class IndicadorsEnergetics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Data { get; set; }
        public double PBEEHidroelectr { get; set; }
        public double PBEECarbo { get; set; }
        public double PBEEGasNat { get; set; }
        public double PBEEFuelOil { get; set; }
        public double PBEECiclComb { get; set; }
        public double PBEENuclear { get; set; }
        public double CDEEBCProdBruta { get; set; }
        public double CDEEBCConsumAux { get; set; }
        public double CDEEBCProdNeta { get; set; }
        public double CDEEBCConsumBomb { get; set; }
        public double CDEEBCProdDisp { get; set; }
        public double CDEEBCTotVendesXarxaCentral { get; set; }
        public double CDEEBCSaldoIntercanviElectr { get; set; }
        public double CDEEBCDemandaElectr { get; set; }
        public string? CDEEBCPercentMercatRegulat { get; set; } = "50.0%";
        public string? CDEEBCPercentMercatLliure { get; set; } = "50.0%";
        public double? FEEIndustria { get; set; }
        public double? FEETerciari { get; set; }
        public double? FEEDomestic { get; set; }
        public double? FEEPrimari { get; set; }
        public double? FEEEnergetic { get; set; }
        public double? FEEIConsObrPub { get; set; }
        public double? FEEISiderFoneria { get; set; }
        public double? FEEIMetalurgia { get; set; }
        public double? FEEIIndusVidre { get; set; }
        public double? FEEICimentsCalGuix { get; set; }
        public double? FEEIAltresMatConstr { get; set; }
        public double? FEEIQuimPetroquim { get; set; }
        public double? FEEIConstrMedTrans { get; set; }
        public double? FEEIRestaTransforMetal { get; set; }
        public double? FEEIAlimBegudaTabac { get; set; }
        public double? FEEITextilConfecCuirCalcat { get; set; }
        public double? FEEIPastaPaperCartro { get; set; }
        public double? FEEIAltresIndus { get; set; }
        public double DGGNPuntFrontEnagas { get; set; }
        public double DGGNDistrAlimGNL { get; set; }
        public double DGGNConsumGNCentrTerm { get; set; }
        public double CCACGasolinaAuto { get; set; }
        public double CCACGasoilA { get; set; }
    }
}
