--WITH RU_cte (AccountId,Email,CountryCode,Trips)
--AS
--(
	SELECT TOP(1) a.Id,a.Email,c.CountryCode,COUNT(*) AS [Trips]
		FROM Trips AS t
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	JOIN Cities AS c ON c.Id=h.CityId
	JOIN AccountsTrips AS at ON at.TripId=t.Id
	JOIN Accounts AS a ON a.Id=at.AccountId
	WHERE c.CountryCode = 'RU' 
	GROUP BY a.Id,a.Email,c.CountryCode
	ORDER BY Trips DESC,a.Id
	
	SELECT TOP(1) a.Id,a.Email,c.CountryCode,COUNT(*) AS [Trips]
		FROM Trips AS t
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	JOIN Cities AS c ON c.Id=h.CityId
	JOIN AccountsTrips AS at ON at.TripId=t.Id
	JOIN Accounts AS a ON a.Id=at.AccountId
	WHERE c.CountryCode = 'UK' 
	GROUP BY a.Id,a.Email,c.CountryCode
	ORDER BY Trips DESC,a.Id
	
	
	SELECT TOP(1) a.Id,a.Email,c.CountryCode,COUNT(*) AS [Trips]
		FROM Trips AS t
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	JOIN Cities AS c ON c.Id=h.CityId
	JOIN AccountsTrips AS at ON at.TripId=t.Id
	JOIN Accounts AS a ON a.Id=at.AccountId
	WHERE c.CountryCode = 'US' 
	GROUP BY a.Id,a.Email,c.CountryCode
	ORDER BY Trips DESC,a.Id

	SELECT TOP(1) a.Id,a.Email,c.CountryCode,COUNT(*) AS [Trips]
		FROM Trips AS t
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	JOIN Cities AS c ON c.Id=h.CityId
	JOIN AccountsTrips AS at ON at.TripId=t.Id
	JOIN Accounts AS a ON a.Id=at.AccountId
	WHERE c.CountryCode = 'BG' 
	GROUP BY a.Id,a.Email,c.CountryCode
	ORDER BY Trips DESC,a.Id


