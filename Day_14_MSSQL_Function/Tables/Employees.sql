SELECT Name, dbo.GetAnnualSalary(Salary) AS AnnualSalary
FROM Employees;

SELECT *
FROM dbo.GetEmployeesAboveSalary(50000);

SELECT Name, Salary,
       dbo.CalculateBonus(Salary, Department) AS Bonus
FROM Employees;