CREATE OR ALTER PROCEDURE League.GetTeamStatsByName
    @TeamName NVARCHAR(32)
AS
BEGIN
    SELECT 
        t.TeamID,
        t.TeamName,
        COUNT(p.PlayerID) AS TotalPlayers,
        AVG(p.Age) AS AverageAge,
		t.TeamCity,
		t.YearEstablished
    FROM 
        League.Team t
    INNER JOIN 
        League.Player p ON t.TeamID = p.TeamID
    WHERE 
        t.TeamName = @TeamName
    GROUP BY 
        t.TeamID, t.TeamName, t.TeamCity, t.YearEstablished;
END;