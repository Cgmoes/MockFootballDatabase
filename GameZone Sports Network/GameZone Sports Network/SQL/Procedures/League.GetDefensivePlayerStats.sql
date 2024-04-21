CREATE PROCEDURE League.GetDefensivePlayerStats
    @Week INT
AS
BEGIN
    SELECT TOP 10
        P.PlayerName,
        DGP.[Week],
        DGP.Tackles,
        DENSE_RANK() OVER (ORDER BY DGP.Tackles DESC) AS DefenseRank
    FROM
        League.DefensiveGamePlayerStats AS DGP
    INNER JOIN
        League.PlayerTeam AS PT ON DGP.PlayerID = PT.PlayerTeamID
    INNER JOIN
        League.Player AS P ON PT.PlayerID = P.PlayerID
    WHERE
        DGP.[Week] = @Week
    ORDER BY
        DGP.Tackles DESC;
END;
