CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
	
AS
	SELECT
		FirstName,
		LastName
		FROM Employees
	Where Salary>=35000