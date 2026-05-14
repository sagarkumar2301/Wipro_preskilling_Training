CREATE DATABASE HospitalManagementSystem;
GO

USE HospitalManagementSystem;
GO

CREATE TABLE Department
(
DepartmentID INT PRIMARY KEY IDENTITY(1,1),
DepartmentName VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE Doctor
(
DoctorID INT PRIMARY KEY IDENTITY(1,1),
DoctorName VARCHAR(100) NOT NULL,
Specialization VARCHAR(100) NOT NULL,
Phone VARCHAR(15) UNIQUE,
Salary DECIMAL(10,2) CHECK(Salary > 0),
DepartmentID INT,
FOREIGN KEY (DepartmentID)
REFERENCES Department(DepartmentID)
);
GO

CREATE TABLE Patient
(
PatientID INT PRIMARY KEY IDENTITY(1,1),
FullName VARCHAR(100) NOT NULL,
Gender VARCHAR(10) CHECK(Gender IN ('Male','Female')),
DOB DATE,
Phone VARCHAR(15) UNIQUE,
Address VARCHAR(200),
BloodGroup VARCHAR(5)
);
GO

CREATE TABLE Appointment
(
AppointmentID INT PRIMARY KEY IDENTITY(1,1),
PatientID INT NOT NULL,
DoctorID INT NOT NULL,
AppointmentDate DATETIME NOT NULL,
Status VARCHAR(20) DEFAULT 'Pending',
FOREIGN KEY (PatientID)
REFERENCES Patient(PatientID),
FOREIGN KEY (DoctorID)
REFERENCES Doctor(DoctorID)
);
GO

CREATE TABLE Treatment
(
TreatmentID INT PRIMARY KEY IDENTITY(1,1),
AppointmentID INT UNIQUE,
Diagnosis VARCHAR(200),
Prescription VARCHAR(300),
TreatmentCost DECIMAL(10,2),
FOREIGN KEY (AppointmentID)
REFERENCES Appointment(AppointmentID)
);
GO

CREATE TABLE Billing
(
BillID INT PRIMARY KEY IDENTITY(1,1),
PatientID INT,
Amount DECIMAL(10,2),
PaymentStatus VARCHAR(20),
BillDate DATE,
FOREIGN KEY (PatientID)
REFERENCES Patient(PatientID)
);
GO

INSERT INTO Department(DepartmentName)
VALUES
('Cardiology'),
('Neurology'),
('Orthopedics');

INSERT INTO Doctor
(DoctorName, Specialization, Phone, Salary, DepartmentID)
VALUES
('Dr. Sharma', 'Heart Specialist', '9876543210', 90000, 1),
('Dr. Singh', 'Brain Specialist', '9876543211', 85000, 2),
('Dr. Roy', 'Bone Specialist', '9876543212', 80000, 3);

INSERT INTO Patient
(FullName, Gender, DOB, Phone, Address, BloodGroup)
VALUES
('Rahul Kumar', 'Male', '2000-05-12', '9991111111', 'Ranchi', 'B+'),
('Anjali Devi', 'Female', '1999-08-20', '9992222222', 'Jamshedpur', 'A+');

INSERT INTO Appointment
(PatientID, DoctorID, AppointmentDate, Status)
VALUES
(1, 1, '2026-05-20 10:00:00', 'Confirmed'),
(2, 2, '2026-05-21 11:30:00', 'Pending');

INSERT INTO Treatment
(AppointmentID, Diagnosis, Prescription, TreatmentCost)
VALUES
(1, 'Heart Pain', 'Medicine A', 5000),
(2, 'Migraine', 'Medicine B', 3000);

--performing DML operations
UPDATE Patient
SET Address = 'Bokaro'
WHERE PatientID = 1;

DELETE FROM Treatment
WHERE TreatmentID = 2;

DELETE FROM Appointment
WHERE AppointmentID = 2;

--simple select query
SELECT * FROM Patient;

SELECT * FROM Doctor;

SELECT * FROM Appointment;

SELECT * FROM Treatment;

--where clause query
SELECT *
FROM Doctor
WHERE Salary > 85000;

--GROUP BY Query
SELECT DepartmentID, COUNT(*) AS TotalDoctors
FROM Doctor
GROUP BY DepartmentID;

--HAVING Clause Query
SELECT DepartmentID, COUNT(*) AS TotalDoctors
FROM Doctor
GROUP BY DepartmentID
HAVING COUNT(*) >= 1;

--INNER JOIN Query
SELECT
p.FullName,
d.DoctorName,
a.AppointmentDate
FROM Appointment a
INNER JOIN Patient p
ON a.PatientID = p.PatientID
INNER JOIN Doctor d
ON a.DoctorID = d.DoctorID;

--LEFT JOIN Query
SELECT
p.FullName,
a.AppointmentID
FROM Patient p
LEFT JOIN Appointment a
ON p.PatientID = a.PatientID;

--RIGHT JOIN Query
SELECT
d.DoctorName,
a.AppointmentID
FROM Appointment a
RIGHT JOIN Doctor d
ON a.DoctorID = d.DoctorID;

-- FULL JOIN Query
SELECT
p.FullName,
a.AppointmentID
FROM Patient p
FULL JOIN Appointment a
ON p.PatientID = a.PatientID;

--Subquery Example
SELECT DoctorName, Salary
FROM Doctor
WHERE Salary >
(
SELECT AVG(Salary)
FROM Doctor
);
GO

-- Create View
CREATE VIEW vw_PatientAppointments
AS
SELECT
p.FullName,
d.DoctorName,
a.AppointmentDate,
a.Status
FROM Appointment a
INNER JOIN Patient p
ON a.PatientID = p.PatientID
INNER JOIN Doctor d
ON a.DoctorID = d.DoctorID;
GO

--Execute View
SELECT * FROM vw_PatientAppointments;

--Create Index
CREATE INDEX idx_patient_name
ON Patient(FullName);
GO

--Create Scalar Function
CREATE FUNCTION fn_GetPatientAge
(
@DOB DATE
)
RETURNS INT
AS
BEGIN
RETURN DATEDIFF(YEAR, @DOB, GETDATE())
END;
GO

--Execute Function
SELECT
FullName,
dbo.fn_GetPatientAge(DOB) AS Age
FROM Patient;
GO

--Create Trigger
CREATE TRIGGER trg_GenerateBill
ON Treatment
AFTER INSERT
AS
BEGIN
INSERT INTO Billing
(
PatientID,
Amount,
PaymentStatus,
BillDate
)
SELECT
a.PatientID,
i.TreatmentCost,
'Pending',
GETDATE()
FROM inserted i
INNER JOIN Appointment a
ON i.AppointmentID = a.AppointmentID
END;

--Test Trigger
INSERT INTO Treatment
(AppointmentID, Diagnosis, Prescription, TreatmentCost)
VALUES
(3, 'Chest Infection', 'Medicine C', 7000);

--Check Billing Table
SELECT * FROM Billing;

--Transaction Control Language (TCL)
--COMMIT Example
BEGIN TRANSACTION
UPDATE Billing
SET PaymentStatus = 'Paid'
WHERE BillID = 1;
COMMIT;

--ROLLBACK Example
BEGIN TRANSACTION
UPDATE Billing
SET Amount = 99999
WHERE BillID = 1;
ROLLBACK;

--DCL Commands
--Create User
CREATE LOGIN Receptionist
WITH PASSWORD = 'Reception@123';
GO

CREATE USER Receptionist
FOR LOGIN Receptionist;
GO

--Grant Permission
GRANT SELECT, INSERT
ON Patient
TO Receptionist;

--Revoke Permission
REVOKE INSERT
ON Patient
FROM Receptionist;

-- Complex Queries for Final Demonstration
--Total Patients
SELECT COUNT(*) AS TotalPatients
FROM Patient;

-- Department Wise Doctor Count
SELECT
dep.DepartmentName,
COUNT(doc.DoctorID) AS DoctorCount
FROM Department dep
INNER JOIN Doctor doc
ON dep.DepartmentID = doc.DepartmentID
GROUP BY dep.DepartmentName;

--Patient Treatment Report
SELECT
p.FullName,
t.Diagnosis,
t.Prescription,
t.TreatmentCost
FROM Treatment t
INNER JOIN Appointment a
ON t.AppointmentID = a.AppointmentID
INNER JOIN Patient p
ON a.PatientID = p.PatientID;

--Total Revenue
SELECT SUM(Amount) AS TotalRevenue
FROM Billing;

--Pending Payments
SELECT *
FROM Billing
WHERE PaymentStatus = 'Pending';

