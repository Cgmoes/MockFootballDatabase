CREATE OR ALTER PROCEDURE League.GetSpecialTeamsID
	@PlayerID INT
AS

SELECT *
FROM League.SpecialTeamsStats
WHERE PlayerID = @PlayerID;