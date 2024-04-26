CREATE OR ALTER PROCEDURE League.GetPlayerByTeam
	@teamId INT
AS

SELECT *
FROM League.Player p
WHERE p.TeamID = @teamId