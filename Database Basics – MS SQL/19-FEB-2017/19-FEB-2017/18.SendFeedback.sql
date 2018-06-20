CREATE PROC usp_SendFeedback
(
	@customerId INT,
	@productId INT,
	@rate DECIMAL (4,2),
	@description NVARCHAR(255)
)
AS
	BEGIN
		DECLARE @fbFromCustomerForThisProduct INT=
		(
			SELECT COUNT(*)
			FROM Feedbacks
			WHERE CustomerId=@customerId
		);
		IF(@fbFromCustomerForThisProduct >= 3)
             BEGIN
                 RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1);
         END;
INSERT INTO Feedbacks(CustomerId,
                               ProductId,
                               Rate,
                               Description
                              )
         VALUES
         (
                @customerId,
                @productId,
                @rate,
                @description
         );
     END;