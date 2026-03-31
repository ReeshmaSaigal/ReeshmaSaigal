USE [master]
GO
/****** Object:  Database [DB_HireMeNow_WebApi]    Script Date: 20-10-2023 04:19:31 ******/
CREATE DATABASE [DB_HireMeNow_WebApi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_HireMeNow_WebApi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_HireMeNow_WebApi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_HireMeNow_WebApi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_HireMeNow_WebApi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_HireMeNow_WebApi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET  MULTI_USER 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_HireMeNow_WebApi', N'ON'
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_HireMeNow_WebApi]
GO
/****** Object:  Table [dbo].[AuthUser]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthUser](
	[Id] [uniqueidentifier] NOT NULL,
	[SystemUserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AuthUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyUser]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyUser](
	[Id] [uniqueidentifier] NOT NULL,
	[Company] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CompanyUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Industry]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Industry](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Industry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobCategory]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPost]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPost](
	[Id] [uniqueidentifier] NOT NULL,
	[JobTitle] [nchar](10) NOT NULL,
	[JobSummary] [nvarchar](50) NOT NULL,
	[JobLocation] [uniqueidentifier] NOT NULL,
	[Company] [uniqueidentifier] NOT NULL,
	[Category] [uniqueidentifier] NOT NULL,
	[Industry] [uniqueidentifier] NOT NULL,
	[PostedBy] [uniqueidentifier] NOT NULL,
	[PostedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_JobPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobProviderCompany]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobProviderCompany](
	[Id] [uniqueidentifier] NOT NULL,
	[LegalName] [varchar](50) NOT NULL,
	[Summary] [varchar](50) NOT NULL,
	[Industry] [uniqueidentifier] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [bigint] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Website] [varchar](50) NOT NULL,
	[Location] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_JobProviderCompany] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobResponsibility]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobResponsibility](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
	[JobPost] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_JobResponsibility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobSeeker]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSeeker](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_JobSeeker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobSeekerProfile]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSeekerProfile](
	[Id] [uniqueidentifier] NOT NULL,
	[ResumeId] [uniqueidentifier] NOT NULL,
	[ProfileName] [nvarchar](max) NULL,
	[ProfileSummary] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobSeekerProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Discription] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualification]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualification](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[JobseekerProfileId] [uniqueidentifier] NULL,
	[JobPostId] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resume]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resume](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[File] [varbinary](max) NULL,
 CONSTRAINT [PK_Resume] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [uniqueidentifier] NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[JobSeekerProfileId] [uniqueidentifier] NOT NULL,
	[JobPost] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUser]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUser](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_SystemUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkExperience]    Script Date: 20-10-2023 04:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkExperience](
	[Id] [uniqueidentifier] NOT NULL,
	[JobSeekerProfileId] [uniqueidentifier] NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[ServiceStart] [datetime2](7) NOT NULL,
	[ServiceEnd] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuthUser]  WITH CHECK ADD  CONSTRAINT [FK_AuthUser_SystemUser_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[SystemUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AuthUser] CHECK CONSTRAINT [FK_AuthUser_SystemUser_Id]
GO
ALTER TABLE [dbo].[AuthUser]  WITH CHECK ADD  CONSTRAINT [FK_AuthUser_SystemUser_SystemUserId] FOREIGN KEY([SystemUserId])
REFERENCES [dbo].[SystemUser] ([Id])
GO
ALTER TABLE [dbo].[AuthUser] CHECK CONSTRAINT [FK_AuthUser_SystemUser_SystemUserId]
GO
ALTER TABLE [dbo].[CompanyUser]  WITH CHECK ADD  CONSTRAINT [FK_CompanyUser_JobProviderCompany] FOREIGN KEY([Company])
REFERENCES [dbo].[JobProviderCompany] ([Id])
GO
ALTER TABLE [dbo].[CompanyUser] CHECK CONSTRAINT [FK_CompanyUser_JobProviderCompany]
GO
ALTER TABLE [dbo].[JobPost]  WITH CHECK ADD  CONSTRAINT [FK_JobPost_Industry] FOREIGN KEY([PostedBy])
REFERENCES [dbo].[CompanyUser] ([Id])
GO
ALTER TABLE [dbo].[JobPost] CHECK CONSTRAINT [FK_JobPost_Industry]
GO
ALTER TABLE [dbo].[JobPost]  WITH CHECK ADD  CONSTRAINT [FK_JobPost_Location] FOREIGN KEY([JobLocation])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[JobPost] CHECK CONSTRAINT [FK_JobPost_Location]
GO
ALTER TABLE [dbo].[JobProviderCompany]  WITH CHECK ADD  CONSTRAINT [FK_JobProviderCompany_Location] FOREIGN KEY([Location])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[JobProviderCompany] CHECK CONSTRAINT [FK_JobProviderCompany_Location]
GO
ALTER TABLE [dbo].[JobResponsibility]  WITH CHECK ADD  CONSTRAINT [FK_JobResponsibility_JobPost] FOREIGN KEY([JobPost])
REFERENCES [dbo].[JobPost] ([Id])
GO
ALTER TABLE [dbo].[JobResponsibility] CHECK CONSTRAINT [FK_JobResponsibility_JobPost]
GO
ALTER TABLE [dbo].[JobSeeker]  WITH CHECK ADD  CONSTRAINT [FK_JobSeeker_SystemUser_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[SystemUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobSeeker] CHECK CONSTRAINT [FK_JobSeeker_SystemUser_Id]
GO
ALTER TABLE [dbo].[JobSeekerProfile]  WITH CHECK ADD  CONSTRAINT [FK_JobSeekerProfile_Resume_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resume] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobSeekerProfile] CHECK CONSTRAINT [FK_JobSeekerProfile_Resume_ResumeId]
GO
ALTER TABLE [dbo].[Qualification]  WITH CHECK ADD  CONSTRAINT [FK_Qualification_JobSeekerProfile] FOREIGN KEY([JobPostId])
REFERENCES [dbo].[JobPost] ([Id])
GO
ALTER TABLE [dbo].[Qualification] CHECK CONSTRAINT [FK_Qualification_JobSeekerProfile]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [FK_Skill_JobSeekerProfile1] FOREIGN KEY([JobPost])
REFERENCES [dbo].[JobPost] ([Id])
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [FK_Skill_JobSeekerProfile1]
GO
ALTER TABLE [dbo].[WorkExperience]  WITH CHECK ADD  CONSTRAINT [FK_WorkExperience_JobSeekerProfile] FOREIGN KEY([JobSeekerProfileId])
REFERENCES [dbo].[JobSeekerProfile] ([Id])
GO
ALTER TABLE [dbo].[WorkExperience] CHECK CONSTRAINT [FK_WorkExperience_JobSeekerProfile]
GO
USE [master]
GO
ALTER DATABASE [DB_HireMeNow_WebApi] SET  READ_WRITE 
GO
