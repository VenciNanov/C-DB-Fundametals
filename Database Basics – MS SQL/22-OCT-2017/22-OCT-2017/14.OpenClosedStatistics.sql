SELECT [EmpName], CONCAT(Closed,'/',Opened) AS [Closed Open Reports]
	FROM(SELECT
		CONCAT(e.FirstName,' ',e.LastName) AS [EmpName],
		e.Id AS [EmpId],
		COUNT(r.CloseDate) AS [Closed],
		COUNT(r.OpenDate) AS [Opened]
		FROM Employees AS e
		JOIN Reports AS r ON r.EmployeeId=e.Id
		WHERE DATEPART(year,r.OpenDate)=2016 OR DATEPART(year,r.CloseDate)=2016
		GROUP BY CONCAT(e.FirstName,' ',e.LastName),e.Id
	)  AS emps
JOIN Employees AS e ON e.Id=emps.EmpId
ORDER BY EmpName ASC,e.Id