CREATE PROCEDURE usp_EmployeesBySalaryLevel @SalaryLevel NVARCHAR(10)
AS
	SELECT 
		FirstName,
		LastName
	FROM Employees
WHERE @SalaryLevel = dbo.ufn_GetSalaryLevel(Salary)