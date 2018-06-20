CREATE FUNCTION udf_CheckForVehicle(@townName VARCHAR(50),@seatsNumber INT)
RETURNS VARCHAR(50)
AS
BEGIN
			DECLARE @returnString VARCHAR(255) = (
													SELECT TOP (1) o.Name+' - '+m.Model
													FROM Towns AS t
														JOIN Offices AS o ON t.Id = o.TownId
														JOIN Vehicles AS v ON v.OfficeId=o.Id
														JOIN Models AS m ON m.Id=v.ModelId
													WHERE t.Name=@townName AND m.Seats=@seatsNumber
													GROUP BY o.Name,m.Model
													ORDER BY o.Name ASC
												)

			IF(@returnString IS NULL)
			BEGIN
				RETURN 'NO SUCH VEHICLE FOUND'
			END

			
RETURN @returnString
END