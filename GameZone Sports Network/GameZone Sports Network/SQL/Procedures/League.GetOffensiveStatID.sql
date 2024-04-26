CREATE OR ALTER PROCEDURE League.GetOffensiveStatID
	@PlayerID INT
AS

SELECT *
FROM League.OffensivePlayerStats
WHERE PlayerID = @PlayerID;