USE ArtWorks;
GO

--table with most foreign constraints
DROP TABLE dbo.Classifications;
GO

DROP TABLE dbo.Artworks;
GO

DROP TABLE dbo.Artists;
GO

DROP TABLE dbo.Genres;
GO

--switch to master so we can delete the database
--if we don't, compiler will tell us that the database is in use
--(because we're connected to it)
USE master;
GO

DROP DATABASE ArtWorks;
GO