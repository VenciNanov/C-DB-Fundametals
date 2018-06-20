SELECT ISNULL(SUM(p.Price*op.Quantity),0.00) AS [Parts Total] FROM Parts AS p
JOIN OrderParts AS op ON op.PartId=p.PartId
JOIN Orders AS o ON o.OrderId=op.OrderId
WHERE DATEDIFF(week,o.IssueDate,'20170424')<=3