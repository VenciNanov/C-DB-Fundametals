SELECT p.PartId AS [PartId],
		p.Description AS [Description],
		SUM(pn.Quantity) AS [Required],
		SUM(p.StockQty) AS [In Stock],
		ISNULL(SUM(op.Quantity),0) AS [Ordered]
	FROM Parts AS p
LEFT OUTER JOIN PartsNeeded AS pn ON pn.PartId=p.PartId
LEFT OUTER JOIN Jobs AS j oN j.JobId=pn.JobId
LEFT OUTER JOIN Orders AS o ON o.JobId=j.JobId
LEFT OUTER JOIN OrderParts AS op ON op.OrderId=o.OrderId
WHERE j.Status<>'Finished'
GROUP BY p.PartId,p.Description
HAVING SUM(p.StockQty)+ISNULL(SUM(op.Quantity),0)<SUM(pn.Quantity)
ORDER BY p.PartId