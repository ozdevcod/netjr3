USE [databasename]
GO
/****** Object:  StoredProcedure [dbo].[spBooksDelete]    Script Date: 12/20/2022 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: 
-- Create date	: 
-- Description	: 			
-- =============================================
CREATE PROCEDURE [dbo].[spBooksDelete] 
	-- Add the parameters for the stored procedure here
	@bookId int = null
	  
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (
				SELECT id FROM books WHERE id=@bookid
			  ) 
	BEGIN 
			DELETE FROM books
			WHERE id = @bookId;
	END

END
GO
