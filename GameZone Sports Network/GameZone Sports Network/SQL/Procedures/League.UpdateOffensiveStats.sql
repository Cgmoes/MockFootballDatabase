CREATE OR ALTER PROCEDURE League.UpdateOffensiveStats
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
	@RushTouchdowns INT,
	@Fumbles INT
AS

UPDATE League.OffensivePlayerStats
SET PassAttempts = @PassAttempts,
	PassCompletions = @PassCompletions,
	PassYards = @PassYards,
	PassTD = @PassTD,
	Ints = @Ints,
	RushYrds = @RushYrds,
	RushAttempts = @RushAttempts,
	Receptions = @Receptions,
	RecievingYrds = @RecievingYrds,
	RushTD = @RushTouchdowns,
	Fumbles = @Fumbles
WHERE PlayerID = @PlayerID