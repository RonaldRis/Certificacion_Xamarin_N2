
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2019 11:19:23
-- Generated from EDMX file: C:\Users\CDS12\source\repos\CertificacionN2\EscuelaAPI\EscuelaAPI\Models\DBModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestingRisDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[notas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[notas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'notas'
CREATE TABLE [dbo].[notas] (
    [idnota] int IDENTITY(1,1) NOT NULL,
    [nota1] real  NULL,
    [nota2] real  NULL,
    [nota3] real  NULL,
    [promedio] real  NULL,
    [estado] varchar(15)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idnota] in table 'notas'
ALTER TABLE [dbo].[notas]
ADD CONSTRAINT [PK_notas]
    PRIMARY KEY CLUSTERED ([idnota] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------