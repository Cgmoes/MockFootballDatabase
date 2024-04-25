CREATE OR ALTER PROCEDURE League.CreateTeam
    @TeamName NVARCHAR(32),
    @TeamCity NVARCHAR(32),
    @YearEstablished INT,
    @TeamID INT OUTPUT
AS
BEGIN
    INSERT INTO League.Team (TeamName, TeamCity, YearEstablished)
    VALUES (@TeamName, @TeamCity, @YearEstablished)

    SET @TeamID = SCOPE_IDENTITY()
END