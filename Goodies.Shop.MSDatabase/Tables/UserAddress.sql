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


