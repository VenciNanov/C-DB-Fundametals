SELECT TOP(10) p.Name,p.Description,
	AVG(f.Rate) AS [AverageRate],
	COUNT(*) AS [FeedbacksAmount]
	FROM Feedbacks AS f
	JOIN Products AS p ON f.ProductId=p.Id
GROUP BY p.Name,p.Description
ORDER BY AverageRate DESC,FeedbacksAmount DESC