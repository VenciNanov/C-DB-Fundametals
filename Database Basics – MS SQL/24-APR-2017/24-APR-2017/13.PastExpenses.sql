SELECT j.JobId AS [JobId],
		ISNULL(SUM(p.Price*op.Quantity),0.00) AS [Total]
	FROM Jobs AS j
	LEFT OUTER JOIN Orders AS o ON o.JobId=j.JobId
	LEFT OUTER JOIN OrderParts AS op ON op.OrderId=o.OrderId
	LEFT OUTER JOIN Parts AS p ON p.PartId=op.PartId
WHERE j.Status ='Finished'
GROUP BY j.JobId
ORDER BY Total DESC,j.JobId ASC