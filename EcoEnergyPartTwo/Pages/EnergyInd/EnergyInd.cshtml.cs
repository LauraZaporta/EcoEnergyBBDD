using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyPartTwo.Models;
using CsvHelper;
using System.Globalization;
using System.Text.Json;

namespace EcoEnergyPartTwo.Pages.WaterCon
{
    public class EnergyIndModel : PageModel
    {
        public List<EnergyIndRecord> energyIndicators { get; set; } = new(); //Unir� el csv i el json

        public void OnGet()
        {
            const string CSVpath = "../EcoEnergyPartTwo/wwwroot/Resources/Files/indicadors_energetics_cat.csv";
            const string JSONpath = "../EcoEnergyPartTwo/wwwroot/Resources/Files/indicadors_energetics_cat.json";

            if (System.IO.File.Exists(CSVpath))
            {
                using (var reader = new StreamReader(CSVpath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    energyIndicators = csv.GetRecords<EnergyIndRecord>().ToList();
                }
            }

            if (System.IO.File.Exists(JSONpath))
            {
                var jsonContent = System.IO.File.ReadAllText(JSONpath);
                var parsedJson = JsonDocument.Parse(jsonContent);

                if (parsedJson.RootElement.TryGetProperty("Data", out JsonElement dataArray))
                {
                    foreach (var item in dataArray.EnumerateArray())
                    {
                        var record = new EnergyIndRecord
                        {
                            Data = item.GetProperty("Data").GetString(),
                            PBEEHidroelectr = item.GetProperty("PBEEHidroelectr").GetDouble(),
                            PBEECarbo = item.GetProperty("PBEECarbo").GetDouble(),
                            PBEEGasNat = item.GetProperty("PBEEGasNat").GetDouble(),
                            PBEEFuelOil = item.GetProperty("PBEEFuelOil").GetDouble(),
                            PBEECiclComb = item.GetProperty("PBEECiclComb").GetDouble(),
                            PBEENuclear = item.GetProperty("PBEENuclear").GetDouble(),
                            CDEEBCProdBruta = item.GetProperty("CDEEBCProdBruta").GetDouble(),
                            CDEEBCConsumAux = item.GetProperty("CDEEBCConsumAux").GetDouble(),
                            CDEEBCProdNeta = item.GetProperty("CDEEBCProdNeta").GetDouble(),
                            CDEEBCConsumBomb = item.GetProperty("CDEEBCConsumBomb").GetDouble(),
                            CDEEBCProdDisp = item.GetProperty("CDEEBCProdDisp").GetDouble(),
                            CDEEBCTotVendesXarxaCentral = item.GetProperty("CDEEBCTotVendesXarxaCentral").GetDouble(),
                            CDEEBCSaldoIntercanviElectr = item.GetProperty("CDEEBCSaldoIntercanviElectr").GetDouble(),
                            CDEEBCDemandaElectr = item.GetProperty("CDEEBCDemandaElectr").GetDouble(),
                            CDEEBCPercentMercatRegulat = item.GetProperty("CDEEBCPercentMercatRegulat").GetString(),
                            CDEEBCPercentMercatLliure = item.GetProperty("CDEEBCPercentMercatLliure").GetString(),
                            FEEIndustria = item.GetProperty("FEEIndustria").GetDouble(),
                            FEETerciari = item.GetProperty("FEETerciari").GetDouble(),
                            FEEDomestic = item.GetProperty("FEEDomestic").GetDouble(),
                            FEEPrimari = item.GetProperty("FEEPrimari").GetDouble(),
                            FEEEnergetic = item.GetProperty("FEEEnergetic").GetDouble(),
                            FEEIConsObrPub = item.GetProperty("FEEIConsObrPub").GetDouble(),
                            FEEISiderFoneria = item.GetProperty("FEEISiderFoneria").GetDouble(),
                            FEEIMetalurgia = item.GetProperty("FEEIMetalurgia").GetDouble(),
                            FEEIIndusVidre = item.GetProperty("FEEIIndusVidre").GetDouble(),
                            FEEICimentsCalGuix = item.GetProperty("FEEICimentsCalGuix").GetDouble(),
                            FEEIAltresMatConstr = item.GetProperty("FEEIAltresMatConstr").GetDouble(),
                            FEEIQuimPetroquim = item.GetProperty("FEEIQuimPetroquim").GetDouble(),
                            FEEIConstrMedTrans = item.GetProperty("FEEIConstrMedTrans").GetDouble(),
                            FEEIRestaTransforMetal = item.GetProperty("FEEIRestaTransforMetal").GetDouble(),
                            FEEIAlimBegudaTabac = item.GetProperty("FEEIAlimBegudaTabac").GetDouble(),
                            FEEITextilConfecCuirCalcat = item.GetProperty("FEEITextilConfecCuirCalcat").GetDouble(),
                            FEEIPastaPaperCartro = item.GetProperty("FEEIPastaPaperCartro").GetDouble(),
                            FEEIAltresIndus = item.GetProperty("FEEIAltresIndus").GetDouble(),
                            DGGNPuntFrontEnagas = item.GetProperty("DGGNPuntFrontEnagas").GetDouble(),
                            DGGNDistrAlimGNL = item.GetProperty("DGGNDistrAlimGNL").GetDouble(),
                            DGGNConsumGNCentrTerm = item.GetProperty("DGGNConsumGNCentrTerm").GetDouble(),
                            CCACGasolinaAuto = item.GetProperty("CCACGasolinaAuto").GetDouble(),
                            CCACGasoilA = item.GetProperty("CCACGasoilA").GetDouble()
                        };

                        energyIndicators.Add(record);
                    };
                }
            }
        }
    }
}