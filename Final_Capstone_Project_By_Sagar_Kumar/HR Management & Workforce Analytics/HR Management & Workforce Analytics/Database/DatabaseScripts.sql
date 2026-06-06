CREATE DATABASE HRManagementDB;
GO

USE HRManagementDB;
GO

CREATE TABLE Employees
(
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    Department NVARCHAR(50),
    Designation NVARCHAR(50),
    JoiningDate DATETIME,
    IsActive BIT
);
GO

CREATE TABLE LeaveRequests
(
    LeaveRequestId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT,
    LeaveType NVARCHAR(50),
    StartDate DATETIME,
    EndDate DATETIME,
    Reason NVARCHAR(200),
    Status NVARCHAR(50)
);
GO

CREATE TABLE AuditLogs
(
    AuditLogId INT IDENTITY(1,1) PRIMARY KEY,
    ActionPerformed NVARCHAR(200),
    UserName NVARCHAR(100),
    CreatedDate DATETIME
);
GO

CREATE TRIGGER trg_EmployeeInsert
ON Employees
AFTER INSERT
AS
BEGIN
    PRINT 'Employee Added';
END
GO