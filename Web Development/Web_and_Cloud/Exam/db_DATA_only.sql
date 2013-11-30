USE [BloggingSystemDb]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Displayname], [AuthCode], [SessionKey]) VALUES (1, N'donchominkov', N'Doncho Minkov', N'bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e', N'1UXQmxzgjqtKFKPPNKaKgSUytCcLDUWfErNIPOQCBBWeykqVsv')
INSERT [dbo].[Users] ([Id], [Username], [Displayname], [AuthCode], [SessionKey]) VALUES (4, N'IvanIvanov', N'Ivan Ivanov', N'bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e', NULL)
INSERT [dbo].[Users] ([Id], [Username], [Displayname], [AuthCode], [SessionKey]) VALUES (5, N'MishoMishov', N'Misho Mishov', N'bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e', NULL)
INSERT [dbo].[Users] ([Id], [Username], [Displayname], [AuthCode], [SessionKey]) VALUES (6, N'StamoStamov', N'Stamo Stamov', N'bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e', NULL)
INSERT [dbo].[Users] ([Id], [Username], [Displayname], [AuthCode], [SessionKey]) VALUES (7, N'WebAPIch', N'WebAPIch', N'bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e', NULL)
INSERT [dbo].[Users] ([Id], [Username], [Displayname], [AuthCode], [SessionKey]) VALUES (8, N'tedkotheserver', N'Tedko the Server', N'bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e', NULL)
INSERT [dbo].[Users] ([Id], [Username], [Displayname], [AuthCode], [SessionKey]) VALUES (9, N'TheRESTfuldimi', N'The RESTful Dimi', N'bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostDate], [User_Id]) VALUES (1, N'I want more homework', N'I think that the homework that the trainers are giving us is too little for our capabilities', CAST(0x0000A21D00A95858 AS DateTime), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostDate], [User_Id]) VALUES (2, N'We need harder exams!', N'The trainers need to think about harder exams, these are too easy', CAST(0x0000A21C00B9D318 AS DateTime), 5)
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostDate], [User_Id]) VALUES (3, N'WebAPI is so much cool!', N'WebAPI made me feel like never before! This is a very cool platform', CAST(0x0000A21D00B9D318 AS DateTime), 7)
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostDate], [User_Id]) VALUES (4, N'NEW POST', N'this is just a test post', CAST(0x0000A21F00EE00BE AS DateTime), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostDate], [User_Id]) VALUES (5, N'NEW POST', N'this is just a test post', CAST(0x0000A21F00F36EC5 AS DateTime), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Text], [PostDate], [User_Id]) VALUES (6, N'NEW POST', N'this is just a test post', CAST(0x0000A21F010799BF AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [Text], [PostDate], [User_Id], [Post_Id]) VALUES (1, N'I fully agree with you!', CAST(0x0000A21D00B9D318 AS DateTime), 8, 1)
INSERT [dbo].[Comments] ([Id], [Text], [PostDate], [User_Id], [Post_Id]) VALUES (2, N'More! More! More! MOREEEEEE!",', CAST(0x0000A21D00B9D318 AS DateTime), 6, 1)
INSERT [dbo].[Comments] ([Id], [Text], [PostDate], [User_Id], [Post_Id]) VALUES (3, N'Rock on!', CAST(0x0000A21D00B9D318 AS DateTime), 8, 2)
INSERT [dbo].[Comments] ([Id], [Text], [PostDate], [User_Id], [Post_Id]) VALUES (4, N'I fully agree with you!', CAST(0x0000A21D00B9D318 AS DateTime), 8, 3)
INSERT [dbo].[Comments] ([Id], [Text], [PostDate], [User_Id], [Post_Id]) VALUES (5, N'Yeah! I  don''t need a girlfriend anymore!",', CAST(0x0000A21D00B9D318 AS DateTime), 9, 3)
INSERT [dbo].[Comments] ([Id], [Text], [PostDate], [User_Id], [Post_Id]) VALUES (6, N'Abe kefi me toq post', CAST(0x0000A21F01091BB4 AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (1, N'webapi', 3)
INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (2, N'is', 3)
INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (3, N'so', 3)
INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (4, N'much', 3)
INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (5, N'cool', 3)
INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (6, N'new', 5)
INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (7, N'post', 5)
INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (8, N'new', 6)
INSERT [dbo].[Tags] ([Id], [Content], [Post_Id]) VALUES (9, N'post', 6)
SET IDENTITY_INSERT [dbo].[Tags] OFF
