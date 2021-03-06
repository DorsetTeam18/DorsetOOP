USE [VirtualCollege]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/6/2020 11:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [nvarchar](max) NOT NULL,
	[AddressLine2] [nvarchar](max) NULL,
	[Postcode] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/6/2020 11:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Credits] [decimal](18, 2) NOT NULL,
	[ReferentTeacherId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 12/6/2020 11:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[ExamName] [nvarchar](max) NOT NULL,
	[Mark] [decimal](18, 2) NOT NULL,
	[Coefficient] [decimal](18, 2) NOT NULL,
	[CourseId] [int] NULL,
	[StudentId] [int] NULL,
 CONSTRAINT [PK_dbo.Grades] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 12/6/2020 11:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[LessonId] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](max) NOT NULL,
	[Day] [nvarchar](max) NOT NULL,
	[Hour] [nvarchar](max) NOT NULL,
	[Duration] [nvarchar](max) NOT NULL,
	[CourseId] [int] NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_dbo.Lessons] PRIMARY KEY CLUSTERED 
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/6/2020 11:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[StudentId] [int] NULL,
 CONSTRAINT [PK_dbo.Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PresentStudentLessons]    Script Date: 12/6/2020 11:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PresentStudentLessons](
	[LessonId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PresentStudentLessons] PRIMARY KEY CLUSTERED 
(
	[LessonId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentLessons]    Script Date: 12/6/2020 11:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentLessons](
	[LessonId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.StudentLessons] PRIMARY KEY CLUSTERED 
(
	[LessonId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherCourses]    Script Date: 12/6/2020 11:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherCourses](
	[CourseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TeacherCourses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/6/2020 11:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[EmailAddress] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[BirthDate] [date] NOT NULL,
	[AddressId] [int] NULL,
	[Fees] [decimal](18, 2) NULL,
	[Paid] [decimal](18, 2) NULL,
	[TutorId] [int] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (1, N'31 bvd Troussel', N'Building A, M08', N'78700', N'Conflans', N'Yvelines', N'France')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (2, N'406-538 Facilisi. Ave', NULL, N'19076', N'Chalon-sur-Saône', N'Bourgogne', N'France')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (3, N'7785 Tempor Ave', NULL, N'18995', N'Ajaccio', N'Corse', N'France')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (4, N'466-9492 Aliquam St.', NULL, N'52044', N'Montigny-lès-Metz', N'Lorraine', N'France')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (5, N'Ap #459-2768 Eu Ave', NULL, N'22096', N'Châtellerault', N'Poitou-Charentes', N'France')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (6, N'7736 Magnis Rd.', NULL, N'14244', N'Ajaccio', N'Corse', N'France')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (7, N'Ap #705-5763 Turpis Rd.', NULL, N'77597', N'Grasse', N'Provence-Alpes-Côte d''Azur', N'France')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (9, N'1 Broadchurch Street', NULL, N'00001', N'Timelord City', N'Dalekticut', N'Gallifrey')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (10, N'76 Totter''s lane', N'Shoreditch', N'E16AN', N'London', N'London', N'England')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (11, N'1 Tardis lane', NULL, N'00000', N'Everywhere', N'Everywhere', N'Earth')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (12, N'10 Downing Street', N'Webminster', N'SW1A 2AA', N'London', N'', N'England')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (14, N'1 Tardis ane', NULL, N'00000', N'Everywhere', N'Everywhere', N'Earth')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (15, N'8 Torchwood lane', NULL, N'E17AA', N'London', N'', N'England')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (16, N'21 Bannerman Road', N'Ealing', N'E1AAA', N'London', N'', N'England')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (17, N'1 Church St.', NULL, N'E3AAA', N'Leadworth', N'Gloucestershire', N'England')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (18, N'8 Great St.', NULL, N'E6777', N'Blackpool', N'Lancashire', N'England')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (19, N'569 Leaman Place', N'Brooklyn Heights', N'10001', N'New York City', N'New York', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (20, N'4 Down Street', NULL, N'54220', N'Manitowoc', N'Winsconsin', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (21, N'219 West 47th Street', NULL, N'10047', N'New York', N'New York', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (22, N'15th Street', NULL, N'10015', N'New York', N'New York', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (23, N'37 Oriole Way', N'West Hollywood', N'90069', N'Los Angeles', N'California', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (24, N'1407 Graymalkin Lane', N'Salem Center', N'10560', N'North Salem', N'New York', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (25, N'213 Main Street', NULL, N'45377', N'Dayton', N'Ohio', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (26, N'Malibu Point 10880', NULL, N'90265', N'Malibu', N'California', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (27, N'62 Columbia Heights', NULL, N'20010', N'Washington D.C.', N'Columbia', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (28, N'1 Royal Place', NULL, N'00000', N'Asgard', N'Nine Realms', N'Asgard')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (29, N'2089 Main Street', NULL, N'02101', N'Boston', N'Massachusetts', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (32, N'Wayne Manor', NULL, N'23120', N'Gotham City', N'New Jersey', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (33, N'344 Clinton Street', N'Apartment 3D', N'111111', N'Metropolis', N'New York', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (34, N'344 Clinton Street', N'Apartement 3D', N'11111', N'Metropolis', N'New York', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (35, N'STAR Labs', NULL, N'45000', N'Central City', N'Oregon', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (36, N'1835 Park Ridge Lane', NULL, N'33862', N'Park Ridge', N'DM', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (37, N'Wayne Manor', NULL, N'11111', N'Gotham City', N'New Jersey', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (38, N'3 Main Street', NULL, N'25000', N'Starling City', N'Washington', N'United States')
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Postcode], [City], [State], [Country]) VALUES (40, N'STAR Labs', NULL, N'25000', N'Central City', N'Oregon', N'United States')
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (1, N'Mathematics', CAST(30.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (2, N'Mecatronnics', CAST(15.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (3, N'Electricity', CAST(30.00 AS Decimal(18, 2)), 6)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (4, N'Evolutionary Biology', CAST(30.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (5, N'Fluid Dynamics', CAST(50.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (6, N'Robotics', CAST(50.00 AS Decimal(18, 2)), 6)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (7, N'Criminology', CAST(50.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (8, N'Cellular biology', CAST(60.00 AS Decimal(18, 2)), 13)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (9, N'Kinesiology', CAST(30.00 AS Decimal(18, 2)), 16)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (11, N'Physical Physiology', CAST(20.00 AS Decimal(18, 2)), 15)
INSERT [dbo].[Courses] ([CourseId], [Title], [Credits], [ReferentTeacherId]) VALUES (12, N'Media Law', CAST(35.00 AS Decimal(18, 2)), 15)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Grades] ON 

INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (1, N'Test 1', CAST(60.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, 4)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (2, N'Online quizz #1', CAST(92.75 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 2, 2)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (3, N'Online quizz #1', CAST(14.25 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (4, N'Online quizz #2', CAST(64.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (7, N'Test 1', CAST(63.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, 22)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (8, N'Test 1', CAST(51.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (9, N'Test 1', CAST(38.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, 31)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (10, N'Test 1', CAST(98.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, 32)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (11, N'Test 2', CAST(72.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), 1, 4)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (12, N'Online quizz #2', CAST(30.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 2, 33)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (13, N'Test 1', CAST(50.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 4, 32)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (14, N'Test 1', CAST(24.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 4, 40)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (15, N'Test 1', CAST(72.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 4, 37)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (16, N'Test 1', CAST(64.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 4, 34)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (17, N'Test 1', CAST(74.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 4, 30)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (18, N'Test A', CAST(87.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 12, 35)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (19, N'Test A', CAST(74.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 12, 34)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (20, N'Test A', CAST(50.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 12, 24)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (21, N'Test A', CAST(50.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), 8, 22)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (22, N'Test A', CAST(76.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), 8, 36)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (23, N'Test A', CAST(64.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), 8, 39)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (24, N'Test B', CAST(74.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 8, 25)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (25, N'Test B', CAST(35.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 8, 29)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (26, N'Test 1', CAST(74.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), 5, 26)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (27, N'Test 1', CAST(7.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), 5, 39)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (28, N'Test 1', CAST(80.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), 5, 21)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (29, N'Group assessment 1', CAST(80.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 6, 38)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (30, N'Group assessment 1', CAST(80.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 6, 40)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (31, N'Group assessment 1', CAST(80.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 6, 26)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (33, N'Test 1', CAST(80.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 7, 37)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (34, N'Test 1', CAST(42.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 7, 39)
INSERT [dbo].[Grades] ([GradeId], [ExamName], [Mark], [Coefficient], [CourseId], [StudentId]) VALUES (35, N'Online quizz #1', CAST(100.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 2, 28)
SET IDENTITY_INSERT [dbo].[Grades] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 

INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (1, N'L309', N'Tuesday', N'08:15', N'03:00', 3, 6)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (2, N'E256', N'Friday', N'16:30', N'02:30', 1, 7)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (3, N'E356', N'Tuesday', N'12:45', N'03:00', 3, 12)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (4, N'L308', N'Saturday', N'08:15', N'03:00', 2, 5)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (5, N'L201', N'Monday', N'08:00', N'03:00', 4, 18)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (6, N'L311', N'Monday', N'09:15', N'02:30', 6, 10)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (7, N'E256', N'Monday', N'11:00', N'03:00', 7, 18)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (8, N'E401', N'Monday', N'14:30', N'04:00', 8, 19)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (9, N'L101', N'Monday', N'17:30', N'02:30', 9, 16)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (10, N'E311', N'Tuesday', N'07:30', N'04:00', 12, 13)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (11, N'L401', N'Tuesday', N'09:15', N'03:00', 5, 20)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (12, N'STADIUM TARDIS', N'Tuesday', N'15:00', N'03:00', 11, 18)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (13, N'L209', N'Tuesday', N'11:30', N'03:00', 4, 17)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (14, N'L411', N'Wenesday', N'14:00', N'03:00', 1, 7)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (15, N'L209', N'Wenesday', N'09:15', N'03:30', 7, 18)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (16, N'L401', N'Wenesday', N'17:30', N'02:30', 2, 5)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (17, N'L501', N'Wenesday', N'14:00', N'05:00', 4, 18)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (18, N'L101', N'Thursday', N'08:15', N'04:00', 5, 20)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (19, N'L201', N'Thursday', N'10:00', N'02:30', 5, 10)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (20, N'L201', N'Thursday', N'13:00', N'02:00', 6, 16)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (21, N'L101', N'Thursday', N'15:00', N'02:00', 9, 16)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (22, N'L401', N'Friday', N'08:00', N'04:00', 8, 19)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (23, N'E201', N'Friday', N'14:00', N'03:00', 12, 15)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (24, N'STADIUM TARDIS', N'Friday', N'17:00', N'03:00', 11, 15)
INSERT [dbo].[Lessons] ([LessonId], [RoomName], [Day], [Hour], [Duration], [CourseId], [TeacherId]) VALUES (25, N'E256', N'Saturday', N'10:00', N'03:00', 6, 6)
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (1, CAST(N'2020-12-06T15:17:36.717' AS DateTime), CAST(1100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (2, CAST(N'2020-12-06T23:06:43.130' AS DateTime), CAST(3000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (3, CAST(N'2020-12-06T23:07:02.783' AS DateTime), CAST(600.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (4, CAST(N'2020-12-06T23:07:23.130' AS DateTime), CAST(2800.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (5, CAST(N'2020-12-06T23:07:49.193' AS DateTime), CAST(5600.00 AS Decimal(18, 2)), 23)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (6, CAST(N'2020-12-06T23:07:58.833' AS DateTime), CAST(200.00 AS Decimal(18, 2)), 23)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (7, CAST(N'2020-12-06T23:08:34.423' AS DateTime), CAST(3200.00 AS Decimal(18, 2)), 21)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (8, CAST(N'2020-12-06T23:08:52.160' AS DateTime), CAST(400.00 AS Decimal(18, 2)), 22)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (9, CAST(N'2020-12-06T23:09:08.393' AS DateTime), CAST(234.00 AS Decimal(18, 2)), 24)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (10, CAST(N'2020-12-06T23:09:16.653' AS DateTime), CAST(66.00 AS Decimal(18, 2)), 24)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (11, CAST(N'2020-12-06T23:09:41.033' AS DateTime), CAST(200.00 AS Decimal(18, 2)), 25)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (12, CAST(N'2020-12-06T23:09:57.157' AS DateTime), CAST(250.00 AS Decimal(18, 2)), 26)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (13, CAST(N'2020-12-06T23:10:19.070' AS DateTime), CAST(860.00 AS Decimal(18, 2)), 27)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (14, CAST(N'2020-12-06T23:10:27.803' AS DateTime), CAST(500.00 AS Decimal(18, 2)), 27)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (15, CAST(N'2020-12-06T23:10:37.273' AS DateTime), CAST(4500.00 AS Decimal(18, 2)), 27)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (16, CAST(N'2020-12-06T23:11:02.600' AS DateTime), CAST(7650.00 AS Decimal(18, 2)), 28)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (17, CAST(N'2020-12-06T23:11:09.463' AS DateTime), CAST(10000.00 AS Decimal(18, 2)), 28)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (18, CAST(N'2020-12-06T23:11:30.097' AS DateTime), CAST(250.00 AS Decimal(18, 2)), 29)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (19, CAST(N'2020-12-06T23:11:56.640' AS DateTime), CAST(520.00 AS Decimal(18, 2)), 34)
INSERT [dbo].[Payments] ([PaymentId], [Date], [Amount], [StudentId]) VALUES (20, CAST(N'2020-12-06T23:12:12.260' AS DateTime), CAST(6000.00 AS Decimal(18, 2)), 39)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (2, 1)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (3, 1)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (4, 1)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (1, 2)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (2, 2)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (3, 2)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (4, 2)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (10, 2)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (19, 2)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (1, 3)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (2, 4)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (3, 4)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (15, 4)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (13, 21)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (15, 21)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (19, 21)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (2, 22)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (22, 22)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (3, 23)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (3, 24)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (10, 24)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (11, 24)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (12, 24)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (15, 24)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (22, 24)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (15, 25)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (22, 25)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (19, 26)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (20, 26)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (5, 27)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (8, 27)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (10, 28)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (16, 28)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (9, 29)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (20, 29)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (22, 29)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (16, 30)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (17, 30)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (14, 31)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (4, 32)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (5, 32)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (14, 32)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (16, 32)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (17, 32)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (23, 32)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (24, 32)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (25, 32)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (4, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (5, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (6, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (7, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (8, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (9, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (11, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (12, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (16, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (24, 33)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (8, 34)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (9, 34)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (11, 34)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (13, 34)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (19, 34)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (23, 34)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (4, 35)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (7, 35)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (11, 35)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (12, 35)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (23, 35)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (8, 36)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (12, 36)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (16, 36)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (24, 36)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (7, 37)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (13, 37)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (17, 37)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (21, 37)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (23, 37)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (4, 38)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (6, 38)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (9, 38)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (13, 38)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (25, 38)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (4, 39)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (7, 39)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (8, 39)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (11, 39)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (12, 39)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (17, 39)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (21, 39)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (5, 40)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (6, 40)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (16, 40)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (24, 40)
INSERT [dbo].[StudentLessons] ([LessonId], [UserId]) VALUES (25, 40)
GO
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (1, 5)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (2, 5)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (1, 6)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (3, 6)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (6, 6)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (1, 7)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (1, 10)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (5, 10)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (6, 10)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (9, 10)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (6, 11)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (6, 13)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (7, 13)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (12, 13)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (11, 15)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (12, 15)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (5, 16)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (6, 16)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (9, 16)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (4, 17)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (8, 17)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (4, 18)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (7, 18)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (8, 18)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (11, 18)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (8, 19)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (4, 20)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (5, 20)
INSERT [dbo].[TeacherCourses] ([CourseId], [UserId]) VALUES (8, 20)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (1, N'Maxime', N'Dennery', N'Male', N'2', N'2', N'06 62 63 02 86', CAST(N'2000-03-06' AS Date), 1, CAST(9700.00 AS Decimal(18, 2)), CAST(1100.00 AS Decimal(18, 2)), 11, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (2, N'Christophe', N'Nguyen', N'Male', N'chri.ngu@edu.devinci.fr', N'chocolate123', NULL, CAST(N'2000-12-10' AS Date), 6, CAST(4600.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), 16, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (3, N'Gwendoline', N'Marek', N'Female', N'gwen.marek@edu.devinci.fr', N'ABC123', NULL, CAST(N'2000-01-05' AS Date), 3, CAST(11900.00 AS Decimal(18, 2)), CAST(600.00 AS Decimal(18, 2)), 18, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (4, N'Rémi', N'Lombard', N'Male', N'remi.lombard@edu.devinci.fr', N'@@', NULL, CAST(N'2000-04-17' AS Date), 1, CAST(8000.00 AS Decimal(18, 2)), CAST(2800.00 AS Decimal(18, 2)), 7, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (5, N'Walter', N'Perreti', N'Male', N'4', N'4', NULL, CAST(N'1972-01-10' AS Date), 2, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (6, N'Olivier', N'Zanette', N'Male', N'3', N'3', NULL, CAST(N'1977-01-10' AS Date), 3, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (7, N'Marie-Noémie', N'Thaï', N'Female', N'n.t@edu.devinci.fr', N'ComplexPassword@!123', NULL, CAST(N'1988-07-14' AS Date), 5, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (8, N'Pascal', N'Brouaye', N'Male', N'1', N'1', NULL, CAST(N'1972-01-10' AS Date), 6, NULL, NULL, NULL, N'Administrator')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (10, N'David', N'Tennant', N'Male', N'david.tennant@who.com', N'iLoveDalek', N'0102030405', CAST(N'1971-04-18' AS Date), 9, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (11, N'Matthew', N'Smith', N'Male', N'm.smith@who.com', N'Geronimo!!!', N'0203040501', CAST(N'1982-10-28' AS Date), 10, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (12, N'Peter', N'Capaldi', N'Male', N'peter.capaldi@who.com', N'imthedoctor', N'0304050102', CAST(N'1958-04-14' AS Date), 11, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (13, N'Harriet', N'Jones', N'Female', N'harrietjones@who.com', N'Primeminister', N'', CAST(N'1946-06-03' AS Date), 12, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (14, N'Martha', N'Jones', N'Female', N'm.j@who.com', N'lovedoctor', N'0111111111', CAST(N'1984-09-14' AS Date), 14, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (15, N'Donna', N'Noble', N'Female', N'donnanoble@who.com', N'ctate', N'0555555555', CAST(N'1969-12-05' AS Date), 11, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (16, N'Jack', N'Harkness', N'Male', N'jack.harkness@who.com', N'faceofboe', N'8888888888', CAST(N'1964-07-10' AS Date), 15, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (17, N'Sarah Jane', N'Smith', N'Female', N'sarahjane@who.com', N'k9doggie', N'555555555', CAST(N'0001-01-01' AS Date), 16, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (18, N'Amelia', N'Pond', N'Female', N'pond@who.net', N'rorywilliams', N'7777777777', CAST(N'1989-08-19' AS Date), 17, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (19, N'River', N'Song', N'Female', N'riversong@who.me', N'melodypond', N'4444444444', CAST(N'1994-06-17' AS Date), 11, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (20, N'Clara', N'Oswald', N'Female', N'oswald@who.eu', N'rycbar123', N'3333333333', CAST(N'1996-06-13' AS Date), 18, NULL, NULL, NULL, N'Teacher')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (21, N'Steve', N'Rogers', N'Male', N'steve.rogers@gmail.com', N'operationRebirth', N'4567896415', CAST(N'1918-07-04' AS Date), 19, CAST(7600.00 AS Decimal(18, 2)), CAST(3200.00 AS Decimal(18, 2)), 10, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (22, N'Phil', N'Coulson', N'Male', N'coulson@shield.com', N'pegasus', N'8212864998', CAST(N'1964-07-08' AS Date), 20, CAST(10400.00 AS Decimal(18, 2)), CAST(400.00 AS Decimal(18, 2)), 16, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (23, N'Nick', N'Fury', N'Male', N'fury@shield.com', N'shield', N'7897897894', CAST(N'1950-07-04' AS Date), 21, CAST(9800.00 AS Decimal(18, 2)), CAST(5800.00 AS Decimal(18, 2)), 19, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (24, N'Peter', N'Parker', N'Male', N'pparker@web.com', N'withgreatpowercomesgreatresponsability', N'0102030405', CAST(N'2001-08-10' AS Date), 22, CAST(5300.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), 20, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (25, N'Stan', N'Lee', N'Male', N'lee@lee.com', N'excelsior!', N'7777777777', CAST(N'1922-12-28' AS Date), 23, CAST(7000.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), 12, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (26, N'Jean', N'Grey', N'Female', N'strangegirl@x-men.com', N'darkphoenixxoxo', N'9999999999', CAST(N'0001-01-01' AS Date), 24, CAST(9000.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 17, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (27, N'Bruce', N'Banner', N'Male', N'banner@banner.com', N'dontmakemeangry!!!', N'2222222222', CAST(N'1969-12-18' AS Date), 25, CAST(10000.00 AS Decimal(18, 2)), CAST(5860.00 AS Decimal(18, 2)), 16, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (28, N'Tony', N'Stark', N'Male', N'stark@stark-industries.com', N'ilypepper', N'5555555555', CAST(N'1970-05-29' AS Date), 26, CAST(10000.00 AS Decimal(18, 2)), CAST(17650.00 AS Decimal(18, 2)), 10, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (29, N'Peggy', N'Carter', N'Female', N'carter@ssr.com', N'w8ting4uRogers', N'1231231231', CAST(N'1921-04-09' AS Date), 27, CAST(4000.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 19, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (30, N'Thor', N'Odinson', N'Male', N'godofthunder@asgard.co', N'Mjolnir', N'66664444', CAST(N'0964-06-02' AS Date), 28, CAST(6400.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 16, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (31, N'Carol', N'Denvers', N'Female', N'ace@marvel.com', N'imcaptainmarvel', N'9999999999', CAST(N'1960-04-24' AS Date), 29, CAST(9760.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 15, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (32, N'Bruce', N'Wayne', N'Male', N'bruce@wayne-enterprises.com', N'thedarkknight', N'4444444444', CAST(N'1963-02-19' AS Date), 32, CAST(14700.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (33, N'Dick', N'Grayson', N'Male', N'dick@wayne-enterprises.com', N'loveubatman', N'89898989', CAST(N'1990-11-11' AS Date), 32, CAST(6500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 11, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (34, N'Loïs', N'Lane', N'Female', N'lane@daily-planet.com', N'jordanjonathan', N'2222222222', CAST(N'1981-07-16' AS Date), 33, CAST(3000.00 AS Decimal(18, 2)), CAST(520.00 AS Decimal(18, 2)), 14, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (35, N'Clark', N'Kent', N'Male', N'kent@daily-planet.com', N'iamsuperman', N'8888888888', CAST(N'1987-05-03' AS Date), 34, CAST(10800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 18, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (36, N'Barry', N'Allen', N'Male', N'allen@starlabs.com', N'imfast', N'555555555', CAST(N'1989-03-14' AS Date), 35, CAST(15800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 11, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (37, N'Lex', N'Luthor', N'Male', N'luthor@lexcorp.com', N'hateusuperman', N'2222222222', CAST(N'1972-07-11' AS Date), 36, CAST(12550.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 20, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (38, N'Alfred', N'Pennyworth', N'Male', N'alfred@wayne-enterprises.com', N'bruce', N'464664664', CAST(N'1943-04-01' AS Date), 37, CAST(7600.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 19, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (39, N'Oliver', N'Queen', N'Male', N'queen@quenc.com', N'imgreenarrow', N'8888878888', CAST(N'1985-05-16' AS Date), 38, CAST(800.00 AS Decimal(18, 2)), CAST(6000.00 AS Decimal(18, 2)), 14, N'Student')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Gender], [EmailAddress], [Password], [PhoneNumber], [BirthDate], [AddressId], [Fees], [Paid], [TutorId], [Discriminator]) VALUES (40, N'Harrison', N'Wells', N'Male', N'wells@starlabs.com', N'eobardthawne', N'2356895623', CAST(N'1976-06-17' AS Date), 40, CAST(9870.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 12, N'Student')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.Users_ReferentTeacherId] FOREIGN KEY([ReferentTeacherId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.Users_ReferentTeacherId]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Grades_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_dbo.Grades_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Grades_dbo.Users_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_dbo.Grades_dbo.Users_StudentId]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Lessons_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_dbo.Lessons_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Lessons_dbo.Users_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_dbo.Lessons_dbo.Users_TeacherId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Payments_dbo.Users_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_dbo.Payments_dbo.Users_StudentId]
GO
ALTER TABLE [dbo].[PresentStudentLessons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PresentStudentLessons_dbo.Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([LessonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PresentStudentLessons] CHECK CONSTRAINT [FK_dbo.PresentStudentLessons_dbo.Lessons_LessonId]
GO
ALTER TABLE [dbo].[PresentStudentLessons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PresentStudentLessons_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PresentStudentLessons] CHECK CONSTRAINT [FK_dbo.PresentStudentLessons_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[StudentLessons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentLessons_dbo.Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([LessonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentLessons] CHECK CONSTRAINT [FK_dbo.StudentLessons_dbo.Lessons_LessonId]
GO
ALTER TABLE [dbo].[StudentLessons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentLessons_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentLessons] CHECK CONSTRAINT [FK_dbo.StudentLessons_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[TeacherCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TeacherCourses_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherCourses] CHECK CONSTRAINT [FK_dbo.TeacherCourses_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[TeacherCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TeacherCourses_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherCourses] CHECK CONSTRAINT [FK_dbo.TeacherCourses_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Addresses_AddressId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Users_TutorId] FOREIGN KEY([TutorId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Users_TutorId]
GO
