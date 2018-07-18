--SELECT [AccountId],[FullName],[LongestTrip],[ShortestTrip]
	--FROM(
	SELECT at.AccountId AS [AccountId],
				a.FirstName+' '+a.LastName AS [FullName],
				MAX(DATEDIFF(day,t.ArrivalDate,t.ReturnDate)) AS [LongestTrip],
				MIN(DATEDIFF(day,t.ArrivalDate,t.ReturnDate)) AS [ShortestTrip]
			FROM Accounts AS a
		JOIN AccountsTrips AS at ON at.AccountId=a.Id
		JOIN Trips AS t ON t.Id=at.TripId
		WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL
		GROUP BY at.AccountId,a.FirstName+' '+a.LastName
		ORDER BY LongestTrip DESC,AccountId
