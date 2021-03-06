USE [master]
GO
/****** Object:  Database [TOEICEssentialWords]    Script Date: 1/18/2017 2:32:57 PM ******/
CREATE DATABASE [TOEICEssentialWords]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TOEICEssentialWords', FILENAME = N'C:\Users\alvin.nguyen\TOEICEssentialWords.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TOEICEssentialWords_log', FILENAME = N'C:\Users\alvin.nguyen\TOEICEssentialWords_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TOEICEssentialWords] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TOEICEssentialWords].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TOEICEssentialWords] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET ARITHABORT OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TOEICEssentialWords] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TOEICEssentialWords] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TOEICEssentialWords] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TOEICEssentialWords] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TOEICEssentialWords] SET  MULTI_USER 
GO
ALTER DATABASE [TOEICEssentialWords] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TOEICEssentialWords] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TOEICEssentialWords] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TOEICEssentialWords] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TOEICEssentialWords] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TOEICEssentialWords]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 1/18/2017 2:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[LessonNumber] [int] NULL,
	[TopicId] [int] NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/18/2017 2:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topic]    Script Date: 1/18/2017 2:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Index] [int] NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 1/18/2017 2:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Salt] [nvarchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 1/18/2017 2:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserWordList]    Script Date: 1/18/2017 2:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserWordList](
	[UserId] [int] NOT NULL,
	[WordId] [int] NOT NULL,
 CONSTRAINT [PK_UserWordList] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[WordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word]    Script Date: 1/18/2017 2:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[WordType] [int] NULL,
	[Mean] [nvarchar](250) NULL,
	[BrEPronoun] [nvarchar](50) NULL,
	[NAmEPronoun] [nvarchar](50) NULL,
	[Examples] [nvarchar](max) NULL,
	[LessonId] [int] NULL,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (1, N'Contracts', 1, 1)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (2, N'Marketing', 2, 1)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (3, N'Warranties', 3, 1)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (4, N'Bussiness Planing', 4, 1)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (5, N'Conferrences', 5, 1)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (6, N'Computers', 6, 2)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (7, N'Office Technology', 7, 2)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (8, N'Office Proceedures', 8, 2)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (9, N'Electronics', 9, 2)
INSERT [dbo].[Lesson] ([Id], [Name], [LessonNumber], [TopicId]) VALUES (10, N'Correspondence', 10, 2)
SET IDENTITY_INSERT [dbo].[Lesson] OFF
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([Id], [Name], [Index]) VALUES (1, N'General Business', 1)
INSERT [dbo].[Topic] ([Id], [Name], [Index]) VALUES (2, N'Office Issues', 2)
INSERT [dbo].[Topic] ([Id], [Name], [Index]) VALUES (3, N'Personal', 3)
INSERT [dbo].[Topic] ([Id], [Name], [Index]) VALUES (4, N'Purchasing', 4)
INSERT [dbo].[Topic] ([Id], [Name], [Index]) VALUES (5, N'Financing and Budgeting', 5)
SET IDENTITY_INSERT [dbo].[Topic] OFF
SET IDENTITY_INSERT [dbo].[Word] ON 

INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (1, N'abide by', 1, N'to comply with; to conform', NULL, NULL, NULL, 1)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (2, N'agreement', 0, N'a mutual arrangement, a contract', NULL, NULL, NULL, 1)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (3, N'assurance', 0, N'a guarantee; confidence', NULL, NULL, NULL, 1)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (4, N'cancellation', 0, N'annulment; stopping', NULL, NULL, NULL, 1)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (5, N'determine', 1, N'to find out; to influence', NULL, NULL, NULL, 1)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (6, N'attract', 1, N'to draw by appeal', NULL, NULL, NULL, 2)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (7, N'compare', 1, N'to examine similarites and differences', NULL, NULL, NULL, 2)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (8, N'competition', 0, N'a contest or struggle', NULL, NULL, NULL, 2)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (9, N'currently', 3, N'happening at the present time; now', NULL, NULL, NULL, 2)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (10, N'productive', 2, N'constructive; high yield', NULL, NULL, NULL, 2)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (11, N'access', 0, N'the ability or right to enter or use', NULL, NULL, NULL, 6)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (12, N'allocate', 1, N'to designate for a specific purpose', N' NULL', NULL, NULL, 6)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (13, N'compatible', 2, N'able to function together', NULL, NULL, NULL, 6)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (14, N'delete', 1, N'to remove; to erase', NULL, NULL, NULL, 6)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (15, N'failure', 0, N'an unsuccessful word or effort', NULL, NULL, NULL, 6)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (16, N'affordable', 2, N'able to be paid for; not too expensive', NULL, NULL, NULL, 7)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (17, N'as needed', 3, N'as necessary', NULL, NULL, NULL, 7)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (18, N'durable', 2, N'sturdy, strong. lasting', NULL, NULL, NULL, 7)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (19, N'network', 0, N'an interconnected group or system over a radio or TV; to engafe in informal communication', NULL, NULL, NULL, 9)
INSERT [dbo].[Word] ([Id], [Name], [WordType], [Mean], [BrEPronoun], [NAmEPronoun], [Examples], [LessonId]) VALUES (20, N'facilitate', 1, N'to make easier', NULL, NULL, NULL, 9)
SET IDENTITY_INSERT [dbo].[Word] OFF
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Topic] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topic] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Topic]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
ALTER TABLE [dbo].[UserWordList]  WITH CHECK ADD  CONSTRAINT [FK_UserWordList_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserWordList] CHECK CONSTRAINT [FK_UserWordList_User]
GO
ALTER TABLE [dbo].[UserWordList]  WITH CHECK ADD  CONSTRAINT [FK_UserWordList_Word] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([Id])
GO
ALTER TABLE [dbo].[UserWordList] CHECK CONSTRAINT [FK_UserWordList_Word]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Lesson] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lesson] ([Id])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Lesson]
GO
USE [master]
GO
ALTER DATABASE [TOEICEssentialWords] SET  READ_WRITE 
GO
