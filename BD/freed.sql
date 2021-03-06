USE [Freed]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 20/3/2017 9:58:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[correo] [varchar](50) NULL,
	[idEstado] [int] NOT NULL,
 CONSTRAINT [pk_cliente_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[configuracion]    Script Date: 20/3/2017 9:58:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[configuracion](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[atributo] [varchar](50) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[codigoSistema] [varchar](50) NOT NULL,
	[tipoValor] [varchar](20) NOT NULL,
	[requerido] [bit] NOT NULL,
	[idGrupo] [int] NOT NULL,
 CONSTRAINT [PK_configuracion_ID] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[configuracionCliente]    Script Date: 20/3/2017 9:58:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[configuracionCliente](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[valor] [varchar](255) NOT NULL,
	[idConfiguracion] [int] NOT NULL,
	[idCliente] [int] NOT NULL,
 CONSTRAINT [pk_configuracionCliente_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[estado]    Script Date: 20/3/2017 9:58:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[estado](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
 CONSTRAINT [pk_estado_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[grupo]    Script Date: 20/3/2017 9:58:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[grupo](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [pk_grupo_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[configuracion] ON 

INSERT [dbo].[configuracion] ([id], [fechaCreacion], [atributo], [descripcion], [codigoSistema], [tipoValor], [requerido], [idGrupo]) VALUES (0, CAST(N'2017-03-16 14:02:59.450' AS DateTime), N'Ruta DB', N'Ubicacion de la BD en el sistema', N'70d6bb44-c6f0-4d74-9fe8-6d3b05fac08e', N'string', 1, 1)
SET IDENTITY_INSERT [dbo].[configuracion] OFF
SET IDENTITY_INSERT [dbo].[estado] ON 

INSERT [dbo].[estado] ([id], [nombre], [descripcion]) VALUES (0, N'Inactivo', N'El cliente no se encuentra activo en el sistema')
INSERT [dbo].[estado] ([id], [nombre], [descripcion]) VALUES (1, N'Activo', N'El cliente se encuentra activo en el sistema')
SET IDENTITY_INSERT [dbo].[estado] OFF
SET IDENTITY_INSERT [dbo].[grupo] ON 

INSERT [dbo].[grupo] ([id], [fechaCreacion], [nombre]) VALUES (0, CAST(N'2017-03-11 22:42:05.083' AS DateTime), N'Impresora')
INSERT [dbo].[grupo] ([id], [fechaCreacion], [nombre]) VALUES (1, CAST(N'2017-03-11 22:42:18.320' AS DateTime), N'bd')
INSERT [dbo].[grupo] ([id], [fechaCreacion], [nombre]) VALUES (2001, CAST(N'2017-03-15 22:26:35.050' AS DateTime), N'fax')
INSERT [dbo].[grupo] ([id], [fechaCreacion], [nombre]) VALUES (2002, CAST(N'2017-03-15 22:28:07.067' AS DateTime), N'tlfn')
INSERT [dbo].[grupo] ([id], [fechaCreacion], [nombre]) VALUES (2003, CAST(N'2017-03-15 22:29:15.457' AS DateTime), N'correo')
SET IDENTITY_INSERT [dbo].[grupo] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [uk_configuracion_codigoSistema]    Script Date: 20/3/2017 9:58:43 a. m. ******/
ALTER TABLE [dbo].[configuracion] ADD  CONSTRAINT [uk_configuracion_codigoSistema] UNIQUE NONCLUSTERED 
(
	[codigoSistema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [uk_grupo_nombre]    Script Date: 20/3/2017 9:58:43 a. m. ******/
ALTER TABLE [dbo].[grupo] ADD  CONSTRAINT [uk_grupo_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [fk_cliente_estado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[estado] ([id])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [fk_cliente_estado]
GO
ALTER TABLE [dbo].[configuracion]  WITH CHECK ADD  CONSTRAINT [fk_configuracion_grupo] FOREIGN KEY([idGrupo])
REFERENCES [dbo].[grupo] ([id])
GO
ALTER TABLE [dbo].[configuracion] CHECK CONSTRAINT [fk_configuracion_grupo]
GO
ALTER TABLE [dbo].[configuracionCliente]  WITH CHECK ADD  CONSTRAINT [fk_configuracionCliente_cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[configuracionCliente] CHECK CONSTRAINT [fk_configuracionCliente_cliente]
GO
ALTER TABLE [dbo].[configuracionCliente]  WITH CHECK ADD  CONSTRAINT [fk_configuracionCliente_configuracion] FOREIGN KEY([idConfiguracion])
REFERENCES [dbo].[configuracion] ([id])
GO
ALTER TABLE [dbo].[configuracionCliente] CHECK CONSTRAINT [fk_configuracionCliente_configuracion]
GO
