USE [OSSStaging]
GO
/****** Object:  UserDefinedTableType [dbo].[CreateOSSOrdersTableType]    Script Date: 16/08/2014 03:16:00 ******/
CREATE TYPE [dbo].[CreateOSSOrdersTableType] AS TABLE(
	[THubOrderId] [bigint] NOT NULL,
	[THubOrderReferenceNo] [nvarchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[THubCompleteOrder] [nvarchar](max) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[OSSOrdersTableType]    Script Date: 16/08/2014 03:16:00 ******/
CREATE TYPE [dbo].[OSSOrdersTableType] AS TABLE(
	[THubOrderId] [bigint] NOT NULL,
	[THubOrderReferenceNo] [nvarchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[THubCompleteOrder] [nvarchar](max) NULL,
	[SentToMB] [bit] NULL,
	[SentToMBOn] [datetime] NULL,
	[MBPostShipmentMessage] [varchar](max) NULL,
	[MBPostShipmentResponseMessage] [varchar](max) NULL,
	[MBSuccessfullyReceived] [bit] NULL,
	[MBShipmentId] [nvarchar](15) NULL,
	[MBShipmentSubmitError] [nvarchar](max) NULL
)
GO
/****** Object:  StoredProcedure [dbo].[USPCreateOSSOrders]    Script Date: 16/08/2014 03:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USPCreateOSSOrders]
	@createOssOrders dbo.CreateOSSOrdersTableType READONLY
As
Begin
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Set NoCount On;
	
	Insert Into [OSSOrders]
           ([THubOrderId]
           ,[THubOrderReferenceNo]
           ,[CreatedOn]
		   ,[THubCompleteOrder])     
		SELECT [THubOrderId]
			  ,[THubOrderReferenceNo]
			  ,[CreatedOn]
			  ,[THubCompleteOrder]
		FROM  @createOssOrders

End

GO
/****** Object:  StoredProcedure [dbo].[USPLoadOrdersFromStaging]    Script Date: 16/08/2014 03:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USPLoadOrdersFromStaging] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [OSSOrderId]
      ,[THubOrderId]
      ,[THubOrderReferenceNo]
      ,[CreatedOn]
      ,[THubCompleteOrder]
      ,[SentToMB]
      ,[SentToMBOn]
      ,[MBPostShipmentMessage]
      ,[MBPostShipmentResponseMessage]
      ,[MBSuccessfullyReceived]
      ,[MBShipmentId]
      ,[MBShipmentSubmitError]
      ,[MBShipmentIdSubmitedToThub]
      ,[MBShipmentIdSubmitedToThubOn]
     FROM [dbo].[OSSOrders] WITH(NOLOCK)

END

GO
/****** Object:  Table [dbo].[Exceptions]    Script Date: 16/08/2014 03:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exceptions](
	[ExceptionId] [bigint] IDENTITY(1,1) NOT NULL,
	[ExceptionType] [int] NOT NULL,
	[OSSOrderId] [bigint] NULL,
	[Exception] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Exceptions] PRIMARY KEY CLUSTERED 
(
	[ExceptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExceptionTypes]    Script Date: 16/08/2014 03:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionTypes](
	[ExceptionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ExceptionType] [nvarchar](15) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ExceptionTypes] PRIMARY KEY CLUSTERED 
(
	[ExceptionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 16/08/2014 03:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogId] [bigint] IDENTITY(1,1) NOT NULL,
	[LogTypeId] [int] NOT NULL,
	[OSSOrderId] [bigint] NULL,
	[LogText] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LogTypes]    Script Date: 16/08/2014 03:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTypes](
	[LogTypeId] [int] IDENTITY(1,1) NOT NULL,
	[LogType] [nvarchar](25) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_LogTypes] PRIMARY KEY CLUSTERED 
(
	[LogTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OSSConfigurations]    Script Date: 16/08/2014 03:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OSSConfigurations](
	[ConfigId] [bigint] IDENTITY(1,1) NOT NULL,
	[ConfigKey] [nvarchar](50) NOT NULL,
	[ConfigValue] [nvarchar](100) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OSSOrders]    Script Date: 16/08/2014 03:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OSSOrders](
	[OSSOrderId] [bigint] IDENTITY(1,1) NOT NULL,
	[THubOrderId] [bigint] NOT NULL,
	[THubOrderReferenceNo] [nvarchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[THubCompleteOrder] [nvarchar](max) NULL,
	[SentToMB] [bit] NULL,
	[SentToMBOn] [datetime] NULL,
	[MBPostShipmentMessage] [nvarchar](max) NULL,
	[MBPostShipmentResponseMessage] [nvarchar](max) NULL,
	[MBSuccessfullyReceived] [bit] NULL,
	[MBShipmentId] [nvarchar](15) NULL,
	[MBShipmentSubmitError] [nvarchar](max) NULL,
	[MBShipmentIdSubmitedToThub] [bit] NULL,
	[MBShipmentIdSubmitedToThubOn] [datetime] NULL,
 CONSTRAINT [PK_OSSOrders] PRIMARY KEY CLUSTERED 
(
	[OSSOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[OSSOrders] ADD  CONSTRAINT [DF_OSSOrders_SentToMB]  DEFAULT ((0)) FOR [SentToMB]
GO
ALTER TABLE [dbo].[OSSOrders] ADD  CONSTRAINT [DF_OSSOrders_MBShipmentIdSubmitedToThub]  DEFAULT ((0)) FOR [MBShipmentIdSubmitedToThub]
GO
ALTER TABLE [dbo].[Exceptions]  WITH CHECK ADD  CONSTRAINT [FK_Exceptions_ExceptionTypes] FOREIGN KEY([ExceptionType])
REFERENCES [dbo].[ExceptionTypes] ([ExceptionTypeId])
GO
ALTER TABLE [dbo].[Exceptions] CHECK CONSTRAINT [FK_Exceptions_ExceptionTypes]
GO
ALTER TABLE [dbo].[Exceptions]  WITH CHECK ADD  CONSTRAINT [FK_Exceptions_OSSOrders] FOREIGN KEY([OSSOrderId])
REFERENCES [dbo].[OSSOrders] ([OSSOrderId])
GO
ALTER TABLE [dbo].[Exceptions] CHECK CONSTRAINT [FK_Exceptions_OSSOrders]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_LogTypes] FOREIGN KEY([LogTypeId])
REFERENCES [dbo].[LogTypes] ([LogTypeId])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_LogTypes]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_OSSOrders] FOREIGN KEY([OSSOrderId])
REFERENCES [dbo].[OSSOrders] ([OSSOrderId])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_OSSOrders]
GO
