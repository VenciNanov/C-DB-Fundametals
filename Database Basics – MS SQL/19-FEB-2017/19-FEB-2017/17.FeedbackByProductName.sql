CREATE FUNCTION udf_GetRating(@productName NVARCHAR(25))
RETURNS VARCHAR(9)
AS
	BEGIN
		DECLARE @productRate DECIMAL(4,2) = 
		(
			SELECT AVG(f.Rate)
			FROM Products AS p
			JOIN Feedbacks AS f ON f.ProductId=p.Id
			WHERE p.Name = @productName
		);
		IF(@productRate IS NULL)
			BEGIN
				RETURN 'No rating';
			END;
		IF(@productRate <5)
			BEGIN
				RETURN 'Bad';
			END;
		IF(@productRate<=8)
			BEGIN
				RETURN 'Average';
			END;
		RETURN 'Good';
	END;