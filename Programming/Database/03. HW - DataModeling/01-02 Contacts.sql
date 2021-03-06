USE [master]
GO
/****** Object:  Database [Contacts]    Script Date: 12.7.2013 г. 16:17:48 ******/
CREATE DATABASE [Contacts]
GO
ALTER DATABASE [Contacts] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Contacts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Contacts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Contacts] SET ARITHABORT OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Contacts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Contacts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Contacts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Contacts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Contacts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Contacts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Contacts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Contacts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Contacts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Contacts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Contacts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Contacts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Contacts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Contacts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Contacts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Contacts] SET RECOVERY FULL 
GO
ALTER DATABASE [Contacts] SET  MULTI_USER 
GO
ALTER DATABASE [Contacts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Contacts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Contacts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Contacts] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Contacts', N'ON'
GO
USE [Contacts]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12.7.2013 г. 16:17:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address_Text] [nvarchar](150) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 12.7.2013 г. 16:17:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 12.7.2013 г. 16:17:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 12.7.2013 г. 16:17:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FisrtName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 12.7.2013 г. 16:17:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [Address_Text], [TownId]) VALUES (1, N'R. Maria Paula', 5)
INSERT [dbo].[Addresses] ([Id], [Address_Text], [TownId]) VALUES (2, N'Пиротска', 2)
INSERT [dbo].[Addresses] ([Id], [Address_Text], [TownId]) VALUES (3, N'Васил Левски', 2)
INSERT [dbo].[Addresses] ([Id], [Address_Text], [TownId]) VALUES (4, N'Цариградско шосе', 2)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([Id], [Name]) VALUES (1, N'Africa')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (2, N'Europe')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (3, N'Asia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (4, N'Australia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (5, N'South_America')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (1, N'Bulgaria', 2)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (2, N'France', 2)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (3, N'China', 3)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (4, N'Brazil', 5)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FisrtName], [LastName], [AddressId]) VALUES (1, N'Pesho', N'Ivanov', 2)
INSERT [dbo].[Persons] ([Id], [FisrtName], [LastName], [AddressId]) VALUES (2, N'Гошо', N'Иванов', 3)
INSERT [dbo].[Persons] ([Id], [FisrtName], [LastName], [AddressId]) VALUES (3, N'Сашо', N'Маринов', 4)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (1, N'Paris', 2)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (2, N'Sofia', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (3, N'Plovdiv', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (4, N'Rio de Janeiro', 4)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (5, N'São Paulo', 4)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents1] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([Id])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents1]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [Contacts] SET  READ_WRITE 
GO
