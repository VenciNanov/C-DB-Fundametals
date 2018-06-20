SELECT TOP 1 WITH TIES mo.Name,COUNT(j.ModelId) AS [Times Serviced],
	(SELECT ISNULL(SUM(p.Price*op.Quantity),0)
		FROM Jobs AS j
	JOIN Orders AS o ON j.JobId=o.JobId
	JOIN OrderParts AS op ON o.OrderId=op.OrderId
	JOIN Parts AS p ON p.PartId=op.PartId
	WHERE j.ModelId=mo.ModelId) AS [Parts Total]	
 FROM Jobs AS j
JOIN Models AS mo ON mo.ModelId=j.ModelId
GROUP BY mo.Name,mo.ModelId
ORDER BY [Times Serviced] DESC