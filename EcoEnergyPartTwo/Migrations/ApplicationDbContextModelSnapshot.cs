﻿// <auto-generated />
using System;
using EcoEnergyBBDD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoEnergyBBDD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcoEnergyBBDD.Models.BD.ConsumsAigua", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AltresActivitats")
                        .HasColumnType("int");

                    b.Property<int>("CodeComarca")
                        .HasColumnType("int");

                    b.Property<string>("Comarca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ConsumDom")
                        .HasColumnType("float");

                    b.Property<int>("DomXarxa")
                        .HasColumnType("int");

                    b.Property<int>("Pobl")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ConsumsAigua");
                });

            modelBuilder.Entity("EcoEnergyBBDD.Models.BD.IndicadorsEnergetics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CCACGasoilA")
                        .HasColumnType("float");

                    b.Property<double>("CCACGasolinaAuto")
                        .HasColumnType("float");

                    b.Property<double>("CDEEBCConsumAux")
                        .HasColumnType("float");

                    b.Property<double>("CDEEBCConsumBomb")
                        .HasColumnType("float");

                    b.Property<double>("CDEEBCDemandaElectr")
                        .HasColumnType("float");

                    b.Property<string>("CDEEBCPercentMercatLliure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CDEEBCPercentMercatRegulat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CDEEBCProdBruta")
                        .HasColumnType("float");

                    b.Property<double>("CDEEBCProdDisp")
                        .HasColumnType("float");

                    b.Property<double>("CDEEBCProdNeta")
                        .HasColumnType("float");

                    b.Property<double>("CDEEBCSaldoIntercanviElectr")
                        .HasColumnType("float");

                    b.Property<double>("CDEEBCTotVendesXarxaCentral")
                        .HasColumnType("float");

                    b.Property<double>("DGGNConsumGNCentrTerm")
                        .HasColumnType("float");

                    b.Property<double>("DGGNDistrAlimGNL")
                        .HasColumnType("float");

                    b.Property<double>("DGGNPuntFrontEnagas")
                        .HasColumnType("float");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("FEEDomestic")
                        .HasColumnType("float");

                    b.Property<double?>("FEEEnergetic")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIAlimBegudaTabac")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIAltresIndus")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIAltresMatConstr")
                        .HasColumnType("float");

                    b.Property<double?>("FEEICimentsCalGuix")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIConsObrPub")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIConstrMedTrans")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIIndusVidre")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIMetalurgia")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIPastaPaperCartro")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIQuimPetroquim")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIRestaTransforMetal")
                        .HasColumnType("float");

                    b.Property<double?>("FEEISiderFoneria")
                        .HasColumnType("float");

                    b.Property<double?>("FEEITextilConfecCuirCalcat")
                        .HasColumnType("float");

                    b.Property<double?>("FEEIndustria")
                        .HasColumnType("float");

                    b.Property<double?>("FEEPrimari")
                        .HasColumnType("float");

                    b.Property<double?>("FEETerciari")
                        .HasColumnType("float");

                    b.Property<double>("PBEECarbo")
                        .HasColumnType("float");

                    b.Property<double>("PBEECiclComb")
                        .HasColumnType("float");

                    b.Property<double>("PBEEFuelOil")
                        .HasColumnType("float");

                    b.Property<double>("PBEEGasNat")
                        .HasColumnType("float");

                    b.Property<double>("PBEEHidroelectr")
                        .HasColumnType("float");

                    b.Property<double>("PBEENuclear")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("IndicadorsEnergetics");
                });

            modelBuilder.Entity("EcoEnergyPartTwo.Models.Simulacions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CostkWh")
                        .HasColumnType("float");

                    b.Property<double>("GeneratedEnergy")
                        .HasColumnType("float");

                    b.Property<double>("PricekWh")
                        .HasColumnType("float");

                    b.Property<double>("Rati")
                        .HasColumnType("float");

                    b.Property<DateTime>("SimulationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SimulationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SpecificField")
                        .HasColumnType("float");

                    b.Property<double>("TotalCostkWh")
                        .HasColumnType("float");

                    b.Property<double>("TotalPricekWh")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Simulacions");
                });
#pragma warning restore 612, 618
        }
    }
}
