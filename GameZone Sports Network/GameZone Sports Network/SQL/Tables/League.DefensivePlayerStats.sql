IF OBJECT_ID(N'League.DefensivePlayerStats') IS NULL
BEGIN
	CREATE TABLE League.DefensivePlayerStats
	(
		OffensiveID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		PlayerID INT NOT NULL FOREIGN KEY
			REFERENCES League.Player(PlayerID),
		Tackles INT NOT NULL,
		Sacks INT NOT NULL,
		Interceptions INT NOT NULL,
		Fumbles INT NOT NULL,
		TDs INT NOT NULL
	)
END;