

IF DB_ID('ManagingProducts') IS NULL
CREATE DATABASE ManagingProducts
GO

USE ManagingProducts

IF(NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME ='Users'))
CREATE TABLE Users(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Login VARCHAR(255) NOT NULL)

IF(NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME='Products'))
CREATE TABLE Products(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Price INT NOT NULL)

IF(NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME ='TypeOfOperations'))
CREATE TABLE TypeOfOperations(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Name VARCHAR(20) NOT NULL)

IF(NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME ='Operations'))
CREATE TABLE Operations(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Quantity INT NOT NULL,
DateOfOperation DATE NOT NULL,
UserId INT NOT NULL CONSTRAINT FK_Operations_Users_UserId FOREIGN KEY REFERENCES Users(Id),
ProductId INT NOT NULL CONSTRAINT FK_Operations_Products_ProductId FOREIGN KEY REFERENCES Products(Id),
TypeOfOperationId INT NOT NULL CONSTRAINT FK_Operations_TypeOfOperations_TypeOfOperationId FOREIGN KEY REFERENCES TypeOfOperations(Id))





