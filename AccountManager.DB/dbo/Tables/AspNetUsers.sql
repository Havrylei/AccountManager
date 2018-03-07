CREATE TABLE [dbo].[AspNetUsers](
	[Name] [nvarchar](max) NULL,
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	GradeID INT NOT NULL FOREIGN KEY REFERENCES Grades(ID),
	RegistrationDate DATETIME NOT NULL,
	EnterDate DATETIME NOT NULL,
	BirthDate DATE NULL,
	Phone VARCHAR(255),
	CountryID INT FOREIGN KEY REFERENCES Countries(ID),
	City VARCHAR(255),
	Avatar VARCHAR(255),
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255),
	HideEmail BIT NOT NULL DEFAULT 0,
	HidePhone BIT NOT NULL DEFAULT 0,
	Immutable BIT DEFAULT 0
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]