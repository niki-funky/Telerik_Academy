--01
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)

--02
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary <= 
  (SELECT MIN(Salary) FROM Employees)*1.1
Order by Salary

--03
SELECT e.FirstName, e.LastName, e.Salary, d.Name
FROM Employees e 
  JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = d.DepartmentID)
   Order by Salary

--04
SELECT AVG(Salary) as AVGSalary
   FROM Employees 
   WHERE DepartmentID = 1

--05
SELECT AVG(Salary) as AVGSalary
   FROM Employees e, Departments d
   WHERE e.DepartmentID = d.DepartmentID and d.Name = 'Sales'

--06
SELECT count(*)
   FROM Employees e, Departments d
   WHERE e.DepartmentID = d.DepartmentID and d.Name = 'Sales'

--07
SELECT count(*)
   FROM Employees
   WHERE ManagerID is not null

--08
SELECT count(*)
   FROM Employees
   WHERE ManagerID is null

--09
SELECT AVG(Salary) as AVGSalary, e.DepartmentID
   FROM Employees e, Departments d
   GROUP BY e.DepartmentID
   Order by e.DepartmentID

--10
SELECT COUNT(*) AS EmpCount, d.Name AS DeptName, t.Name as Town
	FROM Employees e, Departments d, Addresses a, Towns t
		where e.DepartmentID = d.DepartmentID
		and e.AddressID = a.AddressID
		and a.TownID = t.TownID
GROUP BY t.Name, d.Name
ORDER BY t.Name, d.Name

--11
SELECT e.FirstName, e.LastName, e.EmployeeID
FROM Employees e
WHERE 5 =
	(
		SELECT COUNT(*)
		FROM Employees
		WHERE ManagerID = e.EmployeeID
	)

--12
SELECT
  e.FirstName + ' ' + e.LastName EmployeeName,
  COALESCE (m.FirstName + ' ' + m.LastName, '(NO MANAGER)') ManagerName
FROM Employees e LEFT OUTER JOIN Employees m
  ON e.ManagerID = m.EmployeeID
  order by e.FirstName

--13
SELECT e.FirstName, e.LastName EmployeeName
FROM Employees e
WHERE LEN(e.LastName) = 5

--14
SELECT CAST(DATEPART(DD,GETDATE()) AS VARCHAR)+'.'
+CAST(DATEPART(MM,GETDATE()) AS VARCHAR)
+'.'+CAST(DATEPART(YYYY,GETDATE()) AS VARCHAR)
+' '+CAST(DATEPART(HH,GETDATE()) AS VARCHAR)
+':'+CAST(DATEPART(MI,GETDATE()) AS VARCHAR)
+':'+CAST(DATEPART(SS,GETDATE()) AS VARCHAR)
+':'+CAST(DATEPART(MS,GETDATE()) AS VARCHAR)

--15
CREATE TABLE Users (
  UserID int IDENTITY,
  UserName nvarchar(100) NOT NULL,
  Pass nvarchar(100) NOT NULL,
  FullName nvarchar(100) NOT NULL,
  LastLoginTime datetime,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CONSTRAINT UK_UserName UNIQUE (UserName),
  CONSTRAINT UK_Pass CHECK (LEN(Pass) >= 5),
)
GO

--16
CREATE VIEW DailyUsersLog AS
SELECT UserName
FROM Users
WHERE DATEDIFF(day, LastLoginTime, GETDATE()) = 0
GO

--17
CREATE TABLE Groups (
  GroupID int IDENTITY,
  Name nvarchar(100) NOT NULL,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
  CONSTRAINT UK_Name UNIQUE (Name)
)
GO

--18
ALTER TABLE Users
ADD GroupID int
 CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupID)
    REFERENCES Groups(GroupID)
GO

--19
INSERT INTO Users (UserName, Pass, FullName, LastLoginTime, GroupID)
VALUES ('asdd', '123456','dsadsa', '09.7.2013', 1)
INSERT INTO Users (UserName, Pass, FullName, LastLoginTime, GroupID)
VALUES ('assdd', '123s456','dsattdsa', '08.7.2013', 1)

INSERT INTO Groups (Name)
VALUES ('Lamers')
INSERT INTO Groups (Name)
VALUES ('Hackers')
GO

--20
UPDATE Users SET Pass = '12345678' WHERE UserID = 1
UPDATE Users SET Pass = '12345611' WHERE UserID = 2
GO

--21
DELETE FROM Users
WHERE UserID = 2

DELETE FROM Groups
WHERE GroupID = 1
GO

--22
INSERT INTO Users (UserName, Pass, FullName, GroupId)
SELECT LOWER(LEFT(e.FirstName, 3) + '.' + e.LastName) as Username,
           LOWER(LEFT(e.FirstName, 1) + '.' + e.LastName + '_pass') as Password,
           e.FirstName + ' ' + e.LastName as FullName,
           2 as GroupId
FROM Employees e
GO

