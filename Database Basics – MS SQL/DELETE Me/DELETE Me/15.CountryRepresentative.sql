SELECT [CountryName], DistributorName
FROM(
	SELECT c.Name AS [CountryName],
			d.Name AS [DistributorName],
			COUNT(i.DistributorId) AS [IngredientsByDistributor],
			DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.DistributorId) DESC) AS RANK
		FROM Countries AS c
			JOIN Distributors AS d ON d.CountryId=c.Id
			JOIN Ingredients AS i ON i.DistributorId=d.Id
		GROUP BY c.Name,d.Name
) AS ranked
WHERE Rank=1
ORDER BY CountryName,DistributorName