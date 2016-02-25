CREATE PROCEDURE [sp_tblLogin]
@LoginId int=null,
@LoginName varchar(100)=null,
@Email varchar(100)=null,
@Username varchar(20)=null,
@Password varchar(20)=null,
@Rights int=null,
@Mode varchar(25)
AS

IF (@Mode='Insert') 
IF NOT EXISTS (SELECT * FROM tblLogin WHERE Username=@Username)
BEGIN
	INSERT INTO tblLogin(LoginName,Email,Username,Password,Rights,ModifiedDate) VALUES(@LoginName,@Email,@Username,@Password,@Rights,getdate())
END

IF (@Mode='View') 
BEGIN
	SELECT * FROM tblLogin
END

IF (@Mode='ViewByID') 
BEGIN
	SELECT * FROM tblLogin WHERE LoginId = @LoginId
END

IF (@Mode='ChkLogin') 
BEGIN
	SELECT * FROM tblLogin WHERE Username = @Username and Password = @Password
END

IF (@Mode='Update') 
BEGIN
	UPDATE [tblLogin]
	SET [LoginName] = @LoginName
      ,[Email] = @Email
      ,[Username] = @Username
      ,[Password] = @Password
	  ,[Rights] = @Rights
      ,[ModifiedDate] = getdate()
	WHERE LoginId = @LoginId
END

IF (@Mode='Delete') 
BEGIN
	DELETE FROM [tblLogin] WHERE LoginId = @LoginId
END
GO

/**********************************************************************************************/


CREATE PROCEDURE [dbo].[sp_tblDepartment]
@DepartmentId int=null,
@DepartmentName varchar(100)=null,
@Mode varchar(25)
AS

IF (@Mode='Insert') 
IF NOT EXISTS (SELECT * FROM tblDepartment WHERE DepartmentName=@DepartmentName)
BEGIN
	INSERT INTO tblDepartment(DepartmentName) VALUES(@DepartmentName)
END

IF (@Mode='View') 
BEGIN
	SELECT * FROM tblDepartment
END

IF (@Mode='ViewByID') 
BEGIN
	SELECT * FROM tblDepartment WHERE DepartmentId = @DepartmentId
END

IF (@Mode='Update') 
BEGIN
	UPDATE tblDepartment
	SET DepartmentName = @DepartmentName
	WHERE DepartmentId = @DepartmentId
END

IF (@Mode='Delete') 
BEGIN
	DELETE FROM tblDepartment WHERE DepartmentId = @DepartmentId
END

GO

/**********************************************************************************************/


CREATE PROCEDURE [sp_tblEmployee]
@EmployeeId int=null,
@Name varchar(200)=null,
@DOB datetime=null,
@Degree varchar(200)=null,
@Address varchar(300)=null,
@City varchar(50)=null,
@State varchar(50)=null,
@Zip varchar(50)=null,
@Phone varchar(15)=null,
@Mobile varchar(15)=null,
@Email varchar(100)=null,
@Designation varchar(100)=null,
@DepartmentId int=null,
@DOJ datetime=null,
@DOC datetime=null,
@Bio text=null,
@Photo varchar(100)=null,
@Status int=null,
@Years int=null,
@Mode varchar(25)
AS

IF (@Mode='Insert') 
IF NOT EXISTS (SELECT * FROM [tblEmployee] WHERE [Name]=@Name and DOB=@DOB)
BEGIN
	INSERT INTO [tblEmployee]
           ([Name]
           ,[DOB]
		   ,[Degree]
           ,[Address]
           ,[City]
           ,[State]
           ,[Zip]
           ,[Phone]
           ,[Mobile]
           ,[Email]
           ,[Designation]
           ,[DepartmentId]
           ,[DOJ]
           ,[DOC]
           ,[Bio]
           ,[Photo]
           ,[Status])
     VALUES
           (@Name
           ,@DOB
		   ,@Degree
           ,@Address
           ,@City
           ,@State
           ,@Zip
           ,@Phone
           ,@Mobile
           ,@Email
           ,@Designation
           ,@DepartmentId
           ,@DOJ
           ,@DOC
           ,@Bio
           ,@Photo
           ,@Status)
