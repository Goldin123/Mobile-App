USE [Goodies]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2024/03/26 12:05:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](500) NULL,
	[LastName] [varchar](100) NULL,
	[EmailAddress] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Cellphone] [varchar](50) NULL,
	[UserTypeID] [int] NULL,
	[UserAddressID] [int] NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[DateLastOrdered] [datetime] NULL,
	[IsApproved] [bit] NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddress]    Script Date: 2024/03/26 12:05:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddress](
	[UserAddressID] [int] IDENTITY(1,1) NOT NULL,
	[PhysicalAddress1] [varchar](150) NULL,
	[PhysicalAddress2] [varchar](150) NULL,
	[PhysicalAddress3] [varchar](150) NULL,
	[PhysicalAddress4] [varchar](150) NULL,
	[PhysicalAddressCode] [varchar](50) NULL,
	[PostalAddress1] [varchar](150) NULL,
	[PostalAddress2] [varchar](150) NULL,
	[PostalAddress3] [varchar](150) NULL,
	[PostalAddress4] [varchar](150) NULL,
	[PostalAddressCode] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Province] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED 
(
	[UserAddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 2024/03/26 12:05:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeCode] [varchar](50) NULL,
	[UserTypeDescription] [varchar](500) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeCode], [UserTypeDescription], [DateCreated], [DateModified]) VALUES (1, N'ADMIN', N'Administrator', CAST(N'2024-03-26T00:00:00.000' AS DateTime), CAST(N'2024-03-26T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeCode], [UserTypeDescription], [DateCreated], [DateModified]) VALUES (2, N'CUSTOMER', N'Customer', CAST(N'2024-03-26T00:00:00.000' AS DateTime), CAST(N'2024-03-26T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_User_Email]    Script Date: 2024/03/26 12:05:33 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UK_User_Email] UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_User_UserAddress] FOREIGN KEY([UserAddressID])
REFERENCES [dbo].[UserAddress] ([UserAddressID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserAddress]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
