SELECT r.OpenDate,r.Description,u.Email AS [Reporter Email] FROM Reports AS r
JOIN Users AS u ON u.Id=r.UserId
JOIN Categories AS c ON c.Id=r.CategoryId
JOIN Departments AS d ON d.Id = c.DepartmentId
WHERE r.CloseDate IS NULL AND (LEN(r.Description)>20 AND Description LIKE '%str%') AND( d.Name = 'Infrastructure'OR d.Name='Emergency'OR d.Name='Roads Maintenance')
ORDER BY OpenDate ASC,[Reporter Email]ASC,u.Id ASC