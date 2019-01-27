USE [master]
GO
/****** Object:  Database [Tareas]    Script Date: 27/01/2019 03:34:49 p.m. ******/
CREATE DATABASE [Tareas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Tareas', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Tareas.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Tareas_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Tareas_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Tareas] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tareas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tareas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tareas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tareas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tareas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tareas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tareas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tareas] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Tareas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tareas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tareas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tareas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tareas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tareas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tareas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tareas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tareas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Tareas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tareas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tareas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tareas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tareas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tareas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tareas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tareas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Tareas] SET  MULTI_USER 
GO
ALTER DATABASE [Tareas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tareas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Tareas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Tareas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Tareas]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 27/01/2019 03:34:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [tinyint] NOT NULL,
	[Nombre] [nvarchar](200) NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado]    Script Date: 27/01/2019 03:34:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [tinyint] NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Ordinal] [smallint] NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prioridad]    Script Date: 27/01/2019 03:34:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prioridad](
	[Id] [tinyint] NOT NULL,
	[Nombre] [nchar](10) NULL,
	[Ordinal] [smallint] NULL,
 CONSTRAINT [PK_Prioridad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 27/01/2019 03:34:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[Id] [uniqueidentifier] NOT NULL,
	[Asunto] [nvarchar](200) NULL,
	[FechaDesde] [smalldatetime] NULL,
	[FechaVencimiento] [smalldatetime] NULL,
	[FechaCompletada] [smalldatetime] NULL,
	[IdEstado] [tinyint] NULL,
	[IdPrioridad] [tinyint] NULL,
	[FechaCreacion] [smalldatetime] NULL,
 CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TareaCategoria]    Script Date: 27/01/2019 03:34:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TareaCategoria](
	[IdTarea] [uniqueidentifier] NOT NULL,
	[IdCategoria] [tinyint] NOT NULL,
 CONSTRAINT [PK_TareaCategoria] PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC,
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TareaUsuario]    Script Date: 27/01/2019 03:34:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TareaUsuario](
	[IdTarea] [uniqueidentifier] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TareaUsuario] PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/01/2019 03:34:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [uniqueidentifier] NOT NULL,
	[Apellido] [nvarchar](100) NULL,
	[Nombre] [nvarchar](100) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Tarea]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Tarea] CHECK CONSTRAINT [FK_Tarea_Estado]
GO
ALTER TABLE [dbo].[Tarea]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_Prioridad] FOREIGN KEY([IdPrioridad])
REFERENCES [dbo].[Prioridad] ([Id])
GO
ALTER TABLE [dbo].[Tarea] CHECK CONSTRAINT [FK_Tarea_Prioridad]
GO
ALTER TABLE [dbo].[TareaCategoria]  WITH CHECK ADD  CONSTRAINT [FK_TareaCategoria_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[TareaCategoria] CHECK CONSTRAINT [FK_TareaCategoria_Categoria]
GO
ALTER TABLE [dbo].[TareaCategoria]  WITH CHECK ADD  CONSTRAINT [FK_TareaCategoria_Tarea] FOREIGN KEY([IdTarea])
REFERENCES [dbo].[Tarea] ([Id])
GO
ALTER TABLE [dbo].[TareaCategoria] CHECK CONSTRAINT [FK_TareaCategoria_Tarea]
GO
ALTER TABLE [dbo].[TareaUsuario]  WITH CHECK ADD  CONSTRAINT [FK_TareaUsuario_Tarea] FOREIGN KEY([IdTarea])
REFERENCES [dbo].[Tarea] ([Id])
GO
ALTER TABLE [dbo].[TareaUsuario] CHECK CONSTRAINT [FK_TareaUsuario_Tarea]
GO
ALTER TABLE [dbo].[TareaUsuario]  WITH CHECK ADD  CONSTRAINT [FK_TareaUsuario_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[TareaUsuario] CHECK CONSTRAINT [FK_TareaUsuario_Usuario]
GO
USE [master]
GO
ALTER DATABASE [Tareas] SET  READ_WRITE 
GO
