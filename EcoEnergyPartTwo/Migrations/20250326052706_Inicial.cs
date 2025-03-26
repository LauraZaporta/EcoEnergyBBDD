using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoEnergyBBDD.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumsAigua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CodeComarca = table.Column<int>(type: "int", nullable: false),
                    Comarca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pobl = table.Column<int>(type: "int", nullable: false),
                    DomXarxa = table.Column<int>(type: "int", nullable: false),
                    AltresActivitats = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    ConsumDom = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumsAigua", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorsEnergetics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PBEEHidroelectr = table.Column<double>(type: "float", nullable: false),
                    PBEECarbo = table.Column<double>(type: "float", nullable: false),
                    PBEEGasNat = table.Column<double>(type: "float", nullable: false),
                    PBEEFuelOil = table.Column<double>(type: "float", nullable: false),
                    PBEECiclComb = table.Column<double>(type: "float", nullable: false),
                    PBEENuclear = table.Column<double>(type: "float", nullable: false),
                    CDEEBCProdBruta = table.Column<double>(type: "float", nullable: false),
                    CDEEBCConsumAux = table.Column<double>(type: "float", nullable: false),
                    CDEEBCProdNeta = table.Column<double>(type: "float", nullable: false),
                    CDEEBCConsumBomb = table.Column<double>(type: "float", nullable: false),
                    CDEEBCProdDisp = table.Column<double>(type: "float", nullable: false),
                    CDEEBCTotVendesXarxaCentral = table.Column<double>(type: "float", nullable: false),
                    CDEEBCSaldoIntercanviElectr = table.Column<double>(type: "float", nullable: false),
                    CDEEBCDemandaElectr = table.Column<double>(type: "float", nullable: false),
                    CDEEBCPercentMercatRegulat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CDEEBCPercentMercatLliure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FEEIndustria = table.Column<double>(type: "float", nullable: true),
                    FEETerciari = table.Column<double>(type: "float", nullable: true),
                    FEEDomestic = table.Column<double>(type: "float", nullable: true),
                    FEEPrimari = table.Column<double>(type: "float", nullable: true),
                    FEEEnergetic = table.Column<double>(type: "float", nullable: true),
                    FEEIConsObrPub = table.Column<double>(type: "float", nullable: true),
                    FEEISiderFoneria = table.Column<double>(type: "float", nullable: true),
                    FEEIMetalurgia = table.Column<double>(type: "float", nullable: true),
                    FEEIIndusVidre = table.Column<double>(type: "float", nullable: true),
                    FEEICimentsCalGuix = table.Column<double>(type: "float", nullable: true),
                    FEEIAltresMatConstr = table.Column<double>(type: "float", nullable: true),
                    FEEIQuimPetroquim = table.Column<double>(type: "float", nullable: true),
                    FEEIConstrMedTrans = table.Column<double>(type: "float", nullable: true),
                    FEEIRestaTransforMetal = table.Column<double>(type: "float", nullable: true),
                    FEEIAlimBegudaTabac = table.Column<double>(type: "float", nullable: true),
                    FEEITextilConfecCuirCalcat = table.Column<double>(type: "float", nullable: true),
                    FEEIPastaPaperCartro = table.Column<double>(type: "float", nullable: true),
                    FEEIAltresIndus = table.Column<double>(type: "float", nullable: true),
                    DGGNPuntFrontEnagas = table.Column<double>(type: "float", nullable: false),
                    DGGNDistrAlimGNL = table.Column<double>(type: "float", nullable: false),
                    DGGNConsumGNCentrTerm = table.Column<double>(type: "float", nullable: false),
                    CCACGasolinaAuto = table.Column<double>(type: "float", nullable: false),
                    CCACGasoilA = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorsEnergetics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificField = table.Column<double>(type: "float", nullable: false),
                    SimulationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimulationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rati = table.Column<double>(type: "float", nullable: false),
                    GeneratedEnergy = table.Column<double>(type: "float", nullable: false),
                    CostkWh = table.Column<double>(type: "float", nullable: false),
                    PricekWh = table.Column<double>(type: "float", nullable: false),
                    TotalCostkWh = table.Column<double>(type: "float", nullable: false),
                    TotalPricekWh = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumsAigua");

            migrationBuilder.DropTable(
                name: "IndicadorsEnergetics");

            migrationBuilder.DropTable(
                name: "Simulacions");
        }
    }
}
