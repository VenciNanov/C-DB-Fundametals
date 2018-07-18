CREATE TRIGGER T_CancelTrip ON Trips
INSTEAD OF DELETE
AS
BEGIN 
	UPDATE Trips
	SET CancelDate=GETDATE()
	WHERE Id IN( SELECT Id FROM deleted
				WHERE CancelDate IS NULL)
	
END

DELETE FROM Trips
WHERE Id IN (48,49,50)