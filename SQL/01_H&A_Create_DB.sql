USE [master]

IF db_id('H&A') IS NULL
  CREATE DATABASE [H&A]
GO

USE [H&A]
GO

DROP TABLE IF EXISTS [ServiceCall];
DROP TABLE IF EXISTS [UserProfile];
GO

CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY,
  [FirebaseUserId] nvarchar(255) NOT NULL,
  [Username] nvarchar(255) NOT NULL,
  [FirstName] nvarchar(255) NOT NULL,
  [LastName] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [ServiceDate] datetime NOT NULL,
  [CreateDate] datetime NOT NULL
)
GO

CREATE TABLE [ServiceCall] (
  [Id] int PRIMARY KEY IDENTITY,
  [LocationName] nvarchar(255) NOT NULL,
  [LocationAddress] nvarchar(255),
  [DateScheduled] datetime NOT NULL,
  [DateService] datetime NOT NULL,
  [Notes] nvarchar(255),
  [UserProfileId] int NOT NULL
)
GO

ALTER TABLE [ServiceCall] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO
