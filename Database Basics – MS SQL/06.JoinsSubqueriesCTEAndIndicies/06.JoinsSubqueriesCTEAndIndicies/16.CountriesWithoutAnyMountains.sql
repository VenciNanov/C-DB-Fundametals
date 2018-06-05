SELECT COUNT(c.CountryCode) AS CountryCode FROM Countries AS c
LEFT OUTEr JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
LEFT OUTER JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE m.Id IS NULL