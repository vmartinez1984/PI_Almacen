IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BranchType] (
    [Id] int NOT NULL IDENTITY,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [Name] nvarchar(20) NOT NULL,
    [Description] nvarchar(150) NULL,
    CONSTRAINT [PK_BranchType] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [Name] nvarchar(20) NOT NULL,
    [Description] nvarchar(150) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Company] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(150) NOT NULL,
    [Note] nvarchar(255) NULL,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [Street] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ProductStatus] (
    [Id] int NOT NULL IDENTITY,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [Name] nvarchar(20) NOT NULL,
    [Description] nvarchar(150) NULL,
    CONSTRAINT [PK_ProductStatus] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(50) NOT NULL,
    [Password] nvarchar(12) NOT NULL,
    [RolId] int NOT NULL,
    [Name] nvarchar(50) NULL,
    [LastName] nvarchar(50) NULL,
    [Phone] nvarchar(255) NULL,
    [Email] nvarchar(255) NULL,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Branch] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Phone] nvarchar(255) NULL,
    [Email] nvarchar(255) NULL,
    [Note] nvarchar(1000) NULL,
    [CompanyId] int NOT NULL,
    [BranchTypeId] int NOT NULL,
    [TypeBranchId] int NULL,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [Street] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_Branch] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Branch_BranchType_TypeBranchId] FOREIGN KEY ([TypeBranchId]) REFERENCES [BranchType] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Branch_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Product] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(150) NOT NULL,
    [Description] nvarchar(255) NULL,
    [SerieNumber] nvarchar(255) NOT NULL,
    [DateStart] datetime2 NULL,
    [DateStop] datetime2 NULL,
    [CategoryId] int NOT NULL,
    [ProductStatusId] int NOT NULL,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Product_ProductStatus_ProductStatusId] FOREIGN KEY ([ProductStatusId]) REFERENCES [ProductStatus] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Role] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [UserEntityId] int NULL,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Role_User_UserEntityId] FOREIGN KEY ([UserEntityId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Person] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [LastName] nvarchar(255) NOT NULL,
    [Phone] nvarchar(255) NULL,
    [Email] nvarchar(255) NULL,
    [BranchId] int NOT NULL,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Person_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Branch] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ProductAssignment] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [PersonId] int NOT NULL,
    [UserId] int NOT NULL,
    [DateAssignment] datetime2 NOT NULL,
    [DateRegistration] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_ProductAssignment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductAssignment_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductAssignment_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductAssignment_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Description', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[BranchType]'))
    SET IDENTITY_INSERT [BranchType] ON;
INSERT INTO [BranchType] ([Id], [DateRegistration], [Description], [IsActive], [Name])
VALUES (1, '2022-02-11T21:37:34.0021031-06:00', NULL, CAST(1 AS bit), N'Matriz'),
(2, '2022-02-11T21:37:34.0021053-06:00', NULL, CAST(1 AS bit), N'Sucursal');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Description', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[BranchType]'))
    SET IDENTITY_INSERT [BranchType] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Description', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[Category]'))
    SET IDENTITY_INSERT [Category] ON;
INSERT INTO [Category] ([Id], [DateRegistration], [Description], [IsActive], [Name])
VALUES (1, '2022-02-11T21:37:34.0020112-06:00', NULL, CAST(1 AS bit), N'Software'),
(2, '2022-02-11T21:37:34.0020146-06:00', NULL, CAST(1 AS bit), N'Hardware'),
(3, '2022-02-11T21:37:34.0020154-06:00', NULL, CAST(1 AS bit), N'Comunicación');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Description', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[Category]'))
    SET IDENTITY_INSERT [Category] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'IsActive', N'Name', N'Note', N'Street') AND [object_id] = OBJECT_ID(N'[Company]'))
    SET IDENTITY_INSERT [Company] ON;
INSERT INTO [Company] ([Id], [DateRegistration], [IsActive], [Name], [Note], [Street])
VALUES (1, '2022-02-11T21:37:34.0027774-06:00', CAST(1 AS bit), N'Compañia A', N'Prueba', N'Domicilio conocido');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'IsActive', N'Name', N'Note', N'Street') AND [object_id] = OBJECT_ID(N'[Company]'))
    SET IDENTITY_INSERT [Company] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Description', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[ProductStatus]'))
    SET IDENTITY_INSERT [ProductStatus] ON;
INSERT INTO [ProductStatus] ([Id], [DateRegistration], [Description], [IsActive], [Name])
VALUES (1, '2022-02-11T21:37:33.9898385-06:00', NULL, CAST(1 AS bit), N'Activo'),
(2, '2022-02-11T21:37:34.0001805-06:00', NULL, CAST(1 AS bit), N'Asignado'),
(3, '2022-02-11T21:37:34.0001863-06:00', NULL, CAST(1 AS bit), N'Merma'),
(4, '2022-02-11T21:37:34.0001871-06:00', NULL, CAST(1 AS bit), N'Baja por daño'),
(5, '2022-02-11T21:37:34.0001877-06:00', NULL, CAST(1 AS bit), N'Recuperado');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Description', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[ProductStatus]'))
    SET IDENTITY_INSERT [ProductStatus] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Description', N'IsActive', N'Name', N'UserEntityId') AND [object_id] = OBJECT_ID(N'[Role]'))
    SET IDENTITY_INSERT [Role] ON;
