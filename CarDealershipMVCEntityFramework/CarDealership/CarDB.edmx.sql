
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/13/2015 12:34:34
-- Generated from EDMX file: C:\Concordia Program\CarDealershipWeekFive\CarDealership\CarDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Car]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Car];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ECars'
CREATE TABLE [dbo].[ECars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Make] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Year] nvarchar(4)  NOT NULL,
    [ImageUrl] nvarchar(max)  NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Price] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id], [Make], [Model], [Year], [Title], [Price] in table 'ECars'
ALTER TABLE [dbo].[ECars]
ADD CONSTRAINT [PK_ECars]
    PRIMARY KEY CLUSTERED ([Id], [Make], [Model], [Year], [Title], [Price] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------