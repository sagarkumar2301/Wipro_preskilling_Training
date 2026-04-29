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