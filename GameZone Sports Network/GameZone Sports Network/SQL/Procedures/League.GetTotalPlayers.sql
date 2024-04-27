--Gets the total number of players for a certain team
CREATE OR ALTER PROCEDURE League.GetTotalPlayers
	@teamId INT
AS
BEGIN
SELECT t.TeamName, COUNT(p.PlayerID) AS TotalPlayers
FROM League.Player p
	INNER JOIN League.Team t ON t.TeamID = p.TeamID
WHERE p.TeamID = @teamId
GROUP BY t.TeamName
END;