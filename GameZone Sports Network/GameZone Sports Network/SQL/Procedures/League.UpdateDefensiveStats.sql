CREATE OR ALTER PROCEDURE League.UpdateDefensiveStats
	@PlayerID INT,
	@Tackles INT,
	@Sacks INT,
	@Interceptions INT,
	@Fumbles INT,
	@TDs INT
AS

UPDATE League.DefensivePlayerStats
SET Tackles = @Tackles,
	Sacks = @Sacks,
	Interceptions = @Interceptions,
	Fumbles = @Fumbles,
	TDs = @TDs
WHERE PlayerID = @PlayerID