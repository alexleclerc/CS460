--based off of: https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db

--DATABASE CREATION
CREATE DATABASE [ArtWorks];
GO

USE [ArtWorks];
GO

--TABLE CREATION
CREATE TABLE [Artists] 
(
	[ArtistID] int NOT NULL IDENTITY,
	--I always separate names in databases into first, middle, last
	--in case they need to be searched through one name, or translated
	[FirstName] nvarchar(100) DEFAULT null,
	[MiddleName] nvarchar(100) DEFAULT null,
	[LastName] nvarchar(100) NOT NULL DEFAULT 'Anonymous',
	[BirthDate] date DEFAULT null,
	[BirthCity] nvarchar(100) DEFAULT 'Unknown',

	CONSTRAINT [PK_Artists] 
		PRIMARY KEY ([ArtistID])
);
GO

CREATE TABLE [Artworks]
(
	[ArtworkID] int NOT NULL IDENTITY,
	[ArtistID] int NOT NULL,
	[Title] nvarchar(max) DEFAULT 'Untitled',

	CONSTRAINT [PK_Artworks] 
		PRIMARY KEY ([ArtworkID]),
	CONSTRAINT [FK_Artworks_Artists_ArtistID] 
		FOREIGN KEY ([ArtistID]) 
		REFERENCES [Artists] ([ArtistID]) 
		ON DELETE CASCADE --if an artist is deleted from the database, delete all of their artwork too
);
GO

CREATE TABLE [Genres]
(
	[GenreID] int NOT NULL IDENTITY,
	[Name] nvarchar(max) NOT NULL,
	
	CONSTRAINT [PK_Genres]
		PRIMARY KEY ([GenreID])
);
GO

CREATE TABLE [Classifications]
(
	[ClassificationID] int NOT NULL IDENTITY,
	[ArtworkID] int NOT NULL,
	[GenreID] int NOT NULL,
	
	CONSTRAINT [PK_Classifications]
		PRIMARY KEY ([ClassificationID]),

	--if the artwork is deleted, delete this classification
	CONSTRAINT [FK_Classifications_Artworks_ArtworkID] 
		FOREIGN KEY ([ArtworkID]) REFERENCES [Artworks] ([ArtworkID]) ON DELETE CASCADE,
	--if the genre is deleted, delete this classification
	CONSTRAINT [FK_Classifications_Genre_GenreID]
		FOREIGN KEY ([GenreID]) REFERENCES [Genres] ([GenreID]) ON DELETE CASCADE
)


--INSERT STATEMENTS 
INSERT INTO [Artists] (FirstName, MiddleName, LastName, BirthDate, BirthCity) 
	VALUES 
		--remember, date formats are YYYY-MM-DD
		('M.', 'C.', 'Escher', '1898-06-17', 'Leeuwarden, Netherlands'),
		('Leonardo', null, 'Da Vinci', '1519-05-02', 'Vinci, Italy'),
		('Hatip', 'Mehmed', 'Efendi', '1680-11-18', null),
		('Salvador', null, 'Dali', '1904-05-11', 'Figueres Spain')
GO

INSERT INTO [Artworks] (Title, ArtistID)
	VALUES
	
	--if the previous insert is done in a different order, this will still assign the 
	--correct ArtistID because we are looking for M. C. Escher, not just whatever 
	--artist has int ID of 1.
	('Circle Limit III', (SELECT ArtistID
						  FROM Artists a
						  WHERE a.FirstName = 'M.'
							and a.MiddleName = 'C.'
							and a.LastName = 'Escher')),
	('Twon Tree',		 (SELECT ArtistID
						  FROM Artists a
						  WHERE a.FirstName = 'M.'
							and a.MiddleName = 'C.'
							and a.LastName = 'Escher')),
    ('Mona Lisa',		(SELECT ArtistID
						 FROM Artists a
						 WHERE a.FirstName = 'Leonardo'
						   and a.MiddleName is null
						   and a.LastName = 'Da Vinci')),
    ('The Vitruvian Man',(SELECT ArtistID
						 FROM Artists a
						 WHERE a.FirstName = 'Leonardo'
						   and a.MiddleName is null
						   and a.LastName = 'Da Vinci')),
	('Ebru',			 (SELECT ArtistID
						  FROM Artists a
						  WHERE a.FirstName = 'Hatip'
							and a.MiddleName = 'Mehmed'
							and a.LastName = 'Efendi')),
	('Honey is Sweeter than Blood',
						 (SELECT ArtistID
						  FROM Artists a
						  WHERE a.FirstName = 'Salvador'
							and a.MiddleName is null
							and a.LastName = 'Dali'))
GO

INSERT INTO [Genres] (Name)
	VALUES
	('Tesselation'),
	('Surrealism'),
	('Portrait'),
	('Renaissance')
GO

INSERT INTO [Classifications] (ArtworkID, GenreID)
	VALUES
	((SELECT ArtworkID
	  FROM Artworks a
	  WHERE a.Title = 'Circle Limit III'), 
	 (SELECT GenreID
	  FROM Genres g
	  WHERE g.Name = 'Tesselation')),
	--
	((SELECT ArtworkID
	  FROM Artworks a
	  WHERE a.Title = 'Twon Tree'), 
	 (SELECT GenreID
	  FROM Genres g
	  WHERE g.Name = 'Tesselation')),
	--
	((SELECT ArtworkID
	  FROM Artworks a
	  WHERE a.Title = 'Twon Tree'), 
	 (SELECT GenreID
	  FROM Genres g
	  WHERE g.Name = 'Surrealism')),
	--
	((SELECT ArtworkID
	  FROM Artworks a
	  WHERE a.Title = 'Mona Lisa'), 
	 (SELECT GenreID
	  FROM Genres g
	  WHERE g.Name = 'Portrait')),
	 --
	((SELECT ArtworkID
	  FROM Artworks a
	  WHERE a.Title = 'Mona Lisa'), 
	 (SELECT GenreID
	  FROM Genres g
	  WHERE g.Name = 'Renaissance')),
	--
	((SELECT ArtworkID
	  FROM Artworks a
	  WHERE a.Title = 'The Vitruvian Man'), 
	 (SELECT GenreID
	  FROM Genres g
	  WHERE g.Name = 'Renaissance')),
	--
	((SELECT ArtworkID
	  FROM Artworks a
	  WHERE a.Title = 'Ebru'), 
	 (SELECT GenreID
	  FROM Genres g
	  WHERE g.Name = 'Tesselation')),
	--
	((SELECT ArtworkID
	  FROM Artworks a
	  WHERE a.Title = 'Honey Is Sweeter Than Blood'), 
	 (SELECT GenreID
	  FROM Genres g
	  WHERE g.Name = 'Surrealism'))
GO