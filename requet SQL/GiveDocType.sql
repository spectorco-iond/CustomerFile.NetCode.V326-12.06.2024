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
 --Author:		<Author,,Ion>
 --Create date: <Create Date,12.04.2017 ,>
 --Description:	<Description,Return Document Type Description,>
-- =============================================
CREATE FUNCTION dbo.GiveDocType(@id AS Int)

RETURNS Varchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Doc_Description AS Varchar(50)

	-- Add the T-SQL statements to compute the return value here
	
select @Doc_Description = DOC_TYPE  from MDB_CFG_ITEM_DOC_TYPE where ITEM_DOC_TYPE_ID = @id

	-- Return the result of the function
	RETURN @Doc_Description

END
GO

