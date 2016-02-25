SELECT t.ManagerID, e.FirstName 
FROM Teams t
JOIN Employees e
ON t.ManagerID=e.EmployeeID

SELECT c.FirstName, c.LastName, d.Name
FROM Teams a INNER JOIN
	TeamEmployee b ON a.TeamID = b.TeamID INNER JOIN
	Employees c ON b.EmployeeID = c.EmployeeID INNER JOIN
	JobPositions d ON c.JobPositionID = d.JobPositionID
WHERE b.TeamID = 1

