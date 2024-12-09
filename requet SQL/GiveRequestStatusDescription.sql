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
CREATE FUNCTION dbo.GiveRequestStatusDesc(@id AS int)

Returns Varchar(50)
As
Begin
declare @StatusDesc As varchar(50)

 Set  @StatusDesc =  Case 
	WHEN  @id =  0 Then  'OPEN' 
	WHEN  @id =  1 Then 'APPROVED' 
	WHEN  @id = 2 Then  'Rejected' 
	WHEN  @id =  3 Then 'Processed' 
	WHEN  @id =  4 Then 'Realized'
	WHEN  @id = 5 Then  'Draft' 
	WHEN  @id = 6 Then  'Reopen'  
	End 

	return @StatusDesc
END
GO

