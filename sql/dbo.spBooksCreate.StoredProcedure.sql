USE [databasename]
GO
/****** Object:  StoredProcedure [dbo].[spBooksCreate]    Script Date: 12/20/2022 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spBooksCreate] 
	-- Add the parameters for the stored procedure here
		@name			VARCHAR(70) = NULL, 
		@author			VARCHAR(70) = NULL,
		@pages			SMALLINT	= NULL,
		@genre			VARCHAR(70) = NULL,
		@year			VARCHAR(4)	= NULL
	
AS
BEGIN
	SET NOCOUNT ON;

			INSERT INTO [dbo].[Books]
					   (
					    [name]
					   ,[author]
					   ,[pages]
					   ,[genre]
					   ,[year]
					   )
				 VALUES
					   (
					    @name
					   ,@author
					   ,@pages
					   ,@genre
					   ,@year
					   )


END
GO
