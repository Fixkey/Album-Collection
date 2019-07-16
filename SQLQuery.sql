CREATE TABLE Genre
(
	IdGenre INT PRIMARY KEY IDENTITY,
	Name VARCHAR(255) NOT NULL
);
GO

INSERT INTO Genre(Name)
VALUES
('Rock'),
('Pop'),
('Jazz'),
('Classical'),
('Hip Hop'),
('Electronic')
GO

CREATE TABLE Artist
(
	IdArtist INT PRIMARY KEY IDENTITY,
	Name VARCHAR(255) NOT NULL,
	Website VARCHAR(255) NULL
);
GO

INSERT INTO Artist(Name, Website)
VALUES
('Welle Erdball', 'https://www.welle-erdball.info/'),
('Morten Haxholm', 'http://mortenhaxholm.com/'),
('Noisy Cell', 'https://noisycell.com/'),
('Dunderpatrullen', 'http://dunderpatrullen.nu/')
GO

INSERT INTO Artist(Name)
VALUES
('Wolfgang Amadeus Mozart'),
('Johann Sebastian Bach')
GO

CREATE TABLE Album
(
	IdAlbum INT PRIMARY KEY IDENTITY,
	Name VARCHAR(255) NOT NULL,
	ReleaseDate DATE NOT NULL,
	IdArtist INT REFERENCES Artist,
	IdGenre INT REFERENCES Genre
);
GO

INSERT INTO Album(Name, ReleaseDate, IdArtist, IdGenre)
VALUES
('Der Sens des Lebens', '1998/11/02', 1, 6),
('Vestigium', '2018/09/14', 2, 3),
('Wolves', '2018/07/25', 3, 1),
('Focus', '2019/03/06', 3, 1),
('Keygeneration', '2014/06/02', 4, 6)
GO