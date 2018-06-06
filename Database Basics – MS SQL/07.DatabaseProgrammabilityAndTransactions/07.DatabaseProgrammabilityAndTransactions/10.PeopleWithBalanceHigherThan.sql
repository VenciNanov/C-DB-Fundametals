CREATE PROC usp_GetHoldersWithBalanceHigherThan (@balanceMinLevel DECIMAL(16,2))
	AS
		SELECT ah.FirstName,ah.LastName
			FROM AccountHolders AS ah
			JOIN Accounts AS a ON a.AccountHolderId=ah.Id
		GROUP BY ah.FirstName,ah.LastName
		HAVING SUM(a.Balance)>=@balanceMinLevel