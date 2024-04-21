CREATE OR ALTER PROCEDURE League.GetTotalPointsForEstablishedTeams
    @WeekStart INT,
    @WeekEnd INT,
    @DateEstablished INT
AS
BEGIN
    SELECT 
        T.TeamName,
        T.YearEstablished,
        AVG(G.Score) AS AveragePoints
    FROM 
        League.Team AS T
    INNER JOIN 
        League.Game AS G ON T.TeamID = G.HomeTeamID OR T.TeamID = G.AwayTeamID
    WHERE 
        T.YearEstablished < @DateEstablished
        AND G.GameWeek BETWEEN @WeekStart AND @WeekEnd
    GROUP BY 
        T.TeamID,
        T.TeamName,
        T.YearEstablished,
        G.GameWeek;
END;