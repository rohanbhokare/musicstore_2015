CREATE DATABASE MusicStoreDb

use MusicStoreDb

CREATE TABLE Album (
		AlbumId int IDENTITY(101,1) PRIMARY KEY,
		Title varchar(200) NOT NULL,
		CategoryName varchar(100),
		ArtistName varchar(100),
		UintPrice int NOT NULL)

CREATE TABLE Cart(
		RecordId int IDENTITY(101,1) PRIMARY KEY,
		CartID varchar(50) Not NULL,
		AlbumId int Not NULL FOREIGN KEY REFERENCES Album(AlbumId),
		Quantity int,DateCreated datetime NOT NULL)

CREATE TABLE Orders(
		OrderId int IDENTITY(101,1) PRIMARY KEY,
		OrderDate datetime NOT NULL,
		FirstName varchar(150) NOT NULL,
		LastName varchar(150),
		Address varchar(100),
		City varchar(50),
		State varchar(50),
		PostalCode varchar(6) ,
		Country varchar(50),
		Phone varchar(15) NOT NULL,
		Email varchar(50),
		Total int NOT NULL)

CREATE TABLE OrderDetails(
		OrderDetailId int IDENTITY(101,1) PRIMARY KEY,
		OrderId int NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
		AlbumId int NOT NULL FOREIGN KEY REFERENCES Album(AlbumId),
		Quantity int,
		UnitPrice int) 		
