IF OBJECT_ID(N'League.Team') IS NULL
BEGIN
	CREATE TABLE League.Team
	(
		TeamID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		TeamName NVARCHAR(32) NOT NULL,
		TeamCity NVARCHAR(32) NOT NULL,
		YearEstablished INT NOT NULL,

		CHECK(TeamName > N'' OR TeamCity > N'')
	)
END;