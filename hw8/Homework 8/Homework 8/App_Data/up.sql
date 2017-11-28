CREATE TABLE dbo.ARTISTS
(
	AID				INT IDENTITY(1,1) NOT NULL,
	ArtistName		NVARCHAR(50) NOT NULL,
	BirthDate		NVARCHAR(50) NOT NULL,
	BirthCity		NVARCHAR(50) NOT NULL,
	CONSTRAINT[PK_dbo.ARTISTS] PRIMARY KEY CLUSTERED (AID ASC)
);

CREATE TABLE dbo.GENRES
(
	Genre			VARCHAR(24) NOT NULL,
	CONSTRAINT[PK_dbo.GENRES] PRIMARY KEY CLUSTERED (Genre ASC)
);

CREATE TABLE dbo.ARTWORKS (
	AWID			INT IDENTITY(1,1) NOT NULL,
	Title			VARCHAR(50) NOT NULL,
	AID				INT NOT NULL,
	CONSTRAINT[PK_dbo.ARTWORKS] PRIMARY KEY CLUSTERED (AWID ASC),
	CONSTRAINT[FK_dbo.ARTWORKS_ARTISTS] FOREIGN KEY (AID)
		REFERENCES dbo.ARTISTS (AID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE dbo.CLASSIFICATIONS (
	CID				INT IDENTITY(1,1) NOT NULL,
	AWID			INT NOT NULL,
	Genre			VARCHAR(24) NOT NULL,
	CONSTRAINT[PK_dbo.CLASSIFICATIONS] PRIMARY KEY CLUSTERED (CID ASC),
	CONSTRAINT[FK_dbo.ARTWORKS_CLASSIFICATIONS] FOREIGN KEY (AWID)
		REFERENCES dbo.ARTWORKS (AWID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK_dbo.GENRES_CLASSIFICATIONS] FOREIGN KEY (Genre)
		REFERENCES dbo.GENRES (Genre)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO dbo.ARTISTS (ArtistName, BirthDate, BirthCity) VALUES
('M.C. Escher', 'June 17, 1989', 'Leeuwarden, Netherlands'),
('Leonardo Da Vinci', 'May 2, 1519', 'Vinci, Italy'),
('Hatip Mehmed Efendi', 'November 18, 1680', 'Unknown'),
('Salvador Dali', 'May 11, 1904', 'Figueres, Spain')
;

INSERT INTO dbo.GENRES (Genre) VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance')
;

INSERT INTO dbo.ARTWORKS (Title, AID) VALUES
('Circle Limit III', '1'),
('Twon Tree', '1'),
('Mona Lisa', '2'),
('The Vitruvian Man', '2'),
('Ebru', '3'),
('Honey Is Sweeter Than Blood', '4')
;


INSERT INTO dbo.CLASSIFICATIONS (AWID, Genre) VALUES
('1', 'Tesselation'),
('2', 'Tesselation'),
('2', 'Surrealism'),
('3', 'Portrait'),
('3', 'Renaissance'),
('4', 'Renaissance'),
('5', 'Tesselation'),
('6', 'Surrealism')
;

GO