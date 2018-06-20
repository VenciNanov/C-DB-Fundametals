SELECT m.Manufacturer, AVG(m.Consumption) AS [AverageConsumption]
FROM
(
	SELECT TOP(7) m.Id,COUNT(o.VehicleId) AS [OrdersCount]
	FROM Orders AS o
	JOIN Vehicles AS v ON o.VehicleId = v.Id
	JOIN Models AS m ON m.Id=v.ModelId
	GROUP BY m.Id
	ORDER BY COUNT(o.VehicleId) DESC
) AS mostOrdered
JOIN Models AS m ON m.Id =mostOrdered.Id
GROUP BY m.Manufacturer
HAVING AVG(m.Consumption) Between 5 and 15