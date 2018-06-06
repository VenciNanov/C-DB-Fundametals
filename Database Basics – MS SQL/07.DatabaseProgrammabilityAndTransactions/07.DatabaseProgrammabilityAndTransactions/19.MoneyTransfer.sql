CREATE PROC usp_TransferMoney(@SenderId INT,@ReciverId INT, @Amount DECIMAL(15,4))
AS
	BEGIN
	BEGIN TRANSACTION
		EXEC dbo.usp_WithdrawMoney @SenderId,@Amount
		EXEC dbo.usp_DepositMoney @ReciverId,@Amount
		IF((SELECT Balance
			FROM Accounts
			WHERE Accounts.Id = @SenderId) < 0)
		BEGIN
			ROLLBACK
		END
		ELSE
			BEGIN
				COMMIT
			END
	END