INSERT INTO [Role] ([Id], [DateRegistration], [Description], [IsActive], [Name], [UserEntityId])
VALUES (2, '2022-02-11T21:37:34.0022880-06:00', NULL, CAST(1 AS bit), N'Operador', NULL),
(1, '2022-02-11T21:37:34.0022907-06:00', NULL, CAST(1 AS bit), N'Administrador', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Description', N'IsActive', N'Name', N'UserEntityId') AND [object_id] = OBJECT_ID(N'[Role]'))
    SET IDENTITY_INSERT [Role] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Email', N'IsActive', N'LastName', N'Name', N'Password', N'Phone', N'RolId', N'UserName') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] ON;
INSERT INTO [User] ([Id], [DateRegistration], [Email], [IsActive], [LastName], [Name], [Password], [Phone], [RolId], [UserName])
VALUES (1, '2022-02-11T21:37:34.0025872-06:00', NULL, CAST(1 AS bit), N'', N'Administrador', N'123456', NULL, 1, N'administrador');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateRegistration', N'Email', N'IsActive', N'LastName', N'Name', N'Password', N'Phone', N'RolId', N'UserName') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BranchTypeId', N'CompanyId', N'DateRegistration', N'Email', N'IsActive', N'Name', N'Note', N'Phone', N'Street', N'TypeBranchId') AND [object_id] = OBJECT_ID(N'[Branch]'))
    SET IDENTITY_INSERT [Branch] ON;
INSERT INTO [Branch] ([Id], [BranchTypeId], [CompanyId], [DateRegistration], [Email], [IsActive], [Name], [Note], [Phone], [Street], [TypeBranchId])
VALUES (1, 1, 1, '2022-02-11T21:37:34.0029868-06:00', N'correo@dominio.com', CAST(1 AS bit), N'Sucursal', N'Sin observaciones', N'55 5658 1111', N'Domicilio conocido', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BranchTypeId', N'CompanyId', N'DateRegistration', N'Email', N'IsActive', N'Name', N'Note', N'Phone', N'Street', N'TypeBranchId') AND [object_id] = OBJECT_ID(N'[Branch]'))
    SET IDENTITY_INSERT [Branch] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateRegistration', N'DateStart', N'DateStop', N'Description', N'IsActive', N'Name', N'ProductStatusId', N'SerieNumber') AND [object_id] = OBJECT_ID(N'[Product]'))
    SET IDENTITY_INSERT [Product] ON;
INSERT INTO [Product] ([Id], [CategoryId], [DateRegistration], [DateStart], [DateStop], [Description], [IsActive], [Name], [ProductStatusId], [SerieNumber])
VALUES (1, 1, '2022-02-11T21:37:34.0037463-06:00', '2022-02-11T21:37:34.0035631-06:00', '2023-02-11T21:37:34.0036854-06:00', N'Posicion 1/3', CAST(1 AS bit), N'Oficce 360', 1, N'148318'),
(2, 1, '2022-02-11T21:37:34.0039737-06:00', '2022-02-11T21:37:34.0039701-06:00', '2023-02-11T21:37:34.0039722-06:00', N'Posicion 2/3', CAST(1 AS bit), N'Oficce 360', 1, N'148318'),
(3, 1, '2022-02-11T21:37:34.0039754-06:00', '2022-02-11T21:37:34.0039744-06:00', '2023-02-11T21:37:34.0039749-06:00', N'Posicion 3/3', CAST(1 AS bit), N'Oficce 360', 1, N'148318'),
(4, 3, '2022-02-11T21:37:34.0039760-06:00', NULL, NULL, N'Camara axis 1020', CAST(1 AS bit), N'Camara IP', 1, N'148318');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateRegistration', N'DateStart', N'DateStop', N'Description', N'IsActive', N'Name', N'ProductStatusId', N'SerieNumber') AND [object_id] = OBJECT_ID(N'[Product]'))
    SET IDENTITY_INSERT [Product] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BranchId', N'DateRegistration', N'Email', N'IsActive', N'LastName', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Person]'))
    SET IDENTITY_INSERT [Person] ON;
INSERT INTO [Person] ([Id], [BranchId], [DateRegistration], [Email], [IsActive], [LastName], [Name], [Phone])
VALUES (1, 1, '2022-02-11T21:37:34.0032771-06:00', N'ahal_tocob@hotmail.com', CAST(1 AS bit), N'Mtz', N'Víctor', N'55 3273 7357');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BranchId', N'DateRegistration', N'Email', N'IsActive', N'LastName', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Person]'))
    SET IDENTITY_INSERT [Person] OFF;
GO

CREATE INDEX [IX_Branch_CompanyId] ON [Branch] ([CompanyId]);
GO

CREATE INDEX [IX_Branch_TypeBranchId] ON [Branch] ([TypeBranchId]);
GO

CREATE INDEX [IX_Person_BranchId] ON [Person] ([BranchId]);
GO

CREATE INDEX [IX_Product_CategoryId] ON [Product] ([CategoryId]);
GO

CREATE INDEX [IX_Product_ProductStatusId] ON [Product] ([ProductStatusId]);
GO

CREATE INDEX [IX_ProductAssignment_PersonId] ON [ProductAssignment] ([PersonId]);
GO

CREATE INDEX [IX_ProductAssignment_ProductId] ON [ProductAssignment] ([ProductId]);
GO

CREATE INDEX [IX_ProductAssignment_UserId] ON [ProductAssignment] ([UserId]);
GO

CREATE INDEX [IX_Role_UserEntityId] ON [Role] ([UserEntityId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220212033735_v1', N'5.0.14');
GO

COMMIT;
GO

