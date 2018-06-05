SELECT DISTINCT [DepositGroup],SUM([DepositAmount]) AS [TotalSum] FROM WizzardDeposits
GROUP BY DepositGroup