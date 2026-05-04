USE CompanyDB;
GO


SELECT Emp_Id, Name, Department, Salary, JoinDate
FROM dbo.Employees
WHERE Salary > (SELECT AVG(Salary) FROM dbo.Employees);


SELECT Emp_Id, Name, Department, Salary, JoinDate
FROM dbo.Employees
WHERE Department = 'IT';

SELECT Emp_Id, Name, Department, Salary, JoinDate
FROM dbo.Employees
WHERE Salary = (SELECT MAX(Salary) FROM dbo.Employees);


SELECT Emp_Id, Name, Department, Salary, JoinDate
FROM dbo.Employees e
WHERE Salary > (
    SELECT AVG(Salary)
    FROM dbo.Employees
    WHERE Department = e.Department
);

-- Highest paid employee in each department
SELECT Emp_Id, Name, Department, Salary, JoinDate
FROM dbo.Employees e
WHERE Salary = (
    SELECT MAX(Salary)
    FROM dbo.Employees
    WHERE Department = e.Department
);

-- Departments with above-average salaries
SELECT Department
FROM dbo.Employees
GROUP BY Department
HAVING AVG(Salary) > (SELECT AVG(Salary) FROM dbo.Employees);

-- Employees earning above their department average
SELECT e.Emp_Id, e.Name, e.Department, e.Salary, e.JoinDate
FROM dbo.Employees e
INNER JOIN (
    SELECT Department, AVG(Salary) AS AvgSal
    FROM dbo.Employees
    GROUP BY Department
) d ON e.Department = d.Department
WHERE e.Salary > d.AvgSal;

-- Highest paid employee per department
SELECT e.Emp_Id, e.Name, e.Department, e.Salary, e.JoinDate
FROM dbo.Employees e
INNER JOIN (
    SELECT Department, MAX(Salary) AS MaxSal
    FROM dbo.Employees
    GROUP BY Department
) d ON e.Department = d.Department
   AND e.Salary = d.MaxSal;