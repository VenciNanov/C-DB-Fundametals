SELECT DISTINCT [DepartmentId], SUM([Salary]) AS [TotalSalary] FROM Employees
GROUP BY DepartmentID