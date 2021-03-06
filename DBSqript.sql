USE [master]
GO
/****** Object:  Database [TestTaskDB]    Script Date: 04.01.2022 16:01:25 ******/
CREATE DATABASE [TestTaskDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestTaskDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TestTaskDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestTaskDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TestTaskDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TestTaskDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestTaskDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestTaskDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestTaskDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestTaskDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestTaskDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestTaskDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestTaskDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestTaskDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestTaskDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestTaskDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestTaskDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestTaskDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestTaskDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestTaskDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestTaskDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TestTaskDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestTaskDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestTaskDB] SET  MULTI_USER 
GO
ALTER DATABASE [TestTaskDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestTaskDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestTaskDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestTaskDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestTaskDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestTaskDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TestTaskDB] SET QUERY_STORE = OFF
GO
USE [TestTaskDB]
GO
/****** Object:  Table [dbo].[People]    Script Date: 04.01.2022 16:01:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Sex] [nvarchar](max) NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'acmwojeiwqe9', N'Anna Titova', N'female', 19)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'ajkvdnLdj22po11', N'Pishkun Vladislav', N'male', 27)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'cnoqjpIdjkqpo11', N'Sascha Braemer', N'male', 11)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'djkqpo11cnoqjpI', N'Jessica Braemer', N'female', 31)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'guyqwhoij6', N'Dmitry Vegas', N'male', 78)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'hqwuiehquikxhc5', N'German Titov', N'male', 42)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'kjlqwoijeo7', N'Solomon Shlemovich', N'male', 41)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'lkkpokqw8', N'Alex Whitedrinker', N'female', 45)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'lkqjweiojqiow4', N'Erzhena Koroleva', N'female', 31)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'qjIdwojqiowj10', N'Elmo Kennedy', N'male', 63)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'qmvqqwrqsds2', N'Jack Anderson', N'male', 14)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'qyfgqiyhwfoq1', N'Stan Smith', N'male', 30)
INSERT [dbo].[People] ([Id], [Name], [Sex], [Age]) VALUES (N'vdhgqvgj3', N'Olga Popova', N'female', 24)
GO
USE [master]
GO
ALTER DATABASE [TestTaskDB] SET  READ_WRITE 
GO
