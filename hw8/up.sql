CREATE TABLE dbo.ARTISTS
(
	AID				INT IDENTITY(1,1) NOT NULL,
	Name			NVARCHAR(50) NOT NULL,
	BirthDate		NVARCHAR(50) NOT NULL,
	BirthCity		NVARCHAR(50) NOT NULL,
	CONSTRAINT[PK_dbo.ARTISTS] PRIMARY KEY CLUSTERED (AID ASC)
);

INSERT INTO dbo.ARTISTS (Name, BirthDate, BirthCity) VALUES
('M.C. Escher', 'June 17, 1989', 'Leeuwarden, Netherlands'),
('Leonardo Da Vinci', 'May 2, 1519', 'Vinci, Italy'),
('Hatip Mehmed Efendi', 'November 18, 1680', 'Unknown'),
('Salvador Dali', 'May 11, 1904', 'Figueres, Spain')
;

CREATE TABLE dbo.GENRES
(
	GID				INT IDENTITY(1,1) NOT NULL,
	Genre			VARCHAR(24) NOT NULL,
	CONSTRAINT[PK_dbo.GENRES] PRIMARY KEY CLUSTERED (GID ASC)
);

INSERT INTO dbo.GENRES (Genre) VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance')
;

CREATE TABLE dbo.ARTWORKS (
	AWID			INT IDENTITY(1,1) NOT NULL,
	Title			VARCHAR(50) NOT NULL,
	Artist			VARCHAR(50) NOT NULL,
	CONSTRAINT[PK.dbo_ARTWORKS] PRIMARY KEY CLUSTERED (AWID ASC)
);

INSERT INTO dbo.ARTWORKS (Title, Artist) VALUES
('Circle Limit III', 'M.C. Escher'),
('Twon Tree', 'M.C. Escher'),
('Mona Lisa', 'Leonardo Da Vinci'),
('The Vitruvian Man', 'Leonardo Da Vinci'),
('Ebru', 'Hatip Mehmed Efendi'),
('Honey Is Sweeter Than Blood', 'Salvador Dali')
;

CREATE TABLE dbo.CLASSIFICATIONS (
	CID				INT IDENTITY(1,1) NOT NULL,
	ArtWork			VARCHAR(50) NOT NULL,
	Genre			VARCHAR(50) NOT NULL,
	CONSTRAINT[PK.dbo_CLASSIFICATIONS] PRIMARY KEY CLUSTERED (CID ASC)
);

INSERT INTO dbo.CLASSIFICATIONS (Artwork, Genre) VALUES
('Circle Limit III', 'Tesselation'),
('Twon Tree', 'Tesselation'),
('Twon Tree', 'Surrealism'),
('Mona Lisa', 'Portrait'),
('Mona Lisa', 'Renaissance'),
('The Vitruvian Man', 'Renaissance'),
('Ebru', 'Tesselation'),
('Honey Is Sweeter Than Blood', 'Surrealism')
;

GO