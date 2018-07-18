SELECT cu.FirstName,cu.Age,cu.PhoneNumber
	FROM Customers AS cu
	JOIN Countries AS c ON c.Id=cu.CountryId
WHERE (cu.Age>=21 AND cu.FirstName LIKE '%an%') 
	OR(cu.PhoneNumber LIKE '%38' AND c.Name!='Greece')
ORDER BY cu.FirstName,cu.Age DESC