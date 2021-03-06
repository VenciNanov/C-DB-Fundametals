SELECT c.Name AS [CategoryName],
		COUNT(*) AS [EmployeesNumber] FROM Employees AS e
	JOIN Departments AS d ON d.Id= e.DepartmentId
	JOIN Categories AS c ON c.DepartmentId=d.Id
GROUP BY c.Name
ORDER BY CategoryName