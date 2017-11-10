﻿CREATE TABLE dbo.Addresses
(
	ID			INT IDENTITY (1,1)	NOT NULL,
	FirstName	NVARCHAR(64)		NOT NULL,
	MiddleName	NVARCHAR(64),
	LastName    NVARCHAR(128)		NOT NULL,
	DOB			DateTime			NOT NULL,
	Addr		NVARCHAR(128)		NOT NULL,
	City		NVARCHAR(128)		NOT NULL,
	USState		NVARCHAR(128)		NOT NULL,
	County		NVARCHAR(128),
	CONSTRAINT [PK_dbo.Addresses] PRIMARY KEY CLUSTERED (ID ASC)
)