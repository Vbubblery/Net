
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/31/2013 16:22:46
-- Generated from EDMX file: C:\Users\Bubble_PC\Desktop\C# MINI PROJECT\ASTHENIA\ASTHENIA\LinkToTheDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GameLogInfo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PlayerCell]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK_PlayerCell];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerObject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Object] DROP CONSTRAINT [FK_PlayerObject];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectTypeObject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Object] DROP CONSTRAINT [FK_ObjectTypeObject];
GO
IF OBJECT_ID(N'[dbo].[FK_WeaponPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Weapon] DROP CONSTRAINT [FK_WeaponPlayer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Player]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Player];
GO
IF OBJECT_ID(N'[dbo].[Cell]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cell];
GO
IF OBJECT_ID(N'[dbo].[Object]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Object];
GO
IF OBJECT_ID(N'[dbo].[ObjectType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjectType];
GO
IF OBJECT_ID(N'[dbo].[Weapon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Weapon];
GO
IF OBJECT_ID(N'[dbo].[Monster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Monster];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Player'
CREATE TABLE [dbo].[Player] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [XP] bigint  NOT NULL,
    [HP] bigint  NOT NULL,
    [MaxHP] bigint  NOT NULL,
    [Cell_ID] int  NOT NULL
);
GO

-- Creating table 'Cell'
CREATE TABLE [dbo].[Cell] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PosX] smallint  NOT NULL,
    [PosY] smallint  NOT NULL,
    [MonsterRate] smallint  NOT NULL,
    [MonsterGroup] smallint  NOT NULL,
    [CanMoveTo] bit  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Object'
CREATE TABLE [dbo].[Object] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PlayerID] int  NOT NULL,
    [ObjectTypeID] int  NOT NULL
);
GO

-- Creating table 'ObjectType'
CREATE TABLE [dbo].[ObjectType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [HPRestoreValue] smallint  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AttackStrenghtBoost] smallint  NOT NULL,
    [DefenseBoost] smallint  NOT NULL
);
GO

-- Creating table 'Weapon'
CREATE TABLE [dbo].[Weapon] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AttackRate] smallint  NOT NULL,
    [MissRate] smallint  NOT NULL,
    [Player_ID] int  NOT NULL
);
GO

-- Creating table 'Monster'
CREATE TABLE [dbo].[Monster] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AttackRate] smallint  NOT NULL,
    [MissRate] smallint  NOT NULL,
    [HP] bigint  NOT NULL,
    [Group] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [PK_Player]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Cell'
ALTER TABLE [dbo].[Cell]
ADD CONSTRAINT [PK_Cell]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Object'
ALTER TABLE [dbo].[Object]
ADD CONSTRAINT [PK_Object]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ObjectType'
ALTER TABLE [dbo].[ObjectType]
ADD CONSTRAINT [PK_ObjectType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Weapon'
ALTER TABLE [dbo].[Weapon]
ADD CONSTRAINT [PK_Weapon]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Monster'
ALTER TABLE [dbo].[Monster]
ADD CONSTRAINT [PK_Monster]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cell_ID] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [FK_PlayerCell]
    FOREIGN KEY ([Cell_ID])
    REFERENCES [dbo].[Cell]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerCell'
CREATE INDEX [IX_FK_PlayerCell]
ON [dbo].[Player]
    ([Cell_ID]);
GO

-- Creating foreign key on [PlayerID] in table 'Object'
ALTER TABLE [dbo].[Object]
ADD CONSTRAINT [FK_PlayerObject]
    FOREIGN KEY ([PlayerID])
    REFERENCES [dbo].[Player]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerObject'
CREATE INDEX [IX_FK_PlayerObject]
ON [dbo].[Object]
    ([PlayerID]);
GO

-- Creating foreign key on [ObjectTypeID] in table 'Object'
ALTER TABLE [dbo].[Object]
ADD CONSTRAINT [FK_ObjectTypeObject]
    FOREIGN KEY ([ObjectTypeID])
    REFERENCES [dbo].[ObjectType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjectTypeObject'
CREATE INDEX [IX_FK_ObjectTypeObject]
ON [dbo].[Object]
    ([ObjectTypeID]);
GO

-- Creating foreign key on [Player_ID] in table 'Weapon'
ALTER TABLE [dbo].[Weapon]
ADD CONSTRAINT [FK_WeaponPlayer]
    FOREIGN KEY ([Player_ID])
    REFERENCES [dbo].[Player]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WeaponPlayer'
CREATE INDEX [IX_FK_WeaponPlayer]
ON [dbo].[Weapon]
    ([Player_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------