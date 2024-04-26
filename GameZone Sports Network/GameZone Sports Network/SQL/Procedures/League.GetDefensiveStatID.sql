CREATE OR ALTER PROCEDURE League.GetDefensiveStatID
	@PlayerID INT
AS

SELECT *
FROM League.DefensivePlayerStats
WHERE PlayerID = @PlayerID;