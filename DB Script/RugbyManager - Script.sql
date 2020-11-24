/*
REMEMBER TO CREATE THE DATABASE 'RugbyManager' BEFORE RUNNING THIS SCRIPT
*/

USE [RugbyManager]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 2020/11/24 18:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[Height] [decimal](5, 2) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[PrimaryPositionId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 2020/11/24 18:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Description] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stadium]    Script Date: 2020/11/24 18:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stadium](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Suburb] [varchar](50) NULL,
	[City] [varchar](100) NOT NULL,
	[Province] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Stadium] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 2020/11/24 18:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Suburb] [varchar](50) NULL,
	[City] [varchar](100) NOT NULL,
	[Province] [varchar](50) NOT NULL,
	[StadiumId] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Player] ON 
GO
INSERT [dbo].[Player] ([Id], [FirstName], [MiddleName], [LastName], [Height], [BirthDate], [PrimaryPositionId], [TeamId], [CreatedDate], [ModifiedDate]) VALUES (1, N'Koos', NULL, N'Kombius', CAST(10.80 AS Decimal(5, 2)), CAST(N'1994-11-22T00:00:00.000' AS DateTime), 10, 1, CAST(N'2020-11-22T16:34:37.677' AS DateTime), NULL)
GO
INSERT [dbo].[Player] ([Id], [FirstName], [MiddleName], [LastName], [Height], [BirthDate], [PrimaryPositionId], [TeamId], [CreatedDate], [ModifiedDate]) VALUES (2, N'Piet', NULL, N'Roomys', CAST(0.00 AS Decimal(5, 2)), CAST(N'1995-01-01T00:00:00.000' AS DateTime), 1, 1, CAST(N'2020-11-24T17:25:02.030' AS DateTime), CAST(N'2020-11-24T17:33:05.217' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (1, N'PROP_LOOSE', N'Loose-head Prop')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (2, N'HOOKER', N'Hooker')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (3, N'PROP_TIGHT', N'Tight-head Prop')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (4, N'LOCK_FOUR', N'Lock - 4')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (5, N'LOCK_FIVE', N'Lock - 5')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (6, N'FLANKER_BLIND', N'Blind-side Flanker')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (7, N'FLANKER_OPEN', N'Open-side Flanker')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (8, N'NUMBER_EIGHT', N'Number 8')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (9, N'SCRUM_HALF', N'Scrum Half')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (10, N'FLY_HALF', N'Fly Half')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (11, N'WING_LEFT', N'Left Wing')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (12, N'CENTER_INSIDE', N'Inside Center')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (13, N'CENTER_OUTSIDE', N'Outside Center')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (14, N'WING_RIGHT', N'Right Wing')
GO
INSERT [dbo].[Position] ([Id], [Code], [Description]) VALUES (15, N'FULLBACK', N'Fullback')
GO
SET IDENTITY_INSERT [dbo].[Stadium] ON 
GO
INSERT [dbo].[Stadium] ([Id], [Name], [Suburb], [City], [Province], [CreatedDate]) VALUES (1, N'Cape Town Stadium', N'Greenpoint', N'Cape Town', N'Western Cape', CAST(N'2020-11-20T19:56:22.843' AS DateTime))
GO
INSERT [dbo].[Stadium] ([Id], [Name], [Suburb], [City], [Province], [CreatedDate]) VALUES (2, N'Ellis Park', N'Doornfontein', N'Johannesburg', N'Gauteng', CAST(N'2020-11-20T19:56:22.843' AS DateTime))
GO
INSERT [dbo].[Stadium] ([Id], [Name], [Suburb], [City], [Province], [CreatedDate]) VALUES (3, N'Loftus Versfeld Stadium', NULL, N'Pretoria', N'Gauteng', CAST(N'2020-11-20T19:56:22.843' AS DateTime))
GO
INSERT [dbo].[Stadium] ([Id], [Name], [Suburb], [City], [Province], [CreatedDate]) VALUES (4, N'Newlands Stadium', N'Newlands', N'Cape Town', N'Western Cape', CAST(N'2020-11-24T18:19:11.913' AS DateTime))
GO
INSERT [dbo].[Stadium] ([Id], [Name], [Suburb], [City], [Province], [CreatedDate]) VALUES (5, N'Outeniqua Park', NULL, N'George', N'Western Cape', CAST(N'2020-11-24T18:24:44.503' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Stadium] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 
GO
INSERT [dbo].[Team] ([Id], [Name], [Suburb], [City], [Province], [StadiumId], [CreatedDate], [ModifiedDate]) VALUES (1, N'Team Koala', NULL, N'Cape Town', N'Western Cape', NULL, CAST(N'2020-11-22T14:23:46.110' AS DateTime), CAST(N'2020-11-24T18:03:05.143' AS DateTime))
GO
INSERT [dbo].[Team] ([Id], [Name], [Suburb], [City], [Province], [StadiumId], [CreatedDate], [ModifiedDate]) VALUES (2, N'Team Anti-Koala', NULL, N'Brakpan', N'North-West', 1, CAST(N'2020-11-24T17:49:18.543' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Position] FOREIGN KEY([PrimaryPositionId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Position]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Team]
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Stadium] FOREIGN KEY([StadiumId])
REFERENCES [dbo].[Stadium] ([Id])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Stadium]
GO
