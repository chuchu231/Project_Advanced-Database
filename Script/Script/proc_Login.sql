USE [CSDLNC05]
GO
/****** Object:  StoredProcedure [dbo].[LOGIN]    Script Date: 1/7/2024 3:17:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LOGIN]
    @USERNAME CHAR(10),
    @PASSWORD CHAR(10)
AS
BEGIN
    DECLARE @result CHAR(20);

    IF (@USERNAME IS NULL OR @PASSWORD IS NULL)
    BEGIN
        SET @result = 'InvalidInput';
    END
    ELSE IF EXISTS (SELECT 1 FROM dbo.DENTIST WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD)
    BEGIN
        SET @result = 'Dentist';
    END
    ELSE IF EXISTS (SELECT 1 FROM dbo.STAFF WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD)
    BEGIN
        SET @result = 'Staff';
    END
    ELSE IF EXISTS (SELECT 1 FROM dbo.PATIENT WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD)
    BEGIN
        SET @result = 'Patient';
    END
    ELSE IF @USERNAME = 'admin'
    BEGIN
        SET @result = 'Admin';
    END
    ELSE
    BEGIN
        SET @result = 'UserNotFound';
    END

    SELECT @result AS 'UserRole';
END;
GO
