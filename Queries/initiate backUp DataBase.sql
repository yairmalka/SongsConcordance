USE [TextAppBackUp]
GO

/****** Object:  Table [dbo].[Songs]    Script Date: 14/12/2022 18:01:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Songs](
	[SongID] [int] IDENTITY(1,1) NOT NULL,
	[Artist] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Year] [int] NULL,
	[Album] [nvarchar](250) NULL,
	[Genre] [nvarchar](150) NULL,
	[FilePath] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Songs_1] PRIMARY KEY CLUSTERED 
(
	[SongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [TextAppBackUp]
GO

/****** Object:  Table [dbo].[Words]    Script Date: 16/12/2022 02:07:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[SongID] [int] NOT NULL,
	[WordValue] [nvarchar](100) NULL,
	[WordLength] [int] NULL,
	[WordCount] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Songs] FOREIGN KEY([SongID])
REFERENCES [dbo].[Songs] ([SongID])
GO

ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Songs]
GO


USE [TextAppBackUp]
GO

/****** Object:  Table [dbo].[Positions]    Script Date: 16/12/2022 02:07:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Positions](
	[PositionID] [int] IDENTITY(1,1) NOT NULL,
	[WordValue] [nvarchar](100) NULL,
	[SongID] [int] NOT NULL,
	[WordIndex] [int] NULL,
	[SentenceNumber] [int] NULL,
	[VerseNumber] [int] NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Positions]  WITH CHECK ADD  CONSTRAINT [FK_Positions_Songs1] FOREIGN KEY([SongID])
REFERENCES [dbo].[Songs] ([SongID])
GO

ALTER TABLE [dbo].[Positions] CHECK CONSTRAINT [FK_Positions_Songs1]
GO


USE [TextAppBackUp]
GO

/****** Object:  Table [dbo].[Groups]    Script Date: 16/12/2022 02:07:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](150) NOT NULL,
	[GroupIndex] [int] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [TextAppBackUp]
GO

/****** Object:  Table [dbo].[LinguisticExpressions]    Script Date: 16/12/2022 02:08:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LinguisticExpressions](
	[ExpressionID] [int] IDENTITY(1,1) NOT NULL,
	[ExpressionValue] [nvarchar](300) NULL,
	[ExpressionExist] [bit] NULL,
	[ExpressionOccurrences] [int] NULL,
 CONSTRAINT [PK_LinguisticExpressions] PRIMARY KEY CLUSTERED 
(
	[ExpressionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [TextAppBackUp]
GO

/****** Object:  Table [dbo].[ExpressionsVsPositions]    Script Date: 16/12/2022 02:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExpressionsVsPositions](
	[ExpressionVsPositionID] [int] IDENTITY(1,1) NOT NULL,
	[ExpressionID] [int] NULL,
	[PositionID] [int] NULL,
 CONSTRAINT [PK_ExpressionsVsPositions] PRIMARY KEY CLUSTERED 
(
	[ExpressionVsPositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExpressionsVsPositions]  WITH CHECK ADD  CONSTRAINT [FK_ExpressionsVsPositions_LinguisticExpressions] FOREIGN KEY([ExpressionID])
REFERENCES [dbo].[LinguisticExpressions] ([ExpressionID])
GO

ALTER TABLE [dbo].[ExpressionsVsPositions] CHECK CONSTRAINT [FK_ExpressionsVsPositions_LinguisticExpressions]
GO

ALTER TABLE [dbo].[ExpressionsVsPositions]  WITH CHECK ADD  CONSTRAINT [FK_ExpressionsVsPositions_Positions] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Positions] ([PositionID])
GO

ALTER TABLE [dbo].[ExpressionsVsPositions] CHECK CONSTRAINT [FK_ExpressionsVsPositions_Positions]
GO


USE [TextAppBackUp]
GO

/****** Object:  Table [dbo].[WordsVsGroups]    Script Date: 16/12/2022 02:08:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WordsVsGroups](
	[WordVsGroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[WordID] [int] NOT NULL,
	[WordValue] [nvarchar](150) NULL,
 CONSTRAINT [PK_WordsVsGroups] PRIMARY KEY CLUSTERED 
(
	[WordVsGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WordsVsGroups]  WITH CHECK ADD  CONSTRAINT [FK_WordsVsGroups_Groups1] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO

ALTER TABLE [dbo].[WordsVsGroups] CHECK CONSTRAINT [FK_WordsVsGroups_Groups1]
GO

ALTER TABLE [dbo].[WordsVsGroups]  WITH CHECK ADD  CONSTRAINT [FK_WordsVsGroups_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO

ALTER TABLE [dbo].[WordsVsGroups] CHECK CONSTRAINT [FK_WordsVsGroups_Words]
GO




