CREATE TABLE [tblLogin](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Username] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Rights] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL
) ON [PRIMARY]

GO


INSERT INTO [tblLogin]
           ([LoginName]
           ,[Email]
           ,[Username]
           ,[Password]
           ,[Rights]
           ,[ModifiedDate])
     VALUES
           ('Administrator'
           ,'admin@admin.com'
           ,'admin'
           ,'admin'
           ,1
           ,getdate())


CREATE TABLE [tblDepartment](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO


INSERT INTO [tblDepartment] ([DepartmentName]) VALUES ('Management')
INSERT INTO [tblDepartment] ([DepartmentName]) VALUES ('HR')
INSERT INTO [tblDepartment] ([DepartmentName]) VALUES ('Engineering')
INSERT INTO [tblDepartment] ([DepartmentName]) VALUES ('Accounts')


CREATE TABLE [tblEmployee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Degree] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Phone] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Mobile] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Designation] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[DOJ] [datetime] NOT NULL,
	[DOC] [datetime] NOT NULL,
	[Bio] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Photo] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [tblTrainings](
	[TrainingId] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[TrainingDetails] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Effectiveness] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[JobType] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


