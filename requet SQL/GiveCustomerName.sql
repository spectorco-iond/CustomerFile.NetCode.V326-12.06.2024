-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,ION>
-- Create date: <Create Date,12.04.2017 ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION dbo.GiveCustomerName(@wwn As Varchar(40))

RETURNS Varchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @cmp_name as Varchar(40)

	-- Add the T-SQL statements to compute the return value here
	SELECT @cmp_name = cmp_name from cicmpy where cmp_wwn = @wwn
	-- Return the result of the function
	RETURN @cmp_name

END
GO

