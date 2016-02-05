USE [master]
GO
/****** Object:  Database [MovieTheater]    Script Date: 5/2/2016 4:54:01 PM ******/
CREATE DATABASE [MovieTheater]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieTheater', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MovieTheater.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MovieTheater_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MovieTheater_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MovieTheater] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieTheater].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieTheater] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieTheater] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieTheater] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieTheater] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieTheater] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieTheater] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MovieTheater] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MovieTheater] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieTheater] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieTheater] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieTheater] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieTheater] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieTheater] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieTheater] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieTheater] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieTheater] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MovieTheater] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieTheater] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieTheater] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieTheater] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieTheater] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieTheater] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MovieTheater] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieTheater] SET RECOVERY FULL 
GO
ALTER DATABASE [MovieTheater] SET  MULTI_USER 
GO
ALTER DATABASE [MovieTheater] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieTheater] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieTheater] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieTheater] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MovieTheater', N'ON'
GO
USE [MovieTheater]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Booking](
	[Booking_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[RoomMovie_ID] [int] NOT NULL,
	[PaymentType_ID] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[Card_Number] [varchar](20) NULL,
	[Card_Name] [varchar](50) NULL,
	[Card_Expiring_Month] [int] NULL,
	[Card_Expiring_Year] [int] NULL,
	[Card_Secret_Code] [varchar](5) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Booking_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookingDetail]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetail](
	[BookingDetail_ID] [int] IDENTITY(1,1) NOT NULL,
	[Booking_ID] [int] NOT NULL,
	[Seat_ID] [int] NOT NULL,
 CONSTRAINT [PK_BookingDetail] PRIMARY KEY CLUSTERED 
(
	[BookingDetail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[MobileNo] [varchar](15) NOT NULL,
	[Login_ID] [varchar](15) NOT NULL,
	[Password] [varchar](15) NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Create_Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movie](
	[Movie_ID] [int] IDENTITY(1,1) NOT NULL,
	[Movie_Name] [varchar](100) NOT NULL,
	[Duration] [int] NOT NULL,
	[PictureURL] [varchar](50) NULL,
	[IMDB_Link] [varchar](50) NULL,
	[Description] [varchar](1000) NOT NULL,
	[Language] [varchar](50) NOT NULL,
	[Subtitle] [varchar](50) NOT NULL,
	[Ratings] [float] NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Update_Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Movie_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaymentType]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaymentType](
	[PaymentType_ID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType_Name] [varchar](15) NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Update_Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED 
(
	[PaymentType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Room_ID] [int] IDENTITY(1,1) NOT NULL,
	[Room_Name] [varchar](10) NOT NULL,
	[Theater_ID] [int] NOT NULL,
	[RoomType_ID] [int] NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Update_Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Room_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoomMovie]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomMovie](
	[RoomMovie_ID] [int] IDENTITY(1,1) NOT NULL,
	[Room_ID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Movie_ID] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Publish] [bit] NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Update_Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_RoomMovie] PRIMARY KEY CLUSTERED 
(
	[RoomMovie_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomType_ID] [int] IDENTITY(1,1) NOT NULL,
	[RoomType_Name] [varchar](10) NOT NULL,
	[Price] [float] NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Update_Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[RoomType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Seat]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seat](
	[Seat_ID] [int] IDENTITY(1,1) NOT NULL,
	[Seat_Name] [varchar](5) NOT NULL,
	[Room_ID] [int] NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Update_Datetime] [datetime] NOT NULL,
	[Rows] [int] NOT NULL,
	[Columns] [int] NOT NULL,
 CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED 
(
	[Seat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SeatMovie]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeatMovie](
	[SeatMovie_ID] [int] IDENTITY(1,1) NOT NULL,
	[RoomMovie_ID] [int] NOT NULL,
	[Seat_ID] [int] NOT NULL,
	[Occupied] [bit] NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Update_Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_SeatMovie] PRIMARY KEY CLUSTERED 
(
	[SeatMovie_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Theater]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Theater](
	[Theater_ID] [int] IDENTITY(1,1) NOT NULL,
	[Theater_Name] [varchar](100) NOT NULL,
	[Theater_Address] [varchar](1000) NOT NULL,
	[Theater_Phone_No] [varchar](15) NOT NULL,
	[Active_Indicator] [bit] NOT NULL,
	[Update_Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Theater] PRIMARY KEY CLUSTERED 
(
	[Theater_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/2/2016 4:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[User_ID] [varchar](50) NOT NULL,
	[Password] [varchar](5) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Seat] ADD  CONSTRAINT [DF_Seat_Rows]  DEFAULT ((0)) FOR [Rows]
GO
ALTER TABLE [dbo].[Seat] ADD  CONSTRAINT [DF_Seat_Column]  DEFAULT ((0)) FOR [Columns]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_PaymentType] FOREIGN KEY([PaymentType_ID])
REFERENCES [dbo].[PaymentType] ([PaymentType_ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_PaymentType]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_RoomMovie] FOREIGN KEY([RoomMovie_ID])
REFERENCES [dbo].[RoomMovie] ([RoomMovie_ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_RoomMovie]
GO
ALTER TABLE [dbo].[BookingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetail_Booking] FOREIGN KEY([Booking_ID])
REFERENCES [dbo].[Booking] ([Booking_ID])
GO
ALTER TABLE [dbo].[BookingDetail] CHECK CONSTRAINT [FK_BookingDetail_Booking]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([RoomType_ID])
REFERENCES [dbo].[RoomType] ([RoomType_ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Theater] FOREIGN KEY([Theater_ID])
REFERENCES [dbo].[Theater] ([Theater_ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Theater]
GO
ALTER TABLE [dbo].[RoomMovie]  WITH CHECK ADD  CONSTRAINT [FK_RoomMovie_Movie] FOREIGN KEY([Movie_ID])
REFERENCES [dbo].[Movie] ([Movie_ID])
GO
ALTER TABLE [dbo].[RoomMovie] CHECK CONSTRAINT [FK_RoomMovie_Movie]
GO
ALTER TABLE [dbo].[RoomMovie]  WITH CHECK ADD  CONSTRAINT [FK_RoomMovie_Room] FOREIGN KEY([Room_ID])
REFERENCES [dbo].[Room] ([Room_ID])
GO
ALTER TABLE [dbo].[RoomMovie] CHECK CONSTRAINT [FK_RoomMovie_Room]
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD  CONSTRAINT [FK_Seat_Room] FOREIGN KEY([Room_ID])
REFERENCES [dbo].[Room] ([Room_ID])
GO
ALTER TABLE [dbo].[Seat] CHECK CONSTRAINT [FK_Seat_Room]
GO
ALTER TABLE [dbo].[SeatMovie]  WITH CHECK ADD  CONSTRAINT [FK_SeatMovie_RoomMovie] FOREIGN KEY([RoomMovie_ID])
REFERENCES [dbo].[RoomMovie] ([RoomMovie_ID])
GO
ALTER TABLE [dbo].[SeatMovie] CHECK CONSTRAINT [FK_SeatMovie_RoomMovie]
GO
USE [master]
GO
ALTER DATABASE [MovieTheater] SET  READ_WRITE 
GO