END

IF (@Mode='View') 
BEGIN
	SELECT * FROM [tblEmployee]
END

IF (@Mode='ViewActive') 
BEGIN
	SELECT * FROM [tblEmployee] WHERE Status = 1 ORDER BY DepartmentId, DOJ
END

IF (@Mode='ViewInActive') 
BEGIN
	SELECT * FROM [tblEmployee] WHERE Status = 0
END

IF (@Mode='ViewByID') 
BEGIN
	SELECT * FROM [tblEmployee] WHERE EmployeeId = @EmployeeId
END

IF (@Mode='ViewService') 
BEGIN
	SELECT *,DATEDIFF(year, DOJ, getdate()) as Experience FROM [tblEmployee] WHERE Status = 1 ORDER BY DOJ
END

IF (@Mode='FilterService') 
BEGIN
	SELECT *,DATEDIFF(year, DOJ, getdate()) as Experience FROM [tblEmployee] WHERE Status = 1 and DATEDIFF(Year, DOJ, getdate())=@Years ORDER BY DOJ
END

IF (@Mode='ViewYears') 
BEGIN
	SELECT distinct DATEDIFF(Year, DOJ, getdate()) as EmpExp FROM [tblEmployee] WHERE Status = 1
END

IF (@Mode='Update') 
BEGIN
	UPDATE [tblEmployee]
	SET [Name] = @Name
      ,[DOB] = @DOB
	  ,[Degree] = @Degree
      ,[Address] = @Address
      ,[City] = @City
      ,[State] = @State
      ,[Zip] = @Zip
      ,[Phone] = @Phone
      ,[Mobile] = @Mobile
      ,[Email] = @Email
      ,[Designation] = @Designation
      ,[DepartmentId] = @DepartmentId
      ,[DOJ] = @DOJ
      ,[DOC] = @DOC
      ,[Bio] = @Bio
      ,[Photo] = @Photo
      ,[Status] = @Status
	WHERE EmployeeId = @EmployeeId
END

IF (@Mode='Delete') 
BEGIN
	DELETE FROM [tblEmployee] WHERE EmployeeId = @EmployeeId
END

IF (@Mode='Birthday') 
BEGIN
	SELECT * FROM tblEmployee WHERE DATEPART(MONTH, [DOB]) = DATEPART(MONTH, getdate()) and Status = 1 ORDER BY DATEPART(DAY, [DOB]) 
END

IF (@Mode='EmpCount') 
BEGIN
	SELECT count(EmployeeId) as EmpCount FROM tblEmployee WHERE Status = 1
END

GO

/**********************************************************************************************/


CREATE PROCEDURE [sp_tblTrainings]
@TrainingId int=null,
@StartDate datetime=null,
@EndDate datetime=null,
@TrainingDetails text=null,
@Effectiveness text=null,
@JobType int=null,
@EmployeeId int=null,
@Mode varchar(25)
AS

IF (@Mode='Insert') 
BEGIN
	INSERT INTO [tblTrainings]
           ([StartDate]
           ,[EndDate]
           ,[TrainingDetails]
           ,[Effectiveness]
           ,[JobType]
		   ,[EmployeeId])
     VALUES
           (@StartDate
           ,@EndDate
           ,@TrainingDetails
           ,@Effectiveness
           ,@JobType
		   ,@EmployeeId)
END

IF (@Mode='ViewByEmployee') 
BEGIN
	SELECT * FROM [tblTrainings] WHERE EmployeeId = @EmployeeId AND JobType = @JobType ORDER BY StartDate
END

IF (@Mode='ViewByID') 
BEGIN
	SELECT * FROM [tblTrainings] WHERE TrainingId = @TrainingId
END

IF (@Mode='Update') 
BEGIN
	UPDATE [tblTrainings]
	SET [StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[TrainingDetails] = @TrainingDetails,
		[Effectiveness] = @Effectiveness,
		[JobType] = @JobType
	WHERE TrainingId = @TrainingId
END

IF (@Mode='Delete') 
BEGIN
	DELETE FROM [tblTrainings] WHERE TrainingId = @TrainingId
END

GO