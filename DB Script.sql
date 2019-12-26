
 If(db_id(N'KPITEA') IS NULL)
 begin
 create database KPITEA
 end
 Go

USE [KPITEA]
GO

/****** Object:  Table [dbo].[tblEmployee]    Script Date: 26-12-2019 21:16:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee](
	[Emp_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[First_name] [varchar](50) NOT NULL,
	[Middle_name] [varchar](50) NULL,
	[Last_name] [varchar](50) NOT NULL,
	[Age] [tinyint] NOT NULL,
	[Marital_Status] [bit] NOT NULL,
	[Salary] [numeric](18, 0) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[LastChangedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Emp_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([Emp_ID])
REFERENCES [dbo].[tblEmployee] ([Emp_ID])
GO

ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_Employee_Employee]
GO


CREATE TABLE [dbo].[tblUserCredentials](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[EmployeeId] [numeric](18, 0) NOT NULL,
	[Username] [nchar](50) NOT NULL,
	[EmailId] [nchar](50) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[IsApproved] [bit] NOT NULL,
 CONSTRAINT [PK_tblUserCredentials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [tblUserCredentials_EmailId_unique] UNIQUE NONCLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblUserCredentials]  WITH CHECK ADD  CONSTRAINT [FK_tblUserCredentials_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([Emp_ID])
GO

ALTER TABLE [dbo].[tblUserCredentials] CHECK CONSTRAINT [FK_tblUserCredentials_tblEmployee]
GO
