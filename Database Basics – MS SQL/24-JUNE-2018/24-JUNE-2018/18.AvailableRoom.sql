CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT,@Date DATE,@People INT)
RETURNS NVARCHAR(200)
AS 
BEGIN
	DECLARE @isAvailable NVARCHAR(200)=(SELECT TOP(1)
												h.Id,
												r.Id,
												r.Beds,
												(r.Price+h.BaseRate)
												FROM Rooms As r
												JOIN Hotels AS h ON h.Id=r.HotelId
												JOIN Trips AS t ON t.RoomId=r.Id
												WHERE h.Id=@HotelId AND r.Beds>=@People AND (@Date BETWEEN t.ArrivalDate AND t.ReturnDate AND t.CancelDate IS NOt NULL)
												ORDER BY r.Price DESC

										)
	RETURN 'Room'
END