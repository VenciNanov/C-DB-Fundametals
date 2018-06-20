SELECt c.FirstName,c.Age,c.PhoneNumber FROM Customers AS c
JOIN Countries AS co ON co.Id = c.CountryId
WHERE (c.FirstName LIKE '%an%' AND c.Age >= 21) OR (c.PhoneNumber LIKE '%38'AND co.Name!='Greece')
ORDER BY c.FirstName ASC,c.Age DESC