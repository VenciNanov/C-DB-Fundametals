SELECT TOP (15) i.Name,i.Description,
		c.Name AS [CountryName]
		FROM Ingredients AS i
JOIN Countries AS c ON i.OriginCountryId=c.Id
WHERE c.Name IN ('Bulgaria','Greece')
ORDER BY i.Name,CountryName