--create database Car 
USE Car
GO

/****** Object:  Table [dbo].[Book]    Script Date: 8/16/2023 1:08:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cars](
	[carID] [int] IDENTITY(1,1) NOT NULL,
	[CarMaker] [varchar](250) NOT NULL,
	[CarModel] [varchar](250) NOT NULL,
	[CarYear] [int] NULL,
) ON [PRIMARY]
GO
