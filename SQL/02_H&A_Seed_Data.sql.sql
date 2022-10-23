USE [H&A]
GO

SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] (
	[Id], [FirebaseUserId], [Username], [FirstName], [LastName], [Email], [ServiceDate], [CreateDate])
VALUES (1, 'yM5InvGlC0ehCByb42aZKrBSUIC3', 'Hsmith', 'Houston', 'Smith', 'houstonbsmith@gmail.com', SYSDATETIME(), SYSDATETIME()),
(2, 'QXjgESoFYog88byQHKrDwLYJXyh2', 'CCarter', 'Chapel', 'Carter', 'chapelcarter@gmail.com', SYSDATETIME(), SYSDATETIME());
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [ServiceCall] ON
INSERT INTO [ServiceCall] ([Id], [LocationName], [LocationAddress], [DateScheduled], [DateService], [Notes], [UserProfileId])
VALUES (1, 'Filler 1', 'Filler 1', SYSDATETIME(), SYSDATETIME(), 'No Notes', 1),
(2, 'Filler 2', 'Filler 2', SYSDATETIME(), SYSDATETIME(), 'No Notes', 2);
SET IDENTITY_INSERT [ServiceCall] OFF





