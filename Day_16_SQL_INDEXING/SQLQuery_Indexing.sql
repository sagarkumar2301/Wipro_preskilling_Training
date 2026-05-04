USE CompanyDB;

CREATE TABLE New_Employees (
    emp_id INT PRIMARY KEY,
    name VARCHAR(100),
    email VARCHAR(100),
    department_id INT,
    salary DECIMAL(10,2)
);

INSERT INTO New_Employees (emp_id, name, email, department_id, salary)
        VALUES (1, 'Amit Kumar', 'amit@gmail.com', 1, 50000),
               (2, 'Neha Sharma', 'neha@gmail.com', 2, 60000),
               (3, 'Rahul Verma', 'rahul@gmail.com', 1, 55000),
               (4, 'Priya Singh', 'priya@gmail.com', 3, 70000),
               (5, 'Sanjay Gupta', 'sanjay@gmail.com', 2, 65000);

-- Index on email
CREATE UNIQUE INDEX idx_email
ON New_Employees(email);

-- Index on salary
CREATE UNIQUE INDEX idx_salary
ON New_Employees(salary);

-- Index on department
CREATE INDEX idx_dept
ON New_Employees(department_id);

-- Composite index
CREATE INDEX idx_dept_salary
ON New_Employees(department_id, salary);

SELECT * FROM New_Employees;

SELECT * FROM New_Employees
WHERE Salary > 60000;

DROP INDEX idx_salary ON New_Employees;
DROP INDEX idx_email ON New_Employees;
DROP INDEX idx_dept ON New_Employees;
DROP INDEX idx_dept_salary ON New_Employees;

SET Statistics TIME ON;

SET Statistics IO ON;

SET Statistics PROFILE ON;

