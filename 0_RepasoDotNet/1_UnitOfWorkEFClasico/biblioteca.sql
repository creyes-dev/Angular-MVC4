USE [Biblioteca]
GO
/****** Object:  Table [dbo].[Miembro]    Script Date: 08/03/2018 23:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Miembro](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Miembro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 08/03/2018 23:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[Id] [int] NOT NULL,
	[IdMiembroPrestamoActual] [int] NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TituloLibro]    Script Date: 08/03/2018 23:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TituloLibro](
	[ISBN] [varchar](20) NOT NULL,
	[Titulo] [nvarchar](50) NULL,
	[IdLibro] [int] NULL,
 CONSTRAINT [PK_TituloLibro] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prestamo]    Script Date: 08/03/2018 23:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamo](
	[Id] [nchar](10) NOT NULL,
	[FechaPrestamo] [date] NULL,
	[FechaDevolucion] [date] NULL,
	[FechaEstipuladaDevolucion] [date] NULL,
	[IdLibro] [int] NULL,
	[IdMiembro] [int] NULL,
 CONSTRAINT [PK_Prestamo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Libro_Miembro]    Script Date: 08/03/2018 23:49:19 ******/
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Miembro] FOREIGN KEY([Id])
REFERENCES [dbo].[Miembro] ([Id])
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Miembro]
GO
/****** Object:  ForeignKey [FK_Prestamo_Libro]    Script Date: 08/03/2018 23:49:19 ******/
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_Libro] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[Libro] ([Id])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_Prestamo_Libro]
GO
/****** Object:  ForeignKey [FK_Prestamo_Miembro]    Script Date: 08/03/2018 23:49:19 ******/
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_Miembro] FOREIGN KEY([IdMiembro])
REFERENCES [dbo].[Miembro] ([Id])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_Prestamo_Miembro]
GO
/****** Object:  ForeignKey [FK_TituloLibro_Libro]    Script Date: 08/03/2018 23:49:19 ******/
ALTER TABLE [dbo].[TituloLibro]  WITH CHECK ADD  CONSTRAINT [FK_TituloLibro_Libro] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[Libro] ([Id])
GO
ALTER TABLE [dbo].[TituloLibro] CHECK CONSTRAINT [FK_TituloLibro_Libro]
GO
