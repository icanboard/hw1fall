-- CUSTOMERS table
CREATE TABLE dbo.CUSTOMERS
(
	CID					INT IDENTITY (1,1) NOT NULL,
	ODL					NVARCHAR(7) NOT NULL,
	DOB					DATE,
	FullName			NVARCHAR(64) NOT NULL,
	StreetAdd			NVARCHAR(64) NOT NULL,
	CityAdd				NVARCHAR(24) NOT NULL,
	StateAdd			NVARCHAR(3) NOT NULL,
	ZipAdd				NVARCHAR(5) NOT NULL,
	CountyAdd			NVARCHAR(2) NOT NULL,
	DateSigned			DATE,
	CONSTRAINT[PK_dbo.CUSTOMERS] PRIMARY KEY CLUSTERED (CID ASC)
);

INSERT INTO dbo.CUSTOMERS (ODL, DOB, FullName, StreetAdd, CityAdd, StateAdd, ZipAdd, CountyAdd, DateSigned) VALUES
	('1234567', '1999-12-31', 'Jack Frost', '555 High St SE', 'Salem', 'OR', '97301', '24', '2014-10-31'),
	('9874215', '1957-08-13', 'Jon Skillz', '1656 Beavercreek Rd STE C', 'Oregon City', 'OR', '97045', '03', '2015-04-18'),
	('4652464', '2000-01-01', 'Sim Daz', '126 NW Minnesota Ave', 'Bend', 'OR', '97701', '09', '2012-01-01'),
	('3298742', '1984-08-24', 'Chris Columbus', '1660 Ashland St', 'Ashland', 'OR', '97520', '15', '2017-03-27'),
	('2189654', '1972-11-09', 'Oli Benders', '1111 Main St #A', 'Klamath Falls', 'OR', '97601', '18', '2008-09-27');
GO