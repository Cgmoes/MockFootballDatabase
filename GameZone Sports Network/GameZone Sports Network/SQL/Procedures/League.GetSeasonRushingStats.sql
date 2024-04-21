CREATE PROCEDURE League.GetSeasonRushingStats
    @Week INT
AS
BEGIN
    WITH SeasonRushingStats AS (
        SELECT 
            P.PlayerName,
            OGPS.RushTDs,
            OGPS.RushYrds,
            DENSE_RANK() OVER (ORDER BY OGPS.RushTDs DESC, OGPS.RushYrds DESC) AS SeasonRank
        FROM 
            League.OffensiveGamePlayerStats AS OGPS
        INNER JOIN 
            League.PlayerTeam AS PT ON OGPS.PlayerID = PT.PlayerTeamID
        INNER JOIN 
            League.Player AS P ON PT.PlayerID = P.PlayerID
        WHERE 
            OGPS.[Week] <= @Week
    )
    SELECT 
        PlayerName,
        @Week AS Week,
        RushTDs,
        RushYrds,
        SeasonRank
    FROM 
        SeasonRushingStats
    ORDER BY 
        SeasonRank;
END;