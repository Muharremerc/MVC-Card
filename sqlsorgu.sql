USE [master]
GO
/****** Object:  Database [Market]    Script Date: 23.12.2018 21:30:21 ******/
CREATE DATABASE [Market]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Market', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Market.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Market_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Market_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Market] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Market].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Market] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Market] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Market] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Market] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Market] SET ARITHABORT OFF 
GO
ALTER DATABASE [Market] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Market] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Market] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Market] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Market] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Market] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Market] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Market] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Market] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Market] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Market] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Market] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Market] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Market] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Market] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Market] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Market] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Market] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Market] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Market] SET  MULTI_USER 
GO
ALTER DATABASE [Market] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Market] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Market] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Market] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Market]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardId] [nvarchar](50) NULL,
	[Money] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerCard]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardId] [int] NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_CustomerCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](50) NULL,
	[ImageAlt] [nvarchar](50) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pricing]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pricing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Rate] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Pricing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ShopId] [int] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageId] [int] NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shop]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TicketProduct]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_TicketProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Userr]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userr](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Userr] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserShop]    Script Date: 23.12.2018 21:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserShop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ShopId] [int] NULL,
 CONSTRAINT [PK_UserShop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CustomerCard]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCard_Card] FOREIGN KEY([CardId])
REFERENCES [dbo].[Card] ([Id])
GO
ALTER TABLE [dbo].[CustomerCard] CHECK CONSTRAINT [FK_CustomerCard_Card]
GO
ALTER TABLE [dbo].[CustomerCard]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCard_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerCard] CHECK CONSTRAINT [FK_CustomerCard_Customer]
GO
ALTER TABLE [dbo].[Pricing]  WITH CHECK ADD  CONSTRAINT [FK_Pricing_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Pricing] CHECK CONSTRAINT [FK_Pricing_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Shop]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Image1] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([Id])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Image1]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product1]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Customer]
GO
ALTER TABLE [dbo].[TicketProduct]  WITH CHECK ADD  CONSTRAINT [FK_TicketProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[TicketProduct] CHECK CONSTRAINT [FK_TicketProduct_Product]
GO
ALTER TABLE [dbo].[TicketProduct]  WITH CHECK ADD  CONSTRAINT [FK_TicketProduct_Product1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[TicketProduct] CHECK CONSTRAINT [FK_TicketProduct_Product1]
GO
ALTER TABLE [dbo].[TicketProduct]  WITH CHECK ADD  CONSTRAINT [FK_TicketProduct_Ticket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([Id])
GO
ALTER TABLE [dbo].[TicketProduct] CHECK CONSTRAINT [FK_TicketProduct_Ticket]
GO
ALTER TABLE [dbo].[UserShop]  WITH CHECK ADD  CONSTRAINT [FK_UserShop_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[UserShop] CHECK CONSTRAINT [FK_UserShop_Shop]
GO
ALTER TABLE [dbo].[UserShop]  WITH CHECK ADD  CONSTRAINT [FK_UserShop_Userr] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserShop] CHECK CONSTRAINT [FK_UserShop_Userr]
GO
USE [master]
GO
ALTER DATABASE [Market] SET  READ_WRITE 
GO
