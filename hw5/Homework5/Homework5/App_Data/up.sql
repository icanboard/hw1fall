-- CUSTOMERS table
CREATE TABLE dbo.CUSTOMERS
(
	CID					INT IDENTITY (1,1) NOT NULL,
	ODL					NVARCHAR(7) NOT NULL,
	DOB					NVARCHAR(10) NOT NULL,
	FullName			NVARCHAR(64) NOT NULL,
	StreetAdd			NVARCHAR(64) NOT NULL,
	CityAdd				NVARCHAR(24) NOT NULL,
	StateAdd			NVARCHAR(3) NOT NULL,
	ZipAdd				NVARCHAR(5) NOT NULL,
	CountyAdd			NVARCHAR(2) NOT NULL,
	DateSigned			NVARCHAR(10) NOT NULL,
	CONSTRAINT[PK_dbo.CUSTOMERS] PRIMARY KEY CLUSTERED (CID ASC)
);

INSERT INTO dbo.CUSTOMERS (ODL, DOB, FullName, StreetAdd, CityAdd, StateAdd, ZipAdd, CountyAdd, DateSigned) VALUES
	('1234567', '12-31-1999', 'Jack Frost', '555 High St SE', 'Salem', 'OR', '97301', '24', '10-31-2014'),
	('9874215', '8-13-1957', 'Jon Skillz', '1656 Beavercreek Rd STE C', 'Oregon City', 'OR', '97045', '03', '4-18-2015'),
	('4652464', '1-1-2000', 'Sim Daz', '126 NW Minnesota Ave', 'Bend', 'OR', '97701', '09', '1-1-2012'),
	('3298742', '8-24-1984', 'Chris Columbus', '1660 Ashland St', 'Ashland', 'OR', '97520', '15', '3-27-2017'),
	('2189654', '11-9-1972', 'Oli Benders', '1111 Main St #A', 'Klamath Falls', 'OR', '97601', '18', '9-27-2008');
GO