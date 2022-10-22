USE [GravyTrain]
GO

SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] (
	[Id], [FirebaseUserId], [Username], [FirstName], [LastName], [Email], [CreateDate])
VALUES (1, 'umxJ5PnWoiZBFTrNolYC97m749p1', 'HSmith', 'Houston', 'Smith', 'H@Smith.com', SYSDATETIME()),
(2, 'ffhCN0kr3GUv2fWcBdoocbvpj8B2', 'CCarter', 'Chapel', 'Carter', 'C@Carter.com', SYSDATETIME()),
(3, 'Tq6VSx2DrXZYz6AaapiJWiTdu4f2', 'WMoody', 'Walter', 'Moody', 'W@Moddy.com', SYSDATETIME());
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Review] ON
INSERT INTO [Review] ([Id], [LocationName], [LocationAddress], [DateReviewed], [ButteryScore], [FlakeyScore], [GravyScore], [FlavorScore], [DeliveryScore], [AverageScore], [Notes], [GravyType], [UserProfileId])
VALUES (1, 'Nashville Biscuit House', 'Filler', SYSDATETIME(), 8, 6, 7, 7, 8, 7, 'No Notes', 'White', 1),
(2, 'Nashville Biscuit House', 'Filler', SYSDATETIME(), 9, 6, 8, 9, 8, 8, 'No Notes', 'White', 2);
SET IDENTITY_INSERT [Review] OFF





