CREATE OR ALTER PROCEDURE League.CreateResults
   @WeekNumber INT,
   @TeamPlayed NVARCHAR(32),
   @PointsScored INT,
   @PointsAgainst INT
AS

INSERT League.Results(WeekNumber, TeamPlayed, PointsScored, PointsAgainst)
VALUES(@WeekNumber, @TeamPlayed, @PointsScored, @PointsAgainst);
GO