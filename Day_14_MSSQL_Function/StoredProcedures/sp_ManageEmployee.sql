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