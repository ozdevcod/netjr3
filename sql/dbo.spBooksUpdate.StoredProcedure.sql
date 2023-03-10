USE [databasename]
GO
/****** Object:  StoredProcedure [dbo].[spBooksUpdate]    Script Date: 12/20/2022 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spBooksUpdate] 
	-- Add the parameters for the stored procedure here
		@bookId int = null, 
		@name varchar(70) = null,
		@author varchar(70) = null,
		@pages smallint = null,
		@genre varchar(70) = null,
		@year varchar(4) = null
AS
BEGIN

	SET NOCOUNT ON;

			UPDATE
				[dbo].[Books]
			SET
				 [name] = isnull(@name,name)
				,[author] = isnull(@author,author)
				,[pages] = isnull(@pages,pages)
				,[genre] = isnull(@genre,genre)
				,[year] = isnull(@year,[year])
			WHERE
				id = @bookId;
END
GO
