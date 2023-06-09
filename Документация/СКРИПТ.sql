USE [master]
GO
/****** Object:  Database [TimTimBD]    Script Date: 22.05.2023 14:54:14 ******/
CREATE DATABASE [TimTimBD]
 
GO
USE [TimTimBD]
GO
/****** Object:  Table [dbo].[Abonement]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abonement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryTrainerId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[LessonCount] [int] NOT NULL,
 CONSTRAINT [PK_PriceList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buy]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AbonementId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[LessonsLeftCount] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_Abonement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryTrainer]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryTrainer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainerId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryTrainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[AbonementId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Rent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryTrainerId] [int] NOT NULL,
	[DayWeek] [nvarchar](50) NOT NULL,
	[DayTime] [time](7) NOT NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NOT NULL,
	[Birthday] [date] NOT NULL,
	[WorkExperience] [int] NOT NULL,
	[Info] [nvarchar](1000) NOT NULL,
	[Photo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Phone] [nvarchar](30) NULL,
	[Email] [nvarchar](50) NULL,
	[PassportSeries] [nvarchar](50) NULL,
	[PassportNum] [nvarchar](50) NULL,
	[Role] [bit] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visit]    Script Date: 22.05.2023 14:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuytId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Visit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Abonement] ON 

INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (56, 70, 1000, 4)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (57, 70, 1600, 8)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (58, 70, 3000, 24)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (59, 71, 1000, 4)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (60, 71, 1600, 8)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (61, 71, 3000, 24)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (62, 65, 1000, 4)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (63, 65, 1600, 8)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (64, 65, 3000, 24)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (65, 66, 1000, 4)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (66, 66, 1600, 8)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (67, 66, 3000, 24)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (68, 67, 1000, 4)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (69, 67, 1600, 8)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (70, 67, 3000, 24)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (71, 68, 1000, 4)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (72, 68, 1600, 8)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (73, 68, 3000, 24)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (74, 69, 1000, 4)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (75, 69, 1600, 8)
INSERT [dbo].[Abonement] ([Id], [CategoryTrainerId], [Price], [LessonCount]) VALUES (76, 69, 3000, 24)
SET IDENTITY_INSERT [dbo].[Abonement] OFF
SET IDENTITY_INSERT [dbo].[Buy] ON 

INSERT [dbo].[Buy] ([Id], [AbonementId], [DateTime], [LessonsLeftCount], [UserName], [StatusId]) VALUES (20, 65, CAST(N'2023-05-22T14:36:15.027' AS DateTime), 4, N'danil', 1)
INSERT [dbo].[Buy] ([Id], [AbonementId], [DateTime], [LessonsLeftCount], [UserName], [StatusId]) VALUES (21, 58, CAST(N'2023-05-22T14:37:24.747' AS DateTime), 24, N'vladimir', 1)
INSERT [dbo].[Buy] ([Id], [AbonementId], [DateTime], [LessonsLeftCount], [UserName], [StatusId]) VALUES (22, 63, CAST(N'2023-05-22T14:00:00.000' AS DateTime), 8, N'igor', 1)
INSERT [dbo].[Buy] ([Id], [AbonementId], [DateTime], [LessonsLeftCount], [UserName], [StatusId]) VALUES (23, 72, CAST(N'2023-05-20T14:00:00.000' AS DateTime), 8, N'kamila', 1)
INSERT [dbo].[Buy] ([Id], [AbonementId], [DateTime], [LessonsLeftCount], [UserName], [StatusId]) VALUES (24, 66, CAST(N'2023-05-11T14:38:57.353' AS DateTime), 8, N'kazimira', 1)
INSERT [dbo].[Buy] ([Id], [AbonementId], [DateTime], [LessonsLeftCount], [UserName], [StatusId]) VALUES (25, 68, CAST(N'2023-05-22T14:39:35.660' AS DateTime), 4, N'klavdiya', 1)
INSERT [dbo].[Buy] ([Id], [AbonementId], [DateTime], [LessonsLeftCount], [UserName], [StatusId]) VALUES (26, 63, CAST(N'2023-04-14T12:00:00.000' AS DateTime), 0, N'matvey', 2)
SET IDENTITY_INSERT [dbo].[Buy] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Робототехника Kids')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Smart сад')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Ступеньки')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Шахматы')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'Логопед - дефектолог')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'ИЗО')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (7, N'Подготовка к школе')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'Английский язык')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[CategoryTrainer] ON 

INSERT [dbo].[CategoryTrainer] ([Id], [TrainerId], [CategoryId]) VALUES (65, 5, 1)
INSERT [dbo].[CategoryTrainer] ([Id], [TrainerId], [CategoryId]) VALUES (66, 2, 2)
INSERT [dbo].[CategoryTrainer] ([Id], [TrainerId], [CategoryId]) VALUES (67, 2, 3)
INSERT [dbo].[CategoryTrainer] ([Id], [TrainerId], [CategoryId]) VALUES (68, 1, 6)
INSERT [dbo].[CategoryTrainer] ([Id], [TrainerId], [CategoryId]) VALUES (69, 4, 4)
INSERT [dbo].[CategoryTrainer] ([Id], [TrainerId], [CategoryId]) VALUES (70, 3, 7)
INSERT [dbo].[CategoryTrainer] ([Id], [TrainerId], [CategoryId]) VALUES (71, 3, 8)
SET IDENTITY_INSERT [dbo].[CategoryTrainer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Username], [AbonementId], [Date]) VALUES (19, N'kamila', 74, CAST(N'2023-05-22T14:33:58.417' AS DateTime))
INSERT [dbo].[Order] ([Id], [Username], [AbonementId], [Date]) VALUES (20, N'tamara', 60, CAST(N'2023-05-22T14:34:44.927' AS DateTime))
INSERT [dbo].[Order] ([Id], [Username], [AbonementId], [Date]) VALUES (21, N'kazimira', 56, CAST(N'2023-05-22T14:35:46.573' AS DateTime))
INSERT [dbo].[Order] ([Id], [Username], [AbonementId], [Date]) VALUES (22, N'kazimira', 65, CAST(N'2023-05-22T14:35:56.093' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (1, N'активирован', N'#FF90EE90')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (2, N'истек', N'#FFFA8072')
SET IDENTITY_INSERT [dbo].[TimeTable] ON 

INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (57, 70, N'Понедельник', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (58, 70, N'Вторник', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (59, 70, N'Среда', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (60, 70, N'Четверг', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (61, 70, N'Пятница', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (62, 71, N'Понедельник', CAST(N'15:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (63, 71, N'Среда', CAST(N'15:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (64, 71, N'Пятница', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (65, 65, N'Понедельник', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (66, 65, N'Вторник', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (67, 65, N'Среда', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (68, 65, N'Четверг', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (69, 65, N'Пятница', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (70, 65, N'Суббота', CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (71, 66, N'Понедельник', CAST(N'10:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (72, 66, N'Вторник', CAST(N'10:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (73, 66, N'Среда', CAST(N'10:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (74, 66, N'Четверг', CAST(N'10:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (75, 66, N'Пятница', CAST(N'10:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (76, 67, N'Понедельник', CAST(N'13:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (77, 67, N'Вторник', CAST(N'13:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (78, 67, N'Среда', CAST(N'13:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (79, 67, N'Четверг', CAST(N'13:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (80, 67, N'Пятница', CAST(N'13:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (81, 68, N'Понедельник', CAST(N'15:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (82, 68, N'Вторник', CAST(N'15:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (83, 68, N'Среда', CAST(N'15:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (84, 68, N'Четверг', CAST(N'15:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (85, 68, N'Пятница', CAST(N'15:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (86, 69, N'Понедельник', CAST(N'14:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (87, 69, N'Вторник', CAST(N'14:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (88, 69, N'Среда', CAST(N'14:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (89, 69, N'Четверг', CAST(N'14:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [CategoryTrainerId], [DayWeek], [DayTime]) VALUES (90, 69, N'Пятница', CAST(N'14:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[TimeTable] OFF
SET IDENTITY_INSERT [dbo].[Trainer] ON 

INSERT [dbo].[Trainer] ([Id], [LastName], [FirstName], [MiddleName], [Birthday], [WorkExperience], [Info], [Photo]) VALUES (1, N'Мухина', N'Антонина', N'Алексеевна', CAST(N'1987-01-01' AS Date), 15, N'Образование:  Высшее педагогическое образование.', N'IMG_4123.jpg')
INSERT [dbo].[Trainer] ([Id], [LastName], [FirstName], [MiddleName], [Birthday], [WorkExperience], [Info], [Photo]) VALUES (2, N'Залалетдинова', N'Диляра', N'Дулусовна', CAST(N'1998-05-21' AS Date), 8, N'Сертифицированный Монтессори-педагог
 
Девиз в работе: медленно, но верно
', N'image-05-02-21-12-26.jpeg')
INSERT [dbo].[Trainer] ([Id], [LastName], [FirstName], [MiddleName], [Birthday], [WorkExperience], [Info], [Photo]) VALUES (3, N'Галиакберова', N'Анастасия', N'Евгеньевна', CAST(N'1998-03-12' AS Date), 10, N'Педагог подготовки к школе и английского языка', N'30e6823e-40e0-4197-8bd7-9707fcebdd7d.jpg')
INSERT [dbo].[Trainer] ([Id], [LastName], [FirstName], [MiddleName], [Birthday], [WorkExperience], [Info], [Photo]) VALUES (4, N'Сибагатуллин ', N'Тимур', N'Эдуардович', CAST(N'2001-06-17' AS Date), 6, N'КМС по шахматам. Тренерский стаж 4 года.', N'image-06-02-21-11-33-2.jpg')
INSERT [dbo].[Trainer] ([Id], [LastName], [FirstName], [MiddleName], [Birthday], [WorkExperience], [Info], [Photo]) VALUES (5, N'Голубев', N'Дмитрий', N'Сергеевич', CAST(N'1999-06-17' AS Date), 4, N'Сертифицированный специалист lego WEDO 2.O', N'9319.jpg')
SET IDENTITY_INSERT [dbo].[Trainer] OFF
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'admin', N'1', N'Сафин', N'Алмаз', N'Айратович', N'+7 (900) 745-32-34', N'Almaz007@mail.ru', NULL, NULL, 1)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'danil', N'1', N'Гаранин', N'Даниил', N'Владимирович', N'+7 (969) 325-95-89', N'daniil8@mail.ru', NULL, NULL, 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'igor', N'1', N'Дмитриев', N'Игорь', N'Денисович', N'+7 (965) 515-05-55', N'dimitrii7878@mail.ru', N'121', N'121221', 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'kamila', N'1', N'Сивохина', N'Камилла', N'Радиковна', N'+7 (969) 005-13-41', N'kamil@mail.ru', N'11', N'1111', 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'kazimira', N'1', N'Холодкова', N'Казимира ', N'Антоновна', N'+7 (953) 209-24-55', N'KazimiraHolodkova745@gmail.ru', NULL, NULL, 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'klavdiya', N'1', N'Владимирова', N'Клавдия', N'Виталиевна', N'+7 (954) 343-27-62', N'KlavdiyaVladimirova425240@mail.ru', NULL, NULL, 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'matvey', N'5', N'Быстров', N'Матвей', N'Сергеевич', N'+7 (911) 532-83-98', N'MatveyBystrov998@mail.ru', N'1111', N'1111111', 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'shults', N'1', N'Шульц', N'Гурий', N'Геннадиевич', N'+7 (916) 871-77-61', N'GuriyShults13459@mail.ru', NULL, NULL, 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'tamara', N'1', N'Городецкая', N'Тамара', N'Сергеевна', N'+7 (965) 574-31-54', N'TamaraGorodetskaya905@yandex.ru', N'1', N'2', 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'vladimir', N'1', N'Богданов', N'Владимир', N'Максимович', N'+7 (942) 988-43-60', N'VladimirBogdanov278@mail.ru', NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Visit] ON 

INSERT [dbo].[Visit] ([Id], [BuytId], [DateTime]) VALUES (18, 26, CAST(N'2023-05-04T17:01:12.000' AS DateTime))
INSERT [dbo].[Visit] ([Id], [BuytId], [DateTime]) VALUES (19, 26, CAST(N'2023-05-08T17:01:28.000' AS DateTime))
INSERT [dbo].[Visit] ([Id], [BuytId], [DateTime]) VALUES (20, 26, CAST(N'2023-05-10T17:01:45.000' AS DateTime))
INSERT [dbo].[Visit] ([Id], [BuytId], [DateTime]) VALUES (21, 26, CAST(N'2023-05-12T17:00:00.000' AS DateTime))
INSERT [dbo].[Visit] ([Id], [BuytId], [DateTime]) VALUES (22, 26, CAST(N'2023-05-15T17:00:31.000' AS DateTime))
INSERT [dbo].[Visit] ([Id], [BuytId], [DateTime]) VALUES (23, 26, CAST(N'2023-05-17T17:00:45.000' AS DateTime))
INSERT [dbo].[Visit] ([Id], [BuytId], [DateTime]) VALUES (24, 26, CAST(N'2023-05-19T17:00:56.000' AS DateTime))
INSERT [dbo].[Visit] ([Id], [BuytId], [DateTime]) VALUES (25, 26, CAST(N'2023-05-22T17:00:21.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Visit] OFF
ALTER TABLE [dbo].[Abonement]  WITH CHECK ADD  CONSTRAINT [FK_Abonement_CategoryTrainer] FOREIGN KEY([CategoryTrainerId])
REFERENCES [dbo].[CategoryTrainer] ([Id])
GO
ALTER TABLE [dbo].[Abonement] CHECK CONSTRAINT [FK_Abonement_CategoryTrainer]
GO
ALTER TABLE [dbo].[Buy]  WITH CHECK ADD  CONSTRAINT [FK_Buy_Abonement] FOREIGN KEY([AbonementId])
REFERENCES [dbo].[Abonement] ([Id])
GO
ALTER TABLE [dbo].[Buy] CHECK CONSTRAINT [FK_Buy_Abonement]
GO
ALTER TABLE [dbo].[Buy]  WITH CHECK ADD  CONSTRAINT [FK_Buy_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Buy] CHECK CONSTRAINT [FK_Buy_Status]
GO
ALTER TABLE [dbo].[Buy]  WITH CHECK ADD  CONSTRAINT [FK_Buy_User] FOREIGN KEY([UserName])
REFERENCES [dbo].[User] ([UserName])
GO
ALTER TABLE [dbo].[Buy] CHECK CONSTRAINT [FK_Buy_User]
GO
ALTER TABLE [dbo].[CategoryTrainer]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTrainer_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[CategoryTrainer] CHECK CONSTRAINT [FK_CategoryTrainer_Category]
GO
ALTER TABLE [dbo].[CategoryTrainer]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTrainer_Trainer] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainer] ([Id])
GO
ALTER TABLE [dbo].[CategoryTrainer] CHECK CONSTRAINT [FK_CategoryTrainer_Trainer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Abonement] FOREIGN KEY([AbonementId])
REFERENCES [dbo].[Abonement] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Abonement]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Client1] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([UserName])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Rent_Client1]
GO
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_CategoryTrainer] FOREIGN KEY([CategoryTrainerId])
REFERENCES [dbo].[CategoryTrainer] ([Id])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTable_CategoryTrainer]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Buy] FOREIGN KEY([BuytId])
REFERENCES [dbo].[Buy] ([Id])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [FK_Visit_Buy]
GO
USE [master]
GO
ALTER DATABASE [TimTimBD] SET  READ_WRITE 
GO
