   IF OBJECT_ID(N'League.Game') IS NULL
BEGIN
CREATE TABLE League.Game
(
	GameID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	HomeTeamID INT NOT NULL FOREIGN KEY
		REFERENCES League.Team(TeamID),
	AwayTeamID INT NOT NULL FOREIGN KEY
		REFERENCES League.Team(TeamID),
	GameWeek INT NOT NULL,
	Score INT NOT NULL,
);
END