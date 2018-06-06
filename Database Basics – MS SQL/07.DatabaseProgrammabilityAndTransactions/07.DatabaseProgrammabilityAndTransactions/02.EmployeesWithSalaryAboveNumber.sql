CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
	@Salary DECIMAL(18,4)
AS
	SELECT
		FirstName,
		LastName
		FROM Employees
	Where Salary>=@Salary