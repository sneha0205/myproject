USE [sample]
GO
/****** Object:  Table [dbo].[CompanyMaster]    Script Date: 10/21/2020 21:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[Status] [varchar](20) NULL,
 CONSTRAINT [PK_CompanyMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FileMaster]    Script Date: 10/21/2020 21:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](max) NOT NULL,
	[CompanyId] [int] NULL,
 CONSTRAINT [PK_FileMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_FileMaster_CompanyMaster]    Script Date: 10/21/2020 21:33:17 ******/
ALTER TABLE [dbo].[FileMaster]  WITH CHECK ADD  CONSTRAINT [FK_FileMaster_CompanyMaster] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[CompanyMaster] ([Id])
GO
ALTER TABLE [dbo].[FileMaster] CHECK CONSTRAINT [FK_FileMaster_CompanyMaster]
GO
