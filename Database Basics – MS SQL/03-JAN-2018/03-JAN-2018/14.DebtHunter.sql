WITH cte_Ranked(ClientName,Email,Bill,TownName,Rank,ClientId) AS
(
SELECT c.FirstName+' '+c.LastName AS [Category Name],
		c.Email,
		o.Bill,
		t.Name,
		DENSE_RANK() OVER ( PARTITION BY t.Id ORDER BY o.Bill DESC) AS Rank,
		c.Id
	FROM Towns AS t
		JOIN Orders AS o ON o.TownId=t.Id
		JOIN Clients AS c ON c.Id=o.ClientId
	WHERE DATEDIFF(day,c.CardValidity,o.CollectionDate)>0 AND o.Bill IS NOT NULL
	GROUP BY t.Id,o.Bill,c.FirstName+' '+c.LastName,t.Name,c.Email,c.Id
)

SELECT cte.ClientName AS [Category Name],
		cte.Email AS [Email],
			cte.Bill AS [Bill],
		cte.TownName AS [Town]
	FROM cte_Ranked AS cte
WHERE cte.Rank=1 OR cte.Rank=2
ORDER BY cte.TownName,cte.Bill ,cte.ClientId 