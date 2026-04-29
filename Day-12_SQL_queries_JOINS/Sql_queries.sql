USE CompanyDB;
GO

CREATE SCHEMA Sales;
GO
CREATE SCHEMA CustomerData;
GO
CREATE SCHEMA Reports;
GO

IF OBJECT_ID('CustomerData.Customers', 'U') IS NULL
BEGIN
    CREATE TABLE CustomerData.Customers (
        Id INT PRIMARY KEY,
        Name VARCHAR(50),
        Age INT,
        City VARCHAR(50)
    );
END

CREATE TABLE Sales.Orders (
    OrderId INT PRIMARY KEY,
    CustomerId INT,
    OrderDate DATE,
    Amount DECIMAL(10,2),
    FOREIGN KEY (CustomerId) REFERENCES CustomerData.Customers(Id)
);

CREATE TABLE Reports.CustomerOrders (
    CustomerName VARCHAR(50),
    OrderId INT,
    OrderDate DATE,
    Amount DECIMAL(10,2)
);

INSERT INTO CustomerData.Customers VALUES
(1, 'John Doe', 30, 'New York'),
(2, 'Jane Smith', 25, 'Los Angeles'),
(3, 'Alice Johnson', 28, 'Chicago'),
(4, 'Bob Brown', 35, 'Houston'),
(5, 'Charlie Davis', 32, 'Phoenix'),
(6, 'David Wilson', 40, 'San Francisco');

INSERT INTO Sales.Orders VALUES
(1, 1, '2024-01-01', 100.00),
(2, 2, '2024-01-02', 150.00),
(3, 3, '2024-01-03', 200.00),
(4, 1, '2024-01-04', 250.00),
(5, 2, '2024-01-05', 300.00);

INSERT INTO Reports.CustomerOrders VALUES
('John Doe', 1, '2024-01-01', 100.00),
('Jane Smith', 2, '2024-01-02', 150.00),
('Alice Johnson', 3, '2024-01-03', 200.00),
('John Doe', 4, '2024-01-04', 250.00),
('Jane Smith', 5, '2024-01-05', 300.00);

SELECT * FROM CustomerData.Customers;
SELECT * FROM Sales.Orders;
SELECT * FROM Reports.CustomerOrders;

SELECT 
    c.Name,
    o.OrderId,
    o.OrderDate,
    o.Amount
FROM CustomerData.Customers c
JOIN Sales.Orders o ON c.Id = o.CustomerId;

SELECT  c.Name, o.OrderId
FROM CustomerData.Customers c
LEFT JOIN Sales.Orders o ON c.Id = o.CustomerId;

SELECT  c.Name, o.OrderId
FROM CustomerData.Customers c
RIGHT JOIN Sales.Orders o ON c.Id = o.CustomerId;

SELECT  c.Name, o.OrderId
FROM CustomerData.Customers c
CROSS JOIN Sales.Orders O
             