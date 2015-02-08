
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/12/2015 22:10:19
-- Generated from EDMX file: C:\Users\15729_000\documents\visual studio 2013\Projects\2NET-LIU Yaning\2NET-LIU Yaning\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\15729_000\DOCUMENTS\2NET.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DriverCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DriverSet] DROP CONSTRAINT [FK_DriverCity];
GO
IF OBJECT_ID(N'[dbo].[FK_DriverCampus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DriverSet] DROP CONSTRAINT [FK_DriverCampus];
GO
IF OBJECT_ID(N'[dbo].[FK_DriverCarModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DriverSet] DROP CONSTRAINT [FK_DriverCarModel];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DriverSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DriverSet];
GO
IF OBJECT_ID(N'[dbo].[CitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CitySet];
GO
IF OBJECT_ID(N'[dbo].[TripSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TripSet];
GO
IF OBJECT_ID(N'[dbo].[CarModelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarModelSet];
GO
IF OBJECT_ID(N'[dbo].[CampusSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CampusSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DriverSet'
CREATE TABLE [dbo].[DriverSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [Salary] float  NOT NULL,
    [City_Id] int  NOT NULL,
    [Campus_Id] int  NOT NULL,
    [CarModel_Id] int  NOT NULL
);
GO

-- Creating table 'CitySet'
CREATE TABLE [dbo].[CitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TripSet'
CREATE TABLE [dbo].[TripSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Departure] nvarchar(max)  NOT NULL,
    [DepartureTime] datetime  NOT NULL,
    [Arrival] nvarchar(max)  NOT NULL,
    [ArrivalTime] datetime  NOT NULL,
    [ClientFirstName] nvarchar(max)  NOT NULL,
    [ClientLastName] nvarchar(max)  NOT NULL,
    [Driver_Id] int  NULL
);
GO

-- Creating table 'CarModelSet'
CREATE TABLE [dbo].[CarModelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ModelName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CampusSet'
CREATE TABLE [dbo].[CampusSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CampusName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DriverSet'
ALTER TABLE [dbo].[DriverSet]
ADD CONSTRAINT [PK_DriverSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CitySet'
ALTER TABLE [dbo].[CitySet]
ADD CONSTRAINT [PK_CitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TripSet'
ALTER TABLE [dbo].[TripSet]
ADD CONSTRAINT [PK_TripSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CarModelSet'
ALTER TABLE [dbo].[CarModelSet]
ADD CONSTRAINT [PK_CarModelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CampusSet'
ALTER TABLE [dbo].[CampusSet]
ADD CONSTRAINT [PK_CampusSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [City_Id] in table 'DriverSet'
ALTER TABLE [dbo].[DriverSet]
ADD CONSTRAINT [FK_DriverCity]
    FOREIGN KEY ([City_Id])
    REFERENCES [dbo].[CitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DriverCity'
CREATE INDEX [IX_FK_DriverCity]
ON [dbo].[DriverSet]
    ([City_Id]);
GO

-- Creating foreign key on [Campus_Id] in table 'DriverSet'
ALTER TABLE [dbo].[DriverSet]
ADD CONSTRAINT [FK_DriverCampus]
    FOREIGN KEY ([Campus_Id])
    REFERENCES [dbo].[CampusSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DriverCampus'
CREATE INDEX [IX_FK_DriverCampus]
ON [dbo].[DriverSet]
    ([Campus_Id]);
GO

-- Creating foreign key on [CarModel_Id] in table 'DriverSet'
ALTER TABLE [dbo].[DriverSet]
ADD CONSTRAINT [FK_DriverCarModel]
    FOREIGN KEY ([CarModel_Id])
    REFERENCES [dbo].[CarModelSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DriverCarModel'
CREATE INDEX [IX_FK_DriverCarModel]
ON [dbo].[DriverSet]
    ([CarModel_Id]);
GO

-- Creating foreign key on [Driver_Id] in table 'TripSet'
ALTER TABLE [dbo].[TripSet]
ADD CONSTRAINT [FK_TripDriver]
    FOREIGN KEY ([Driver_Id])
    REFERENCES [dbo].[DriverSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TripDriver'
CREATE INDEX [IX_FK_TripDriver]
ON [dbo].[TripSet]
    ([Driver_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------