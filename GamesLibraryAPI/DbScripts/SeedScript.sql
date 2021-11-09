USE [GamesLibrary_IEDb]
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName]) VALUES (4, N'CD PROJEKT RED')
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName]) VALUES (5, N'Ubisoft')
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName]) VALUES (6, N'Rockstar Games')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Pegies] ON 
GO
INSERT [dbo].[Pegies] ([PegiId], [PegiValue]) VALUES (4, N'18')
GO
SET IDENTITY_INSERT [dbo].[Pegies] OFF
GO
SET IDENTITY_INSERT [dbo].[Games] ON 
GO
INSERT [dbo].[Games] ([GameId], [Title], [Description], [Price], [Premiere], [PegiId], [CompanyId]) VALUES (1, N'Witcher 3: Wild Hunt', N'The best game from CD PROJEKT GAME. History of legendary witcher - Geralt of Rivia', CAST(125.00 AS Decimal(18, 2)), CAST(N'2015-05-18T00:00:00.0000000' AS DateTime2), 4, 4)
GO
INSERT [dbo].[Games] ([GameId], [Title], [Description], [Price], [Premiere], [PegiId], [CompanyId]) VALUES (2, N'Assassin''s Creed Valhalla', N'The newest game from assassin''s franichse from Ubisoft studio. Now we are vikings', CAST(259.00 AS Decimal(18, 2)), CAST(N'2020-11-10T00:00:00.0000000' AS DateTime2), 4, 5)
GO
INSERT [dbo].[Games] ([GameId], [Title], [Description], [Price], [Premiere], [PegiId], [CompanyId]) VALUES (3, N'Red Dead Redemption 2', N'Insane Wild West style game. Amazing adventure, Precious gameplay. Everythin is top of the top', CAST(315.00 AS Decimal(18, 2)), CAST(N'2018-10-25T00:00:00.0000000' AS DateTime2), 4, 6)
GO
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [UserName], [Email], [HashedPassword], [Description], [DateOfBirth], [RoleId]) VALUES (9, N'Test', N'Testowy', N'test1', N'test@gmail.com', N'AQAAAAEAACcQAAAAEEWx0Uhdmoql45PApXhm8ALjOY02mkqHctaQpMfsKNKyEI58c5eV28yZZf4mLRi4Gw==', NULL, CAST(N'2017-11-01T00:00:00.0000000' AS DateTime2), 2)
GO
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [UserName], [Email], [HashedPassword], [Description], [DateOfBirth], [RoleId]) VALUES (10, N'Test', N'Testowy', N'test2', N'test2@gmail.com', N'AQAAAAEAACcQAAAAEJY27eVp4WzPpVBMPMW49XOgKJCaZK4jpqvLnMQXAzJV44uVBHsvhpONwOfkH23lKg==', NULL, CAST(N'2017-11-01T00:00:00.0000000' AS DateTime2), 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 
GO
INSERT [dbo].[Genres] ([GenreId], [GenreName]) VALUES (10, N'RPG')
GO
INSERT [dbo].[Genres] ([GenreId], [GenreName]) VALUES (11, N'Fantasy')
GO
INSERT [dbo].[Genres] ([GenreId], [GenreName]) VALUES (12, N'Action')
GO
INSERT [dbo].[Genres] ([GenreId], [GenreName]) VALUES (15, N'Adventure')
GO
INSERT [dbo].[Genres] ([GenreId], [GenreName]) VALUES (17, N'Western')
GO
INSERT [dbo].[Genres] ([GenreId], [GenreName]) VALUES (18, N'Shooter')
GO
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (1, 10)
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (2, 10)
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (1, 11)
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (1, 12)
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (2, 12)
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (2, 15)
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (3, 15)
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (3, 17)
GO
INSERT [dbo].[GameGenre] ([GamesGameId], [GenresGenreId]) VALUES (3, 18)
GO