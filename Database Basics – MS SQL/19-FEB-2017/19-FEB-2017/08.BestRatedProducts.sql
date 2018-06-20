SELECT TOP(10) p.Name,p.Description,AVG(f.Rate) AS [AverageRate],COUNT(*) AS [FeedbacksAmount] FROM Products AS p
JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY p.Name,p.Description
ORDER BY AverageRate DESC,FeedbacksAmount DESC