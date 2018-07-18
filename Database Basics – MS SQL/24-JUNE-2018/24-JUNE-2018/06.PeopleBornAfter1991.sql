SELECT
		
			CASE WHEN MiddleName IS NULL THEN FirstName+' '+LastName
			ELSE FirstName+' '+MiddleName+' '+LastName
		
	END AS [FullName],DATEPART(Year,BirthDate) AS[BirthYear]
	FROM Accounts
WHERE DATEPART(YEAR,BirthDate)>1991
ORDER BY BirthYear DESC,FirstName ASC