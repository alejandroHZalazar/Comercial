USE [master]
GO

/****** Object:  Database [Evoltis]    Script Date: 05/11/2023 17:08:10 ******/
--DROP DATABASE [Evoltis]
--GO

/****** Object:  Database [Evoltis]    Script Date: 05/11/2023 17:08:10 ******/
CREATE DATABASE [Evoltis] ON  PRIMARY 
( NAME = N'Evoltis', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Evoltis.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Evoltis_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Evoltis_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO


/****** Object:  Table [dbo].[Empleado]    Script Date: 05/11/2023 17:06:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Evoltis].[dbo].[Empleado]') AND type in (N'U'))
DROP TABLE [dbo].[Empleado]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 05/11/2023 17:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Evoltis].[dbo].[Empleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](300) NOT NULL,
	[Apellido] [varchar](300) NOT NULL,
	[Email] [varchar](150) NULL,
	[Salario] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
