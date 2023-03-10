USE [databasename]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/20/2022 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](70) NULL,
	[author] [varchar](70) NULL,
	[pages] [smallint] NULL,
	[genre] [varchar](70) NULL,
	[year] [varchar](4) NULL,
	[creationDate] [datetime] NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_books_creationDate]  DEFAULT (getdate()) FOR [creationDate]
GO
