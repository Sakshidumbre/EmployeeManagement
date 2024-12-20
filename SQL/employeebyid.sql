USE [Management]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 11/24/2024 5:43:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetEmployeeById]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM [EmployeeManagement].[tbEmployee]
    WHERE Id = @Id AND IsDeleted = 0;
END;