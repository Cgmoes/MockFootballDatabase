IF OBJECT_ID(N'League.DefensivePlayerStats') IS NULL
BEGIN
	CREATE TABLE League.DefensivePlayerStats
	(
		DefensiveID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		PlayerID INT NULL FOREIGN KEY
			REFERENCES League.Player(PlayerID),
		Tackles INT NULL,
		Sacks INT NULL,
		Interceptions INT NULL,
		Fumbles INT NULL,
		TDs INT NULL
	)
END;