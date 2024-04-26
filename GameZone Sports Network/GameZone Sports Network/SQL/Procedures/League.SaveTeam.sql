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