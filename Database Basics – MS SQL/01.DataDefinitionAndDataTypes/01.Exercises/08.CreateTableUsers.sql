CREATE TABLE Users(
	Id INT IDENTITY (1,1) UNIQUE,
	Username VARCHAR (30) NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY CHECK(DATALENGTH(ProfilePicture)<900*1024),
	LastLoginTime DATE,
	IsDeleted NVARCHAR(5) NOT NULL CHECK(IsDeleted='true' or IsDeleted='false')
)

INSERT INTO Users(Username,Password,ProfilePicture,LastLoginTime,IsDeleted)
VALUES
('Gosho','Peshev',35,NULL,'true'),
('Pesho','Peshev',25,NULL,'false'),
('Stamat','12345',15,NULL,'true'),
('Mariq','423536',65,NULL,'false'),
('Kiro','14g2g221c123',75,NULL,'true')

ALTER TABLE Users
ADD CONSTRAINT PK_Users Primary KEY(Id,Username);

ALTER TABLE Users
ADD CONSTRAINT Password CHECK(LEN(Password)>=5);

ALTER TABLE Users DROP CONSTRAINT PK_Users;

ALTER TABLE Users
ADD CONSTRAINT PK_Person PRIMARY KEY(Id);

ALTER TABLE Users
ADD CONSTRAINT UC_Users UNIQUE(Username);

ALTER TABLE Users
ADD CONSTRAINT CHK_Users CHECK(LEN(Password) >= 3);
