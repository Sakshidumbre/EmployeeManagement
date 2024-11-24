CREATE PROCEDURE AddEmployeeDetails
@Name NVARCHAR(100),
@Email NVARCHAR(100),
@PhoneNumber NVARCHAR(15),
@IsDeleted BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [EmployeeManagement].[tbEmployee] (Name, Email, PhoneNumber, createdDate, modifiedDate, IsDeleted)
    VALUES (@Name, @Email, @PhoneNumber, GETDATE(), GETDATE(), @IsDeleted);
END