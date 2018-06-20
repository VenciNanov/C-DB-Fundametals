CREATE TRIGGER T_MoveTheTally
ON Orders
AFTER UPDATE
AS
	BEGIN
		DECLARE @newTotalMileage INT=(
			SELECT TotalMileage
			FROM inserted
		)
		DECLARE @vehicleId INT =(
			SELECT VehicleId
			FROM inserted
		)
		DEClARE @oldTotalMileage INT=(
			SELECT TotalMileage
			FROM deleted
		)
		IF(@oldTotalMileage IS NULL AND @vehicleId IS NOT NULL)
		BEGIN 
			UPDATE Vehicles
			SET Mileage +=@newTotalMileage
			WHERE Id=@vehicleId
		END
	END
