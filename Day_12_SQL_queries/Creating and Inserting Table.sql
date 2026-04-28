create Database CompanyDB;
USE CompanyDB;

CREATE TABLE Employees(
            Emp_Id INT PRIMARY KEY,
            Name VARCHAR(50),
            Department VARCHAR(50),
            Salary DECIMAL(10,2),
            JoinDate DATE);
INSERT INTO Employees(Emp_Id, Name, Department, Salary, JoinDate)
VALUES(1, 'Amit Sharma', 'HR', 35000.00, '2022-01-15'),
      (2, 'Neha Verma', 'IT', 60000.00, '2021-07-10'),
      (3, 'Rahul Singh', 'Finance', 50000.00, '2020-03-20'),
      (4, 'Priya Gupta', 'Marketing', 45000.00, '2023-05-12'),
      (5, 'Sagar Kumar', 'IT', 300000.00, '2019-11-25');
SELECT * FROM Employees;