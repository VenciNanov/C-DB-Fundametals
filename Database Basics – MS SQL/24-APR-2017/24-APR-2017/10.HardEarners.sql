SELECT m.FirstName+' '+m.LastName AS [Mechanic],
		COUNT(*) AS [Jobs]
	FROM Jobs AS j
		JOIN Mechanics AS m ON m.MechanicId=j.MechanicId
WHERE Status<>'Finished'
GROUP BY m.FirstName+' '+m.LastName,m.MechanicId
HAVING COUNT(*)>1
ORDER BY Jobs DESC,m.MechanicId