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
	@RushTouchdowns INT,
	@Fumbles INT,
	@OffensiveTeamID INT OUTPUT
AS
BEGIN
    MERGE INTO League.OffensivePlayerStats AS Target
    USING (VALUES (@PlayerID)) AS Source(PlayerID)
    ON Target.PlayerID = Source.PlayerID
    WHEN MATCHED THEN
        UPDATE SET
            PassAttempts = @PassAttempts,
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
    WHEN NOT MATCHED THEN
        INSERT (PlayerID, PassAttempts, PassCompletions, PassYards, PassTD, Ints, RushYrds, RushAttempts, Receptions, RecievingYrds, RushTD, Fumbles)
        VALUES (@PlayerID, @PassAttempts, @PassCompletions, @PassYards, @PassTD, @Ints, @RushYrds, @RushAttempts, @Receptions, @RecievingYrds, @RushTouchdowns, @Fumbles);
SET @OffensiveTeamID = SCOPE_IDENTITY()
END;