﻿CREATE TABLE Messages (
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY,
	Subject VARCHAR(255),
	Text TEXT NOT NULL,
	CreateDate DATETIME NOT NULL,
	ReciverID NVARCHAR(450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id),
	SenderID NVARCHAR(450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id)
)