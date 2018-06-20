SELECT  c.Name AS [CategoryName],
		COUNT(*) AS [ReporstsNumber] FROM Reports AS r
JOIN Categories AS c ON c.Id=r.CategoryId
GROUP BY c.Name
ORDER BY ReporstsNumber DESC,CategoryName ASC