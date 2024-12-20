USE [Management]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeDetails]    Script Date: 11/24/2024 5:44:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateEmployeeDetails]
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;

    -- Perform the update
    UPDATE [EmployeeManagement].tbEmployee
    SET 
        Name = @Name,
        Email = @Email,
        PhoneNumber = @PhoneNumber,
        ModifiedDate = GETDATE()
    WHERE 
        Id = @Id AND IsDeleted = 0;

    -- Return the number of rows affected
    SELECT @@ROWCOUNT;
END
