SELECT DISTINCT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand] FROM WizzardDeposits
GROUP BY [DepositGroup]