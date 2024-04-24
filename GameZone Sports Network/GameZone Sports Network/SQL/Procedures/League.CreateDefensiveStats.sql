CREATE OR ALTER PROCEDURE League.CreateDefensiveStats
	@PlayerID INT,
	@Tackles INT,
	@Sacks INT,
	@Interceptions INT,
	@Fumbles INT,
	@TDs INT
AS

INSERT League.DefensivePlayerStats(PlayerID, Tackles, Sacks, Interceptions, Fumbles, TDs)
VALUES(@PlayerID, @Tackles, @Sacks, @Interceptions, @Fumbles, @TDs);
GO