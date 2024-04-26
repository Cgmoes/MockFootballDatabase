CREATE OR ALTER PROCEDURE League.CreateResults
	@HomeTeam NVARCHAR(32),
    @WeekNumber INT,
    @TeamPlayed NVARCHAR(32),
    @PointsScored INT,
    @PointsAgainst INT
AS

INSERT League.Results(HomeTeam, WeekNumber, TeamPlayed, PointsScored, PointsAgainst)
VALUES(@HomeTeam, @WeekNumber, @TeamPlayed, @PointsScored, @PointsAgainst);
GO