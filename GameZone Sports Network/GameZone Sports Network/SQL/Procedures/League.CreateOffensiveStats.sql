CREATE OR ALTER PROCEDURE League.CreateOffensiveStats
	@PlayerID INT,
	@PassAttempts INT,
	@PassCompletions INT,
	@PassYards INT,
	@PassTD INT,
	@Ints INT,
	@RushYrds INT,
	@RushAttempts INT,
	@Receptions INT,
	@RecievingYrds INT,
	@Touchdowns INT,
	@Fumbles INT
AS

INSERT League.OffensivePlayerStats(PlayerID, PassAttempts, PassCompletions, PassYards, PassTD, Ints, RushYrds, RushAttempts, Receptions, RecievingYrds, Touchdowns, Fumbles)
VALUES(@PlayerID, @PassAttempts, @PassCompletions, @PassYards, @PassTD, @Ints, @RushYrds, @RushAttempts, @Receptions, @RecievingYrds, @Touchdowns, @Fumbles);
GO