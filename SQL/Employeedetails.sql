CREATE PROCEDURE GetEmployeeDetails
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, Email, PhoneNumber, createdDate, modifiedDate, IsDeleted
    FROM [EmployeeManagement].[tbEmployee]
    WHERE IsDeleted = 0;   
END;
