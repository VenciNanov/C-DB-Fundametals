SELECT at.TripId,
		h.Name AS [HotelName],
		r.Type AS [RoomType],
		(CASE
			WHEN t.CancelDate IS NULL THEN SUM(r.Price+h.BaseRate) 
			ELSE 0.00
		END)AS [Revenue]
	FROM Trips AS t
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	JOIN AccountsTrips AS at ON at.TripId=t.Id
GROUP By AT.TripId, H.Name, R.Type, T.CancelDate
ORDER BY RoomType ASC,at.TripId 