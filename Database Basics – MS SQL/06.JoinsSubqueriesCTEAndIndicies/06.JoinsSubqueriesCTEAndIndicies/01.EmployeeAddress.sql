SELECT TOP (5) e.EmployeeID,e.JobTitle,a.AddressID AS [AddressId], a.AddressText
FROM Employees e
	JOIN Addresses a ON e.AddressID=a.AddressID
	JOIN Towns t ON a.TownID=t.TownID
ORDER BY a.AddressID ASC