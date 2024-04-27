CREATE OR ALTER PROCEDURE League.SaveTeam
	@TeamID INT,
    @TeamName NVARCHAR(32),
    @TeamCity NVARCHAR(32),
	@YearEstablished INT
AS

UPDATE League.Team
SET TeamCity = @TeamCity,
	TeamName = @TeamName,
	YearEstablished = @YearEstablished
WHERE TeamID = @TeamID;

UPDATE League.Results
    SET HomeTeam = @TeamName
    WHERE HomeTeam = (SELECT TeamName FROM League.Team WHERE TeamID = @TeamID);

UPDATE League.Results
SET TeamPlayed = @TeamName
WHERE TeamPlayed = (SELECT TeamName FROM League.Team WHERE TeamID = @TeamID);