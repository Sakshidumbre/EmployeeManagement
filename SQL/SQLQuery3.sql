USE [Management]
GO

/****** Object:  Table [EmployeeManagement].[tbEmployee]    Script Date: 11/23/2024 9:00:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [EmployeeManagement].[tbEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[createdDate] [datetime] NULL,
	[modifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [EmployeeManagement].[tbEmployee] ADD  DEFAULT (getdate()) FOR [createdDate]
GO

ALTER TABLE [EmployeeManagement].[tbEmployee] ADD  DEFAULT (getdate()) FOR [modifiedDate]
GO

ALTER TABLE [EmployeeManagement].[tbEmployee] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO

