USE [tds]
GO
/****** Object:  Table [dbo].[CompleteProcesses]    Script Date: 12.12.2019 22:47:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompleteProcesses](
	[processID] [int] IDENTITY(1,1) NOT NULL,
	[taskID] [int] NULL,
	[taskName] [nchar](50) NULL,
	[taskImportance] [nchar](50) NULL,
	[taskUrgency] [nchar](50) NULL,
	[executorID] [int] NULL,
	[executorNickname] [nchar](50) NULL,
	[executorQualification] [nchar](100) NULL,
	[executorRating] [int] NULL,
 CONSTRAINT [PK_CompleteProcesses] PRIMARY KEY CLUSTERED 
(
	[processID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Executors]    Script Date: 12.12.2019 22:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Executors](
	[executorID] [int] IDENTITY(1,1) NOT NULL,
	[nickName] [nchar](50) NULL,
	[firstName] [nchar](50) NULL,
	[secondName] [nchar](50) NULL,
	[fatherName] [nchar](50) NULL,
	[qualification] [nchar](100) NULL,
	[specialization] [nchar](100) NULL,
	[rating] [int] NULL,
	[phoneNumber] [nchar](20) NULL,
	[eMail] [nchar](50) NULL,
 CONSTRAINT [PK_Executors] PRIMARY KEY CLUSTERED 
(
	[executorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Processes]    Script Date: 12.12.2019 22:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Processes](
	[processID] [int] IDENTITY(1,1) NOT NULL,
	[taskID] [int] NULL,
	[taskName] [nchar](50) NULL,
	[taskImportance] [nchar](50) NULL,
	[taskUrgency] [nchar](50) NULL,
	[executorID] [int] NULL,
	[executorNickname] [nchar](50) NULL,
	[executorQualification] [nchar](100) NULL,
	[executorRating] [int] NULL,
 CONSTRAINT [PK_Processes] PRIMARY KEY CLUSTERED 
(
	[processID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 12.12.2019 22:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[taskID] [int] IDENTITY(1,1) NOT NULL,
	[miniDescr] [nchar](50) NULL,
	[fullDescr] [nchar](300) NULL,
	[urgency] [nchar](30) NULL,
	[importance] [nchar](20) NULL,
	[complexity] [nchar](30) NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[taskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12.12.2019 22:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[login] [nchar](50) NULL,
	[password] [nchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Processes]  WITH CHECK ADD  CONSTRAINT [FK_Processes_Executors] FOREIGN KEY([executorID])
REFERENCES [dbo].[Executors] ([executorID])
GO
ALTER TABLE [dbo].[Processes] CHECK CONSTRAINT [FK_Processes_Executors]
GO
ALTER TABLE [dbo].[Processes]  WITH CHECK ADD  CONSTRAINT [FK_Processes_Tasks] FOREIGN KEY([taskID])
REFERENCES [dbo].[Tasks] ([taskID])
GO
ALTER TABLE [dbo].[Processes] CHECK CONSTRAINT [FK_Processes_Tasks]
GO
