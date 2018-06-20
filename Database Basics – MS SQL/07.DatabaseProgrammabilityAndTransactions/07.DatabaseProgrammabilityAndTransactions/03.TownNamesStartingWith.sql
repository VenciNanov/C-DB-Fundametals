CREATE PROCEDURE usp_GetTownsStartingWith
	@StartString NVARCHAR(10)
AS 
	SELECT Name
	FROM Towns
	WHERE Name LIKE @StartString+'%'