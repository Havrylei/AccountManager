﻿CREATE TABLE Grades (
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(255) NOT NULL,
	Immutable BIT NOT NULL DEFAULT 0	
)