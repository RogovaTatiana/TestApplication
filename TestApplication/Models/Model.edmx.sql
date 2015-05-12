
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/12/2015 15:27:45
-- Generated from EDMX file: C:\Users\Тиана\Source\Repos\TestApplication2\TestApplication\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestApplication];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UploadHistorySet'
CREATE TABLE [dbo].[UploadHistorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [FileSize] int  NOT NULL,
    [UploadDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UploadHistorySet'
ALTER TABLE [dbo].[UploadHistorySet]
ADD CONSTRAINT [PK_UploadHistorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------