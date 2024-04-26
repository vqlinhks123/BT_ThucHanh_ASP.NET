CREATE DATABASE VUQUANGLINH_BT_BUOI11

-- BÀI TẬP 1
CREATE TABLE Employees 
(
	EmployeeID int NOT NULL,
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	Position nvarchar(30) NOT NULL,
	DepartmentID int NOT NULL,
	Salary decimal(10,2) NOT NULL
)

INSERT INTO Employees (EmployeeID, FirstName, LastName, Position, DepartmentID, Salary)
VALUES (100, N'Linh', N'Vũ Quang', N'Thực tập sinh', 1, 2000000),
	   (101, N'Nhật', N'Huỳnh Phan Minh', N'Trưởng nhóm', 1, 15000000),
	   (102, N'Trung', N'Nguyễn Văn', N'Nhân viên hành chính', 1, 12000000),
	   (103, N'Tuấn', N'Lê', N'Nhân viên', 2, 12000000),
	   (104, N'Sang', N'Nguyễn', N'Nhân viên', 3, 1000000)

SELECT * FROM Employees

-- BÀI TẬP 2
CREATE TABLE Departments
(
	DepartmentID int NOT NULL,
	DepartmentName nvarchar(30) NOT NULL,
)

INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES (1, N'ONOC'),
	   (2, N'INOC'),
	   (3, N'TNOC')

SELECT * FROM Departments

SELECT e.FirstName, e.LastName, d.DepartmentName FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID

-- BÀI TẬP 3
SELECT D.DepartmentName, SUM(e.Salary) AS TotalSalary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentName
ORDER BY TotalSalary DESC;

