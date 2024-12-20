USE [Management]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 11/24/2024 5:42:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteEmployee]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [EmployeeManagement].[tbEmployee]
    SET IsDeleted = 1, ModifiedDate = GETDATE()  
    WHERE Id = @Id;
END;
