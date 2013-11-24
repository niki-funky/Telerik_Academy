--04
SELECT * FROM Departments

--05
SELECT Name FROM Departments

--06
SELECT LastName, Salary 
FROM Employees
ORDER BY LastName

--07
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
FROM Employees
ORDER BY FirstName

--08
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees
ORDER BY FirstName

--09
SELECT DISTINCT Salary 
FROM Employees
ORDER BY Salary

--10
SELECT * FROM Employees e
WHERE e.JobTitle = 'Sales Representative'

--11
SELECT  FirstName + ' ' + LastName AS [Full Name] 
From Employees e
WHERE e.FirstName like 'SA%';

--12
SELECT LastName
From Employees e
WHERE e.LastName like '%ei%';

--13
SELECT Salary 
FROM Employees e
Where e.Salary BETWEEN 20000 AND 30000
ORDER BY Salary

--14
SELECT LastName 
FROM Employees e
Where e.Salary=12500  OR e.Salary=14000
OR e.Salary=23600  OR e.Salary=25000
ORDER BY LastName

--15
SELECT LastName 
FROM Employees e
Where e.ManagerID IS NULL
ORDER BY LastName

--16
SELECT LastName, Salary
FROM Employees e
Where e.Salary>50000
ORDER BY Salary DESC

--17
select TOP 5 LastName, Salary 
FROM Employees 
ORDER BY Salary DESC

--18
SELECT e.FirstName, e.LastName, t.Name as Town, a.AddressText
FROM Employees e
  JOIN Addresses a
    ON e.AddressID = a.AddressID
  JOIN Towns t
    ON a.TownID = t.TownID
Order by FirstName

--19
SELECT e.FirstName, e.LastName, t.Name as Town, a.AddressText
FROM Employees e, Addresses a, Towns t
where e.AddressID = a.AddressID
and a.TownID = t.TownID
Order by FirstName

--20
SELECT e.FirstName + ' ' + e.LastName +
 ' is managed by ' + m.LastName as Message
FROM Employees e JOIN Employees m
ON (e.ManagerId = m.EmployeeId)
Order by e.FirstName

--21
SELECT e.FirstName, e.LastName, a.AddressText, t.Name, m.FirstName + ' ' + m.LastName as [Managed by]
FROM Employees e
	JOIN Employees m 
		ON e.ManagerId = m.EmployeeId
	JOIN Addresses a
		ON a.AddressID = e.AddressID
	JOIN Towns t
		ON t.TownID = a.TownID
Order by e.FirstName

--21
SELECT e.FirstName + ' ' + e.LastName +
 ' is managed by ' + m.LastName as [Employees and Managers], t.Name as Town, a.AddressText
FROM Employees e 
JOIN Employees m
 ON (e.ManagerId = m.EmployeeId)
  JOIN Addresses a
    ON e.AddressID = a.AddressID
  JOIN Towns t
    ON a.TownID = t.TownID
Order by e.FirstName

--22
SELECT d.Name, 'Department' as [Town/Department]
FROM Departments d
UNION
SELECT t.Name,'Town' as [Town/Department]
FROM Towns t
ORDER BY [Town/Department]

--23A
SELECT
  e.FirstName + ' ' + e.LastName EmployeeName,
  m.FirstName + ' ' + m.LastName ManagerName
FROM Employees e RIGHT OUTER JOIN Employees m
  ON m.ManagerID = e.EmployeeID
  order by e.FirstName

--23B
SELECT
  e.FirstName + ' ' + e.LastName EmployeeName,
  m.FirstName + ' ' + m.LastName ManagerName
FROM Employees e LEFT OUTER JOIN Employees m
  ON e.ManagerID = m.EmployeeID
  order by e.FirstName

--24
select e.LastName, e.HireDate, d.Name as Department
from Employees e, Departments d
where e.DepartmentID = d.DepartmentID
and (d.Name = 'Sales' 
	or d.Name = 'Finance')
and e.HireDate BETWEEN '1995' AND '2005'