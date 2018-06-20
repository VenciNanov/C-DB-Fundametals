SELECT m.Manufacturer,m.Model,
		COUNT(o.VehicleId) AS [TimesOrdered]
	FROM Models AS m
JOIN Vehicles AS v ON v.ModelId=m.Id
LEFT JOIN Orders AS o ON o.VehicleId = v.Id
GROUP BY ALL m.Model,m.Manufacturer
ORDER BY TimesOrdered DESC,Manufacturer DESC,Model ASC