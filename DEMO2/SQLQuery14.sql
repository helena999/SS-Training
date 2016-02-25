SELECT Name FROM TeamProjects

SELECT e.FirstName, e.LastName, j.Name
FROM Employees e
JOIN JobPositions j
ON e.JobPositionID = j.JobPositionID


SELECT tp.Name, e.FirstName, e.LastName
FROM TeamProjects tp
JOIN Employees e
ON tp.ProjectID = e.ProjectID

SELECT tp.ManagerID, e.FirstName
FROM TeamProjects tp
JOIN Employees e
ON tp.ProjectID = e.ProjectID


SELECT FirstName, LastName, ManagerID
FROM Employees

SELECT
  e.FirstName EmpFirstName,
  m.EmployeeID MgrID, m.FirstName MgrFirstName
FROM Employees e INNER JOIN Employees m
  ON e.ManagerID = m.EmployeeID
