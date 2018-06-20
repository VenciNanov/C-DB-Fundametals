CREATE PROC usp_MoveVehicle(@vehicleId INT,@officeId INT)
AS
BEGIN
	BEGIN TRANSACTION
	DECLARE @officePlaces INT=(
		SELECT ParkingPlaces
		FROM Offices
		WHERE Id=@officeId
	)
	DECLARE @currentPlaces INT=(
		SELECT COUNT(v.OfficeId)
		FROM Vehicles AS v
		JOIN Offices AS o ON o.Id=v.OfficeId
		WHERE o.Id=@officeId
		GROUP BY o.Name
	)

	IF(@officePlaces IS NULL OR @currentPlaces IS NULL OR @currentPlaces>=@officePlaces)
	BEGIN
		ROLLBACK;
		RAISERROR ('Not enough room in this office!',16,1);
	END;
	
	UPDATE Vehicles
	SET OfficeId = @officeId
	WHERE Id=@vehicleId

	COMMIT;
END