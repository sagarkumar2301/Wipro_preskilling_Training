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