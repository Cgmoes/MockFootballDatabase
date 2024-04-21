   IF OBJECT_ID(N'League.DefensiveGamePlayerStats') IS NULL
BEGIN
CREATE TABLE League.DefensiveGamePlayerStats
(
	GameID INT NOT NULL FOREIGN KEY
		REFERENCES League.Game(GameID),
	PlayerID INT NOT NULL FOREIGN KEY
		REFERENCES League.PlayerTeam(PlayerTeamID),
	Tackles INT NOT NULL,
	Sacks INT NOT NULL,
	Interceptions INT NOT NULL,
	Fumbles INT NOT NULL,
	TDs INT NOT NULL
);
END