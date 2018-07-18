SELECT at.TripId,
		SUM(at.Luggage) AS [Luggage],
			CONCAT('$',CASE 
				WHEN SUM(at.Luggage)<=5 THEN 0
				ELSE SUM(at.Luggage*5) END) AS [Fee]
		FROM AccountsTrips AS at
WHERE Luggage>0
GROUP BY at.TripId
ORDER BY Luggage DESC

