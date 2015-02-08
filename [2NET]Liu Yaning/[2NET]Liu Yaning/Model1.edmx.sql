
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/07/2015 13:43:13
-- Generated from EDMX file: C:\Users\15729_000\Documents\GitHub\Net\[2NET]]Liu Yaning\[2NET]]Liu Yaning\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [2NET2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DishSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DishSet];
GO
IF OBJECT_ID(N'[dbo].[WaiterSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WaiterSet];
GO
IF OBJECT_ID(N'[dbo].[MapSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MapSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DishSet'
CREATE TABLE [dbo].[DishSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL
);
GO

-- Creating table 'WaiterSet'
CREATE TABLE [dbo].[WaiterSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tables] int  NOT NULL,
    [Earned] float  NOT NULL,
    [Sexy] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MapSet'
CREATE TABLE [dbo].[MapSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HaveTable] bit  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Potion] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DishSet'
ALTER TABLE [dbo].[DishSet]
ADD CONSTRAINT [PK_DishSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WaiterSet'
ALTER TABLE [dbo].[WaiterSet]
ADD CONSTRAINT [PK_WaiterSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MapSet'
ALTER TABLE [dbo].[MapSet]
ADD CONSTRAINT [PK_MapSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------