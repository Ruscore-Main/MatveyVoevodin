
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2022 23:10:54
-- Generated from EDMX file: D:\3 курс 2 семестр\MONEY\MatveiVoevodin\MatveiVoevodin\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\RUSLAN\DOCUMENTS\MATVEIVOEVODIN.MDF];
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

-- Creating table 'EmployeeSet'
CREATE TABLE [dbo].[EmployeeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Patronymic] nvarchar(max)  NOT NULL,
    [Post] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ReportSet1'
CREATE TABLE [dbo].[ReportSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] smallint  NOT NULL,
    [Employee_Id] int  NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] int  NOT NULL,
    [Amount] int  NOT NULL,
    [Production_time] nvarchar(max)  NOT NULL,
    [MaterialUsed] nvarchar(max)  NOT NULL,
    [StorageId] int  NULL,
    [ReportId] int  NULL
);
GO

-- Creating table 'StorageSet'
CREATE TABLE [dbo].[StorageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Capacity] int  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [PK_EmployeeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReportSet1'
ALTER TABLE [dbo].[ReportSet1]
ADD CONSTRAINT [PK_ReportSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StorageSet'
ALTER TABLE [dbo].[StorageSet]
ADD CONSTRAINT [PK_StorageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StorageId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_ProductStorage]
    FOREIGN KEY ([StorageId])
    REFERENCES [dbo].[StorageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductStorage'
CREATE INDEX [IX_FK_ProductStorage]
ON [dbo].[ProductSet]
    ([StorageId]);
GO

-- Creating foreign key on [ReportId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_ProductReport]
    FOREIGN KEY ([ReportId])
    REFERENCES [dbo].[ReportSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductReport'
CREATE INDEX [IX_FK_ProductReport]
ON [dbo].[ProductSet]
    ([ReportId]);
GO

-- Creating foreign key on [Employee_Id] in table 'ReportSet1'
ALTER TABLE [dbo].[ReportSet1]
ADD CONSTRAINT [FK_EmployeeReport]
    FOREIGN KEY ([Employee_Id])
    REFERENCES [dbo].[EmployeeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeReport'
CREATE INDEX [IX_FK_EmployeeReport]
ON [dbo].[ReportSet1]
    ([Employee_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------