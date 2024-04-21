CREATE PROCEDURE League.RankTeamsByMarginOfVictory
    @Week INT
AS
BEGIN
    WITH MarginOfVictory AS (
        SELECT 
            CASE
                WHEN G.Score - G2.Score >= 14 THEN 'Win'
                WHEN G2.Score - G.Score >= 14 THEN 'Loss'
                ELSE NULL
            END AS Result,
            CASE
                WHEN G.Score - G2.Score >= 14 THEN G.Score - G2.Score
                WHEN G2.Score - G.Score >= 14 THEN G2.Score - G.Score
                ELSE NULL
            END AS MarginOfVictory,
            CASE
                WHEN G.Score - G2.Score >= 14 THEN G.HomeTeamID
                WHEN G2.Score - G.Score >= 14 THEN G.AwayTeamID
                ELSE NULL
            END AS TeamID
        FROM 
            League.Game AS G
        INNER JOIN 
            League.Game AS G2 ON G.GameID = G2.GameID AND G.GameWeek = G2.GameWeek
        WHERE 
            G.GameWeek = @Week
    )
    SELECT 
        T.TeamName,
        @Week AS Week,
        MOV.MarginOfVictory,
        DENSE_RANK() OVER (ORDER BY MOV.MarginOfVictory DESC) AS RankOfMargin
    FROM 
        MarginOfVictory AS MOV
    INNER JOIN 
        League.Team AS T ON MOV.TeamID = T.TeamID
    WHERE 
        MOV.Result = 'Win'
    ORDER BY 
        RankOfMargin;
END;