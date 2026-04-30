use CompanyDB;
GO

CREATE PROCEDURE dbo.ManageEmployee
    @Action VARCHAR(10),
    @EmpID INT = NULL,
    @Name VARCHAR(50) = NULL,
    @Salary DECIMAL(10,2) = NULL,
    @Department VARCHAR(50) = NULL
AS
BEGIN
    IF @Action = 'INSERT'
    BEGIN
        INSERT INTO Employees(Name, Salary, Department)
        VALUES(@Name, @Salary, @Department)
    END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE Employees
        SET Name = @Name,
            Salary = @Salary,
            Department = @Department
        WHERE Emp_Id = @EmpID
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM Employees
        WHERE Emp_Id = @EmpID
    END
END
GO

CREATE FUNCTION dbo.GetAnnualSalary
(
    @MonthlySalary DECIMAL(10,2)
)
RETURNS DECIMAL(12,2)
AS
BEGIN
    RETURN @MonthlySalary * 12
END
GO

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
GO

CREATE FUNCTION dbo.CalculateBonus
(
    @Salary DECIMAL(10,2),
    @Department VARCHAR(50)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @Bonus DECIMAL(10,2)

    SET @Bonus =
        CASE
            WHEN @Department = 'IT' THEN @Salary * 0.15
            WHEN @Department = 'HR' THEN @Salary * 0.12
            ELSE @Salary * 0.10
        END

    RETURN @Bonus
END
GO

SELECT Name, dbo.GetAnnualSalary(Salary) AS AnnualSalary
FROM Employees;

SELECT *
FROM dbo.GetEmployeesAboveSalary(50000);

SELECT Name, Salary,
       dbo.CalculateBonus(Salary, Department) AS Bonus
FROM Employees;