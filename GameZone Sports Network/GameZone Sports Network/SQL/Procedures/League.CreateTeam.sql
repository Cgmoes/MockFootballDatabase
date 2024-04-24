CREATE OR ALTER PROCEDURE League.CreateTeam
   @TeamName NVARCHAR(32),
   @TeamCity NVARCHAR(32),
   @YearEstablished NVARCHAR(32)
AS

INSERT League.Team(TeamName, TeamCity, YearEstablished)
VALUES(@TeamName, @TeamCity, @YearEstablished);
GO