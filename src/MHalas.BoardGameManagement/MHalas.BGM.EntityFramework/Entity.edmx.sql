
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2019 12:49:07
-- Generated from EDMX file: C:\Git\MHalas.BoardGameManagement\src\MHalas.BoardGameManagement\MHalas.BGM.EntityFramework\Entity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BoardGameManagement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BoardGameBoardGameLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoardGameLog] DROP CONSTRAINT [FK_BoardGameBoardGameLog];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BoardGame]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoardGame];
GO
IF OBJECT_ID(N'[dbo].[BoardGameLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoardGameLog];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BoardGame'
CREATE TABLE [dbo].[BoardGame] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PlayerMinimalAge] int  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'BoardGameLog'
CREATE TABLE [dbo].[BoardGameLog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BoardGameId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Source] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BoardGame'
ALTER TABLE [dbo].[BoardGame]
ADD CONSTRAINT [PK_BoardGame]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BoardGameLog'
ALTER TABLE [dbo].[BoardGameLog]
ADD CONSTRAINT [PK_BoardGameLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BoardGameId] in table 'BoardGameLog'
ALTER TABLE [dbo].[BoardGameLog]
ADD CONSTRAINT [FK_BoardGameBoardGameLog]
    FOREIGN KEY ([BoardGameId])
    REFERENCES [dbo].[BoardGame]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BoardGameBoardGameLog'
CREATE INDEX [IX_FK_BoardGameBoardGameLog]
ON [dbo].[BoardGameLog]
    ([BoardGameId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------