USE [100]
GO
/****** Object:  UserDefinedFunction [dbo].[GiveCustomerName]    Script Date: 12/5/2017 10:57:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,ION>
-- Create date: <Create Date,12.04.2017 ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[GiveCustomerName](@wwn As Varchar(40))

RETURNS Varchar(50)
AS
BEGIN
	DECLARE @cmp_name as Varchar(40)
	IF ISNULL(@wwn,'') <> ''
	BEGIN
		-- Declare the return variable here

	 
	-- Add the T-SQL statements to compute the return value here
	SELECT 	 @cmp_name = cmp_name from cicmpy where cmp_wwn = @wwn
-- Return the result of the function
	END	
	ELSE 
	BEGIN
	SET @cmp_name = ''
	END
	
	RETURN @cmp_name
END
