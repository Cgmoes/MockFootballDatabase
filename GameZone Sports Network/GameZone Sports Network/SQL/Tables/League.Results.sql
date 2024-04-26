IF OBJECT_ID(N'League.Results') IS NULL
BEGIN
	CREATE TABLE League.Results
	(
		ResultID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		HomeTeam NVARCHAR(32) NOT NULL,
		WeekNumber INT NOT NULL,
		TeamPlayed NVARCHAR(32) NOT NULL,
		PointsScored INT NOT NULL,
		PointsAgainst INT NOT NULL,

		CHECK(TeamPlayed > N'' )
	)
END;