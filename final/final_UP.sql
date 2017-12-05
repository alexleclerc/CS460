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
	[SellerName] nvarchar(100) NOT NULL,
	
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
	[TimeStamp] datetime NOT NULL DEFAULT CURRENT_TIMESTAMP

	CONSTRAINT [PK_Bids]
		PRIMARY KEY ([BidID]),
	CONSTRAINT [FK_Bids_Items_ItemID]
		FOREIGN KEY ([ItemID]) REFERENCES [Items] ([ItemID]) ON DELETE CASCADE,
	CONSTRAINT [FK_Bids_Buyers_BuyerID]
		FOREIGN KEY ([BuyerID]) REFERENCES [Buyers] ([BuyerID]) ON DELETE CASCADE
);
GO