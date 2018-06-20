UPDATE Jobs
SET Status ='In Progress',
MechanicId=
(SELECT TOP(1) MechanicId FROM Mechanics 
WHERE FirstName+' '+LastName='Ryan Harnos')
WHERE Status='Pending'