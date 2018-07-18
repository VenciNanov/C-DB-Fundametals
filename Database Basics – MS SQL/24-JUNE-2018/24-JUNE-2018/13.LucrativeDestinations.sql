SELECT TOP(10) [CityId],
				[CityName],
				[TotalRevenue],
				[TripCount]
		FROM (
		SELECT DISTINCT
				c.Id AS [CityId],
				c.Name AS [CityName],
		SUM(h.BaseRate+r.Price) AS [TotalRevenue],
				COUNT(*) AS [TripCount]
				FROM Trips AS t
			JOIN Rooms AS r ON r.Id=t.RoomId
			JOIN Hotels AS h ON h.Id=r.HotelId
			JOIN Cities AS c ON c.Id=h.CityId
			WHERE DATEPART(YEAR,t.BookDate)=2016
			GROUP BY c.Id,c.Name
			) AS stats
			ORDER BY TotalRevenue DESC,TripCount DESC
	