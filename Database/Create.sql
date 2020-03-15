IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = N'ProductManagementSystemDatabase')
BEGIN
	CREATE DATABASE [ProductManagementSystemDatabase];
END
GO

USE [ProductManagementSystemDatabase];
GO

IF NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Products'))
BEGIN
    CREATE TABLE [dbo].[Products](
		[Code] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](max) NULL,
		[Price] [money] NULL,
		CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
		(
			[Code] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END