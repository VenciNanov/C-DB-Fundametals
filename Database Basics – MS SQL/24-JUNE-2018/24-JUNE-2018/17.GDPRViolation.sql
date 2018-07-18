SELECT t.Id,
			CASE WHEN a.MiddleName IS NULL THEN a.FirstName+' '+a.LastName
			ELSE a.FirstName+' '+a.MiddleName+' '+a.LastName		
			END AS [FullName],
		c.Name AS[From],
		ct.Name AS[To],
			CASE
					WHEN t.CancelDate IS NOT NULL THEN 'Canceled' ELSE CONCAT(DATEDIFF(day,t.ArrivalDate,t.ReturnDate),' days')
			END AS [Duration]
		FROM Trips AS t
		JOIN Rooms AS r ON r.Id=t.RoomId
		JOIN Hotels AS h ON h.Id=r.HotelId
		JOIN Cities AS ct ON ct.Id=h.CityId
		JOIN AccountsTrips AS at ON at.TripId=t.Id
		JOIN Accounts AS a ON a.Id=at.AccountId
		JOIN Cities AS c ON c.Id=a.CityId
		--JOIN Cities AS c2 ON c.Id=h.CityId
ORDER BY FullName,t.Id
