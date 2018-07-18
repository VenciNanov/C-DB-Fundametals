SELECT a.Id,
		a.Email,
		c.Name AS [City],
		COUNT(*) AS [Trips]
	FROM Trips AS t
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	JOIN AccountsTrips AS at ON at.TripId=t.Id
	JOIN Accounts AS a ON a.Id=at.AccountId
	JOIN Cities AS c ON c.Id=a.CityId
WHERE a.CityId=h.CityId
GROUP BY a.Id,a.Email,c.Name
ORDER BY Trips DESC,a.Id
