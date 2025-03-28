USE [master]
GO
/****** Object:  Database [EcoEnergy]    Script Date: 28/03/2025 5:25:39 ******/
CREATE DATABASE [EcoEnergy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EcoEnergy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EcoEnergy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EcoEnergy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EcoEnergy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EcoEnergy] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EcoEnergy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EcoEnergy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EcoEnergy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EcoEnergy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EcoEnergy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EcoEnergy] SET ARITHABORT OFF 
GO
ALTER DATABASE [EcoEnergy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EcoEnergy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EcoEnergy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EcoEnergy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EcoEnergy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EcoEnergy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EcoEnergy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EcoEnergy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EcoEnergy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EcoEnergy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EcoEnergy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EcoEnergy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EcoEnergy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EcoEnergy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EcoEnergy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EcoEnergy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EcoEnergy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EcoEnergy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EcoEnergy] SET  MULTI_USER 
GO
ALTER DATABASE [EcoEnergy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EcoEnergy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EcoEnergy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EcoEnergy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EcoEnergy] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EcoEnergy] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EcoEnergy] SET QUERY_STORE = ON
GO
ALTER DATABASE [EcoEnergy] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EcoEnergy]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28/03/2025 5:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsumsAigua]    Script Date: 28/03/2025 5:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsumsAigua](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[CodeComarca] [int] NOT NULL,
	[Comarca] [nvarchar](max) NULL,
	[Pobl] [int] NOT NULL,
	[DomXarxa] [int] NOT NULL,
	[AltresActivitats] [int] NOT NULL,
	[Total] [int] NOT NULL,
	[ConsumDom] [float] NOT NULL,
 CONSTRAINT [PK_ConsumsAigua] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IndicadorsEnergetics]    Script Date: 28/03/2025 5:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicadorsEnergetics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [nvarchar](max) NULL,
	[PBEEHidroelectr] [float] NOT NULL,
	[PBEECarbo] [float] NOT NULL,
	[PBEEGasNat] [float] NOT NULL,
	[PBEEFuelOil] [float] NOT NULL,
	[PBEECiclComb] [float] NOT NULL,
	[PBEENuclear] [float] NOT NULL,
	[CDEEBCProdBruta] [float] NOT NULL,
	[CDEEBCConsumAux] [float] NOT NULL,
	[CDEEBCProdNeta] [float] NOT NULL,
	[CDEEBCConsumBomb] [float] NOT NULL,
	[CDEEBCProdDisp] [float] NOT NULL,
	[CDEEBCTotVendesXarxaCentral] [float] NOT NULL,
	[CDEEBCSaldoIntercanviElectr] [float] NOT NULL,
	[CDEEBCDemandaElectr] [float] NOT NULL,
	[CDEEBCPercentMercatRegulat] [nvarchar](max) NULL,
	[CDEEBCPercentMercatLliure] [nvarchar](max) NULL,
	[FEEIndustria] [float] NULL,
	[FEETerciari] [float] NULL,
	[FEEDomestic] [float] NULL,
	[FEEPrimari] [float] NULL,
	[FEEEnergetic] [float] NULL,
	[FEEIConsObrPub] [float] NULL,
	[FEEISiderFoneria] [float] NULL,
	[FEEIMetalurgia] [float] NULL,
	[FEEIIndusVidre] [float] NULL,
	[FEEICimentsCalGuix] [float] NULL,
	[FEEIAltresMatConstr] [float] NULL,
	[FEEIQuimPetroquim] [float] NULL,
	[FEEIConstrMedTrans] [float] NULL,
	[FEEIRestaTransforMetal] [float] NULL,
	[FEEIAlimBegudaTabac] [float] NULL,
	[FEEITextilConfecCuirCalcat] [float] NULL,
	[FEEIPastaPaperCartro] [float] NULL,
	[FEEIAltresIndus] [float] NULL,
	[DGGNPuntFrontEnagas] [float] NOT NULL,
	[DGGNDistrAlimGNL] [float] NOT NULL,
	[DGGNConsumGNCentrTerm] [float] NOT NULL,
	[CCACGasolinaAuto] [float] NOT NULL,
	[CCACGasoilA] [float] NOT NULL,
 CONSTRAINT [PK_IndicadorsEnergetics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Simulacions]    Script Date: 28/03/2025 5:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Simulacions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpecificField] [float] NOT NULL,
	[SimulationType] [nvarchar](max) NULL,
	[SimulationDate] [datetime2](7) NOT NULL,
	[Rati] [float] NOT NULL,
	[GeneratedEnergy] [float] NOT NULL,
	[CostkWh] [float] NOT NULL,
	[PricekWh] [float] NOT NULL,
	[TotalCostkWh] [float] NOT NULL,
	[TotalPricekWh] [float] NOT NULL,
 CONSTRAINT [PK_Simulacions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [EcoEnergy] SET  READ_WRITE 
GO
