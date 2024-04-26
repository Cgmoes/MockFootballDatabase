CREATE OR ALTER PROCEDURE League.CreateDefensiveStats
	@PlayerID INT,
	@Tackles INT,
	@Sacks INT,
	@Interceptions INT,
	@Fumbles INT,
	@TDs INT,
	@DefensiveID INT OUTPUT
AS
BEGIN
    MERGE INTO League.DefensivePlayerStats AS Target
    USING (VALUES (@PlayerID)) AS Source(PlayerID)
    ON Target.PlayerID = Source.PlayerID
    WHEN MATCHED THEN
        UPDATE SET
            Tackles = @Tackles,
            Sacks = @Sacks,
            Interceptions = @Interceptions,
            Fumbles = @Fumbles,
			TDs = @TDs
    WHEN NOT MATCHED THEN
        INSERT (PlayerID, Tackles, Sacks, Interceptions, Fumbles, TDs)
        VALUES (@PlayerID, @Tackles, @Sacks, @Interceptions, @Fumbles, @TDs);
SET @DefensiveID = SCOPE_IDENTITY()
END;