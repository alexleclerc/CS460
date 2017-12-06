CREATE TABLE [Buyers]
(
	[BuyerID] int NOT NULL IDENTITY,
	[BuyerName] nvarchar(100) NOT NULL,

	CONSTRAINT [PK_Buyer]
		PRIMARY KEY ([BuyerID])
);
GO

CREATE TABLE [Sellers]
(
	[SellerID] int NOT NULL IDENTITY,
	[SellerName] nvarchar(100) NOT NULL,

	CONSTRAINT [PK_Seller]
		PRIMARY KEY ([SellerID])
);
GO

CREATE TABLE [Items]
(
	[ItemID] int NOT NULL IDENTITY(1001, 1),
	[ItemName] nvarchar(100) NOT NULL,
	[ItemDescription] nvarchar(200),
	[SellerID] int NOT NULL,
	
	CONSTRAINT [PK_Items]
		PRIMARY KEY ([ItemID]),

	CONSTRAINT [FK_Items_Sellers_SellerID]
		FOREIGN KEY ([SellerID])
		REFERENCES [Sellers] ([SellerID])
		ON DELETE CASCADE
);
GO

CREATE TABLE [Bids]
(
	[BidID] int NOT NULL IDENTITY,
	[ItemID] int NOT NULL,
	[BuyerID] int NOT NULL,
	[Price] int NOT NULL,
	[TimeStamp] datetime2 NOT NULL DEFAULT CURRENT_TIMESTAMP

	CONSTRAINT [PK_Bids]
		PRIMARY KEY ([BidID]),
	CONSTRAINT [FK_Bids_Items_ItemID]
		FOREIGN KEY ([ItemID]) REFERENCES [Items] ([ItemID]) ON DELETE CASCADE,
	CONSTRAINT [FK_Bids_Buyers_BuyerID]
		FOREIGN KEY ([BuyerID]) REFERENCES [Buyers] ([BuyerID]) ON DELETE CASCADE
);
GO

INSERT INTO [Buyers] (BuyerName) 
	VALUES 
		('Jane Stone'),
		('Tom McMasters'),
		('Otto Vanderwall');
GO

INSERT INTO [Sellers] (SellerName)
	VALUES
		('Gayle Hardy'),
		('Lyle Banks'),
		('Pearl Greene');
GO

INSERT INTO [Items] (ItemName, ItemDescription, SellerID)
	VALUES
		('Abraham Lincoln Hammer', 'A bench mallet fashioned from a broken rail splitting maul in 1892 and owned by Abraham Lincoln.', (SELECT SellerID FROM Sellers s WHERE SellerName = 'Pearl Greene')),
		('Albert Einsteins Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927.', (SELECT SellerID FROM Sellers s WHERE SellerName = 'Gayle Hardy')),
		('Bob Dylan Love Poems', 'Five versions of original unplublished handwritten, love poem by Bob Dylan.', (SELECT SellerID FROM Sellers s WHERE SellerName = 'Lyle Banks'))
GO

INSERT INTO [Bids] (ItemID, BuyerID, Price)
	VALUES
		((SELECT ItemID FROM Items i WHERE ItemName = 'Abraham Lincoln Hammer'), (SELECT BuyerID FROM Buyers b WHERE BuyerName = 'Otto Vanderwall'), '250000'),
		((SELECT ItemID FROM Items i WHERE ItemName = 'Bob Dylan Love Poems'), (SELECT BuyerID FROM Buyers b WHERE BuyerName = 'Jane Stone'), '95000')
GO
