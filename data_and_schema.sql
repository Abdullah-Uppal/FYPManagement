USE [ProjectA]
GO
/****** Object:  Table [dbo].[Advisor]    Script Date: 06 March, 2022 5:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advisor](
	[Id] [int] NOT NULL,
	[Designation] [int] NOT NULL,
	[Salary] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 06 March, 2022 5:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[TotalWeightage] [int] NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created_On] [date] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupEvaluation]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupEvaluation](
	[GroupId] [int] NOT NULL,
	[EvaluationId] [int] NOT NULL,
	[ObtainedMarks] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupEvaluation] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[EvaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupProject]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupProject](
	[ProjectId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupStudent]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupStudent](
	[GroupId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupStudent] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NULL,
	[Contact] [varchar](20) NULL,
	[Email] [varchar](30) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](max) NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectAdvisor]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAdvisor](
	[AdvisorId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[AdvisorRole] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectAdvisor] PRIMARY KEY CLUSTERED 
(
	[AdvisorId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 06 March, 2022 5:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[RegistrationNo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (1, 6, CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (2, 7, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3, 9, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (6, 7, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (7, 9, CAST(130000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (8, 8, CAST(135000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (9, 8, CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (10, 6, CAST(210000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (11, 7, CAST(190000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (69, 9, CAST(50000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Evaluation] ON 

INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (7, N'At least 5 reports Generation', 10, 7)
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1, CAST(N'2022-03-05' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2, CAST(N'2022-03-05' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (4, CAST(N'2022-03-05' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (6, CAST(N'2022-03-06' AS Date))
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1, 7, 10, CAST(N'2022-03-06T12:40:41.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (2, 7, 9, CAST(N'2022-03-06T12:40:41.000' AS DateTime))
GO
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (1, 1, CAST(N'2022-03-05T21:37:59.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (3, 1, CAST(N'2022-03-06T03:09:32.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (13, 4, CAST(N'2022-03-06T03:09:12.000' AS DateTime))
GO
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (1, 1, 3, CAST(N'2022-03-05T20:38:50.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (1, 13, 3, CAST(N'2022-03-05T19:40:20.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (1, 37, 3, CAST(N'2022-03-05T19:40:21.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2, 51, 3, CAST(N'2022-03-05T19:44:21.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2, 52, 3, CAST(N'2022-03-05T19:44:22.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (4, 2, 3, CAST(N'2022-03-05T20:17:46.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (4, 27, 3, CAST(N'2022-03-05T20:17:46.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (4, 33, 3, CAST(N'2022-03-05T20:17:46.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (4, 47, 3, CAST(N'2022-03-05T20:17:46.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (6, 14, 3, CAST(N'2022-03-06T01:31:32.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (6, 15, 3, CAST(N'2022-03-06T01:31:32.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (6, 17, 3, CAST(N'2022-03-06T01:31:32.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (1, N'Male', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (2, N'Female', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (3, N'Active', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (4, N'InActive', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (6, N'Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (7, N'Associate Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (8, N'Assisstant Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (9, N'Lecturer', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (10, N'Industry Professional', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (11, N'Main Advisor', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (12, N'Co-Advisror', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (14, N'Industry Advisor', N'ADVISOR_ROLE')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1, N'Muhammad Abdullah', N'Asif', N'03009439389', N'computerinsider4@gmail.com', CAST(N'2001-09-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (2, N'Sameed', N'Bin Adeel', N'03243234567', N'sameedadeel@gmail.com', CAST(N'2002-01-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3, N'Fizza', N'Akram', N'03214323456', N'fizzaakram@gmail.com', CAST(N'2002-06-11T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (5, N'Zain', N'Rasool', N'09876543212', N'zainrasool@gmail.com', CAST(N'2000-04-26T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (6, N'Zain', N'Tahir', N'09879898989', N'zainultahir@hotmail.com', CAST(N'2003-11-06T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (7, N'Esha', N'Tanveer', N'03212121212', N'eshatanveer@gmail.com', CAST(N'2001-08-14T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (8, N'Humna', N'AB', N'03334445556', N'humnaab@gmail.com', CAST(N'2003-06-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (10, N'Awais', N'Butt', N'03212134567', N'muhammadabdullahupal@gmail.com', CAST(N'2000-06-22T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (11, N'Abdullah', N'Butt', N'03456523456', N'muhammadabdullahupal@gmail.com', CAST(N'2002-07-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (12, N'Qazi Maaz', N'Sajjad', N'03434343434', N'muhammadabdullahupal@gmail.com', CAST(N'2006-03-22T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (13, N'Ahtisham', N'Rajpoot', N'03245674555', N'ahtishamrajpoot774@gmail.com', CAST(N'2002-09-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (14, N'Ayesha', N'Shabbir', N'08765432123', N'ayeshashabbir@gmail.com', CAST(N'2000-01-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (15, N'Ayesha', N'Javaid', N'03212123456', N'ayeshajavaid@gmail.com', CAST(N'2000-01-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (16, N'Rafia', N'Mehmood', N'03213212321', N'rafiamehmood@gmail.com', CAST(N'2001-09-09T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (17, N'Ayesha', N'Amjad', N'03216543219', N'ayeshaamjad@gmail.com', CAST(N'2001-01-10T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (18, N'Khadija', N'Dar', N'06565674654', N'dusrikhadija@gmail.com', CAST(N'2002-02-02T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (19, N'Esha', N'Tur Razia', N'09876248762', N'eshaturrazia@gmail.com', CAST(N'2003-03-02T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (20, N'Abdullah', N'Yaqub', N'03456789000', N'abdullahyaqub72@gmail.com', CAST(N'2003-04-06T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (22, N'Muhammad', N'Ahmad', N'08767657657', N'ahmadrao@gmail.com', CAST(N'2001-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (24, N'Muhammad Khuzaima', N'Umair', N'03213213213', N'mkumair@gmail.com', CAST(N'2002-04-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (25, N'Rehan', N'Khalid', N'03212345678', N'rehankhalid@gmail.com', CAST(N'2001-03-04T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (27, N'Mohsin', N'Raza', N'03334445556', N'mohsynraza@gmail.com', CAST(N'2002-02-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (28, N'Laibah', N'Azhar', N'03234567898', N'laibahazhar@gmail.com', CAST(N'2002-12-22T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (30, N'Salahuddin', N'Ayubi', N'03234532344', N'salahuddin@gmail.com', CAST(N'2001-06-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (31, N'Talha', N'Ramzan', N'03333333327', N'talharamzan@gmail.com', CAST(N'2000-06-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (32, N'Sadia', N'Ghani', N'03333321232', N'sadiaghani@gmail.com', CAST(N'2001-09-09T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (33, N'Shafqat', N'Ullah', N'03212345555', N'shafqatullah@gmail.com', CAST(N'1999-10-10T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (34, N'Khadija', N'Iqbal', N'09878888233', N'khadijaiqbal@gmail.com', CAST(N'2001-01-10T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (35, N'Moiz', N'Wajahat', N'03214214214', N'moizhun@outlook.com', CAST(N'2001-02-20T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (36, N'Muattar', N'Mehdi', N'03456532146', N'muattarmehdizaidi@gmail.com', CAST(N'2001-12-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (37, N'Aqib', N'Shahzad', N'03214215055', N'aqibali543@gmail.com', CAST(N'2001-12-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (38, N'Muhammad', N'Ahmad', N'03212343222', N'muhammadahmedgcu@gmail.com', CAST(N'2000-12-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (39, N'Momina', N'Ghauri', N'03214232323', N'momina.ghauri97@gmail.com', CAST(N'2001-12-21T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (40, N'Eman', N'Muneeb', N'03212344444', N'emanmuneeb@gmail.com', CAST(N'2002-02-20T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (42, N'Hoga', N'Koi', N'03333333333', N'hanhunkoi@gmail.com', CAST(N'2000-02-01T14:15:24.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (44, N'Syed Bilal', N'Hashmi', N'03009494949', N'syedbilal@gmail.com', CAST(N'2005-06-07T20:12:22.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (47, N'Muhammad Usman', N'Rasheed', N'03333323452', N'usmanrasheed@gmail.com', CAST(N'2001-03-13T13:23:09.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (50, N'Awais Yusuf', N'Dar', N'03009494949', N'buttawa@gmail.com', CAST(N'2000-02-01T10:22:38.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (51, N'Abdullah', N'Butt', N'0452143578', N'butthun@gmail.com', CAST(N'2000-07-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (52, N'Abdullah', N'Yaqub', N'03344381565', N'abdullahyaqub555@gmail.com', CAST(N'2003-09-16T11:34:30.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (1, N'This project is all about the management of Final Year Projects.', N'FYP Management')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (3, N'API based project which will run on other devices as well if other developers use this api', N'FreeAPI')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (13, N'Alone but happy.', N'Alone')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (16, N'This project I hope will be for unit testing in C#.', N'Testing')
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (1, 1, 11, CAST(N'2022-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (1, 3, 12, CAST(N'2022-03-05T06:44:11.080' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (1, 13, 11, CAST(N'2022-03-05T11:10:05.000' AS DateTime))
GO
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (1, N'2020-CS-52')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (2, N'2020-CS-53')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3, N'2020-CS-54')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (5, N'2020-CS-56')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (6, N'2020-CS-57')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (7, N'2020-CS-58')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (8, N'2020-CS-59')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (13, N'2020-CS-64')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (14, N'2020-CS-65')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (15, N'2020-CS-66')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (16, N'2020-CS-67')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (17, N'2020-CS-68')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (18, N'2020-CS-69')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (19, N'2020-CS-70')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (20, N'2020-CS-71')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (22, N'2020-CS-73')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (24, N'2020-CS-75')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (25, N'2020-CS-76')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (27, N'2020-CS-77')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (28, N'2020-CS-78')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (30, N'2020-CS-80')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (31, N'2020-CS-81')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (32, N'2020-CS-82')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (33, N'2020-CS-88')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (34, N'2020-CS-84')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (35, N'2020-CS-85')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (36, N'2020-CS-86')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (37, N'2020-CS-92')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (38, N'2020-CS-95')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (39, N'2020-CS-97')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (40, N'2020-CS-99')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (42, N'2020-CS-100')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (44, N'2020-CS-93')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (47, N'2020-CS-79')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (50, N'2020-CS-62')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (51, N'2020-CS-63')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (52, N'2020-CS-72')
GO
ALTER TABLE [dbo].[Advisor]  WITH CHECK ADD  CONSTRAINT [FK_Advisor_Lookup] FOREIGN KEY([Designation])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Advisor] CHECK CONSTRAINT [FK_Advisor_Lookup]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Evaluation] FOREIGN KEY([EvaluationId])
REFERENCES [dbo].[Evaluation] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Evaluation]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Project]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_GroupStudents_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_GroupStudents_Lookup]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Group]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Student]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Lookup] FOREIGN KEY([Gender])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Lookup] FOREIGN KEY([AdvisorRole])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Project]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeachers_Teacher] FOREIGN KEY([AdvisorId])
REFERENCES [dbo].[Advisor] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectTeachers_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Person]
GO
