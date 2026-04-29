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