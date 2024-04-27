CREATE OR ALTER PROCEDURE League.GetTotalPlayers
	@teamId INT
AS

SELECT COUNT(p.PlayerID) AS TotalPlayers
FROM League.Player p
WHERE p.TeamID = @teamId