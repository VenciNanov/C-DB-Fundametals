SELECT TOP(1) WITH TIES co.Name AS [CountryName],
						AVG(f.Rate) AS [FeedbackRate]
	FROM Countries AS co
	JOIN Customers AS cu ON cu.CountryId=co.Id
	JOIN Feedbacks AS f ON f.CustomerId=cu.Id
GROUP BY co.Name
ORDER BY FeedbackRate DESC