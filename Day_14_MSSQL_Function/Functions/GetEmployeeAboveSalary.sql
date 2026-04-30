CREATE FUNCTION dbo.GetEmployeesAboveSalary
(
    @MinSalary DECIMAL(10,2)
)
RETURNS TABLE
AS
RETURN
(
    SELECT Name, Salary
    FROM Employees
    WHERE Salary > @MinSalary
)