SELECT j.ModelId,m.Name, 
		CONCAT(AVG(DATEDIFF(day,j.IssueDate,j.FinishDate)),' days') AS [Average Service Time]
	FROM Jobs AS j
	JOIN Models AS m ON m.ModelId=j.ModelId
WHERE j.Status='Finished'
GROUP BY j.ModelId,m.Name
ORDER BY AVG(DATEDIFF(day,j.IssueDate,j.FinishDate))