--23
-- Write a SQL statement that changes the password to NULL for all users that have not been in the
-- system since 10.03.2010.
-- UPDATE Users SET LastLoginTime = '2008-03-10 00:00:00.000' WHERE LastLoginTime is NULL
UPDATE Users SET Pass = NULL WHERE LastLoginTime < '2010-03-10 00:00:00.000'
GO

--24
-- Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE Pass is NULL
GO

--25
SELECT e.JobTitle, AVG(Salary) AS [Average Salary],
       d.Name AS [Department Name]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name

--26
SELECT MIN(Salary) AS [Minimal Salary],
       e.JobTitle AS [Job Title],
       d.Name AS [Department Name],
       MIN(e.FirstName + ' ' + e.LastName) AS [FULL Name]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY d.Name, E.JobTitle

--27
SELECT TOP 1 t.Name AS [Town], COUNT(e.EmployeeID) AS [EmployeeCount]
FROM Employees e ,Addresses a, Towns t
 WHERE e.AddressID = a.AddressID
 AND t.TownID = a.TownID
GROUP BY t.Name
ORDER BY EmployeeCount DESC

--28
SELECT COUNT(*) AS [Managers COUNT], t.Name
FROM Employees e, Addresses a, Towns t
 WHERE e.AddressID = a.AddressID
 AND a.TownID = t.TownID
GROUP BY t.Name
ORDER BY t.Name

--29
CREATE TABLE WorkHours (
 EmployeeID INT IDENTITY,
 OnDate DATETIME,
 Task NVARCHAR(50),
 HoursWorked INT,
 Comments nvarchar(50)
 CONSTRAINT PK_EmployeeID PRIMARY KEY (EmployeeID)
 CONSTRAINT FK_EmployeeID FOREIGN KEY (EmployeeID)
  REFERENCES Employees (EmployeeID)
)
GO
 
INSERT INTO WorkHours
SELECT
 GETDATE() AS OnDate,
 'sometask1' AS Task,
 6 AS HoursWorked,
 'no comment' AS Comments
 
UPDATE WorkHours
 SET Task = 'no current task'
 WHERE Task = 'sometask1'


CREATE TABLE WorkHoursLogs
(
 NewEmployeeID int,
 NewOnDate datetime,
 NewTask nvarchar(50),
 NewHoursWorked int,
 NewComments nvarchar(50),
    CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(NewEmployeeID),
)
GO
 
CREATE TRIGGER tr_Update ON dbo.WorkHours FOR UPDATE
AS
 BEGIN
  INSERT INTO dbo.WorkHoursLogs(NewOnDate, NewTask, NewHoursWorked,NewComments)
  SELECT  i.OnDate ,
          i.Task,
          i.HoursWorked,
          i.Comments         
  FROM inserted i
 END
GO

-- for testing purposes
DROP TRIGGER tr_Update
GO
 
CREATE TRIGGER tr_Insert ON dbo.WorkHours FOR INSERT
AS
 BEGIN
  INSERT INTO dbo.WorkHoursLogs(NewOnDate, NewTask, NewHoursWorked,NewComments)
  SELECT  i.OnDate,
          i.Task,
          i.HoursWorked,
          i.Comments
  FROM inserted i
 END
GO

-- for testing purposes
DROP TRIGGER tr_Insert
GO
 
CREATE TRIGGER tr_Delete ON dbo.WorkHours FOR DELETE
AS
 BEGIN
  INSERT INTO dbo.WorkHoursLogs(NewOnDate, NewTask, NewHoursWorked,NewComments)
  SELECT  d.OnDate,
          d.Task,
          d.HoursWorked,
          d.Comments
  FROM deleted d
 END
GO

-- for testing purposes
DROP TRIGGER tr_Delete
GO

--30
BEGIN TRAN
 
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
 
DELETE FROM Employees
WHERE Employees.DepartmentID = (
        SELECT DepartmentID
        FROM Departments
        WHERE Departments.Name = 'Sales')
 
ROLLBACK TRAN

--31
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK

--32
CREATE TABLE #LocalTempTable(
        EmployeeID INT NOT NULL,
        ProjectID INT NOT NULL,
        CONSTRAINT PK_EmployeeesProjects PRIMARY KEY (EmployeeID, ProjectID),
)
GO

INSERT INTO #LocalTempTable
SELECT * FROM EmployeesProjects
 
DROP TABLE EmployeesProjects
 
CREATE TABLE EmployeesProjects(
 EmployeeID INT NOT NULL,
 ProjectID INT NOT NULL,
 CONSTRAINT PK_EmployeeesProjects PRIMARY KEY (EmployeeID, ProjectID),
 CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY (EmployeeID)
         REFERENCES Employees(EmployeeId),
 CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY (ProjectID)
         REFERENCES Projects(ProjectId)
)
GO
 
INSERT INTO EmployeesProjects
SELECT * FROM #LocalTempTable