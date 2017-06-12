USE [master]
GO

/****** Object:  Database [Calemas.Erp]    Script Date: 05/06/2017 21:07:47 ******/
CREATE DATABASE [Calemas.Erp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Calemas.Erp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Calemas.Erp.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Calemas.Erp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Calemas.Erp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Calemas.Erp] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Calemas.Erp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Calemas.Erp] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Calemas.Erp] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Calemas.Erp] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Calemas.Erp] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Calemas.Erp] SET ARITHABORT OFF 
GO

ALTER DATABASE [Calemas.Erp] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Calemas.Erp] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Calemas.Erp] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Calemas.Erp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Calemas.Erp] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Calemas.Erp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Calemas.Erp] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Calemas.Erp] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Calemas.Erp] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Calemas.Erp] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Calemas.Erp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Calemas.Erp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Calemas.Erp] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Calemas.Erp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Calemas.Erp] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Calemas.Erp] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Calemas.Erp] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Calemas.Erp] SET RECOVERY FULL 
GO

ALTER DATABASE [Calemas.Erp] SET  MULTI_USER 
GO

ALTER DATABASE [Calemas.Erp] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Calemas.Erp] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Calemas.Erp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Calemas.Erp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Calemas.Erp] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Calemas.Erp] SET  READ_WRITE 
GO
