SELECT f.ProductId,c.FirstName+' '+c.LastName AS [CustomerName],f.Description FROM Feedbacks AS f
JOIN Customers AS c ON c.Id=f.CustomerId
WHERE f.CustomerId IN(
	SELECT CustomerId
	FROM Feedbacks
	GROUP BY CustomerId
	HAVING COUNT(*)>=3
	)
ORDER BY f.ProductId,CustomerName,f.Id