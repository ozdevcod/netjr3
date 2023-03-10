USE [databasename]
GO
/****** Object:  StoredProcedure [dbo].[spBooksRead]    Script Date: 12/20/2022 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spBooksRead] 
	@bookId int = null
AS
BEGIN
	SET NOCOUNT ON;
    
	SELECT * FROM books
	WHERE books.id = isnull(@bookId, books.id);

END
GO
