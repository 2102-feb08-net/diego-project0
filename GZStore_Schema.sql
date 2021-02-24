-- GameZoneStore Schema

-- CREATE SCHEMA GZStore;

-- TABLES
CREATE TABLE [GZStore].[Product](
    [ProductID] INT IDENTITY NOT NULL, 
    [Type] NVARCHAR(100),
    [Name] NVARCHAR(100) NOT NULL, 
    [Price] NUMERIC (10,2) NOT NULL, 
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductID])
);
GO

CREATE TABLE [GZStore].[Customer](
    [CustomerID] INT IDENTITY NOT NULL, 
    [FistName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,  
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerID])
);
GO

CREATE TABLE [GZStore].[Order](
    [OrderID] INT IDENTITY NOT NULL, 
    [CustomerID] INT NOT NULL, 
	[OrderDate] DATETIMEOFFSET NOT NULL,
	[OrderTotal] NUMERIC (10,2) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderID])
);
GO

CREATE TABLE [GZStore].[OrderDetail](
    [OrderDetailID] INT IDENTITY NOT NULL, 
    [OrderID] INT NOT NULL,
    [ProductID] INT NOT NULL,
	[Quantity] INT NOT NULL, 
	[TotalPrice] NUMERIC(10,2) NOT NULL, 
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED ([OrderDetailID])
);
GO

-- FOREIGN KEYS
ALTER TABLE [GZStore].[Order] ADD 
	CONSTRAINT [FK_CustomerId] FOREIGN KEY ([CustomerID]) REFERENCES [GZStore].[Customer] ([CustomerID]) ON DELETE CASCADE ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_CustomerId] ON [GZStore].[Order] ([CustomerId]);
GO

ALTER TABLE [GZStore].[OrderDetail] ADD 
	CONSTRAINT [FK_OrderId] FOREIGN KEY ([OrderID]) REFERENCES [GZStore].[Order] ([OrderID]) ON DELETE CASCADE ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_OrderId] ON [GZStore].[OrderDetail] ([OrderID]);
GO
ALTER TABLE [GZStore].[OrderDetail] ADD 
	CONSTRAINT [FK_ProductId] FOREIGN KEY ([ProductID]) REFERENCES [GZStore].[Product] ([ProductID]) ON DELETE CASCADE ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_ProductId] ON [GZStore].[OrderDetail] ([ProductID]);
GO

-- INSERTS
INSERT INTO [GZStore].[Product] VALUES (N'Game Title', N'Super Mario Odyssey', 49.99);
INSERT INTO [GZStore].[Product] VALUES (N'Game Title', N'Mario Kart 8 Deluxe', 49.99);
INSERT INTO [GZStore].[Product] VALUES (N'Game Title', N'Persona 5 Royal', 59.99);
INSERT INTO [GZStore].[Product] VALUES (N'Game Title', N'Marvel Spider-Man: Miles Morales, PS5', 49.99);
INSERT INTO [GZStore].[Product] VALUES (N'Game Title', N'Resident Evil Village, Xbox Series X', 69.99);
INSERT INTO [GZStore].[Product] VALUES (N'Console', N'Nintendo Switch Neon Blue and Neon Red', 299.99);
INSERT INTO [GZStore].[Product] VALUES (N'Console', N'PlayStation 5', 499.99);
INSERT INTO [GZStore].[Product] VALUES (N'Console', N'Xbox Series X', 499.99);
INSERT INTO [GZStore].[Product] VALUES (N'Membership', N'Xbox Game Pass 3 Month Ultimate Membership', 49.99);
INSERT INTO [GZStore].[Product] VALUES (N'Membership', N'PlayStation Plus 3 Month Membership', 24.99);
GO

-- SELECT
SELECT * FROM [GZStore].[Product];

-- DROP TABLE
--DROP TABLE [GZStore].[Product];
--DROP TABLE [GZStore].[Order];
--DROP TABLE [GZStore].[Customer];
--DROP TABLE [GZStore].[OrderDetail];