USE [Freed]
GO
/****** Object:  Table [dbo].[actividad]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[actividad](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[nombre] [varchar](255) NOT NULL,
 CONSTRAINT [pk_actividad_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[afiliado]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[afiliado](
	[idPersonaAfiliado] [int] NOT NULL,
	[idTipoNomina] [int] NOT NULL,
 CONSTRAINT [pk_afiliado_idPersonaAfiliado] PRIMARY KEY CLUSTERED 
(
	[idPersonaAfiliado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cliente]    Script Date: 3/20/2017 1:02:29 PM ******/
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
/****** Object:  Table [dbo].[configuracion]    Script Date: 3/20/2017 1:02:29 PM ******/
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
/****** Object:  Table [dbo].[configuracionCliente]    Script Date: 3/20/2017 1:02:29 PM ******/
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
/****** Object:  Table [dbo].[costo]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[costo](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[inicio] [datetime] NOT NULL,
	[fin] [datetime] NOT NULL,
	[costo] [int] NOT NULL,
	[idPaquete] [int] NOT NULL,
 CONSTRAINT [pk_costo_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[empleado]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[empleado](
	[idPersonaEmpleado] [int] NOT NULL,
	[cargo] [varchar](50) NOT NULL,
	[sueldo] [money] NOT NULL,
 CONSTRAINT [pk_empleado_idPersonaEmpleado] PRIMARY KEY CLUSTERED 
(
	[idPersonaEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[estado]    Script Date: 3/20/2017 1:02:29 PM ******/
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
/****** Object:  Table [dbo].[factura]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[factura](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[numero] [varchar](30) NOT NULL,
	[fechaPago] [datetime] NOT NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NOT NULL,
	[idCliente] [int] NOT NULL,
 CONSTRAINT [pk_factura_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[grupo]    Script Date: 3/20/2017 1:02:29 PM ******/
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
/****** Object:  Table [dbo].[infoAdicional]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[infoAdicional](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[atributo] [varchar](50) NOT NULL,
	[valor] [varchar](255) NOT NULL,
	[tipo] [varchar](20) NOT NULL,
	[requerido] [bit] NOT NULL,
	[vigente] [bit] NOT NULL,
	[idPersona] [int] NOT NULL,
 CONSTRAINT [pk_infoAdicional_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[paquete]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[paquete](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [pk_paquete_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[paqueteActividad]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paqueteActividad](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[idPaquete] [int] NOT NULL,
	[idActividad] [int] NOT NULL,
 CONSTRAINT [pk_paqueteActividad_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[paqueteRegla]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paqueteRegla](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[idPaquete] [int] NOT NULL,
	[idRegla] [int] NOT NULL,
 CONSTRAINT [pk_paqueteRegla_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[permiso]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[permiso](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](255) NULL,
 CONSTRAINT [pk_permiso_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[persona]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[persona](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[dni] [varchar](50) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[sexo] [bit] NOT NULL,
	[idCliente] [int] NOT NULL,
	[idRol] [int] NOT NULL,
 CONSTRAINT [pk_persona_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[personaPaquete]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personaPaquete](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[desde] [datetime] NULL,
	[hasta] [datetime] NULL,
	[cantidad] [int] NULL,
	[idPersona] [int] NOT NULL,
	[idPaquete] [int] NOT NULL,
 CONSTRAINT [pk_personaPaquete_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[regla]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[regla](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[clasificacion] [varchar](50) NOT NULL,
	[valor] [varchar](50) NOT NULL,
 CONSTRAINT [pk_regla_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rol]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rol](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[nombre] [varchar](255) NOT NULL,
 CONSTRAINT [pk_rol_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rolPermiso]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rolPermiso](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[idPermiso] [int] NOT NULL,
 CONSTRAINT [pk_rolPermiso_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipoNomina]    Script Date: 3/20/2017 1:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipoNomina](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [pk_tipoNomina_id] PRIMARY KEY CLUSTERED 
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
/****** Object:  Index [uk_configuracion_codigoSistema]    Script Date: 3/20/2017 1:02:29 PM ******/
ALTER TABLE [dbo].[configuracion] ADD  CONSTRAINT [uk_configuracion_codigoSistema] UNIQUE NONCLUSTERED 
(
	[codigoSistema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [uk_grupo_nombre]    Script Date: 3/20/2017 1:02:29 PM ******/
ALTER TABLE [dbo].[grupo] ADD  CONSTRAINT [uk_grupo_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[afiliado]  WITH CHECK ADD  CONSTRAINT [fk_afiliado_persona] FOREIGN KEY([idPersonaAfiliado])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[afiliado] CHECK CONSTRAINT [fk_afiliado_persona]
GO
ALTER TABLE [dbo].[afiliado]  WITH CHECK ADD  CONSTRAINT [fk_afiliado_tipoNomina] FOREIGN KEY([idTipoNomina])
REFERENCES [dbo].[tipoNomina] ([id])
GO
ALTER TABLE [dbo].[afiliado] CHECK CONSTRAINT [fk_afiliado_tipoNomina]
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
ALTER TABLE [dbo].[costo]  WITH CHECK ADD  CONSTRAINT [fk_costo_paquete] FOREIGN KEY([idPaquete])
REFERENCES [dbo].[paquete] ([id])
GO
ALTER TABLE [dbo].[costo] CHECK CONSTRAINT [fk_costo_paquete]
GO
ALTER TABLE [dbo].[empleado]  WITH CHECK ADD  CONSTRAINT [fk_empleado_persona] FOREIGN KEY([idPersonaEmpleado])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[empleado] CHECK CONSTRAINT [fk_empleado_persona]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [fk_factura_cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [fk_factura_cliente]
GO
ALTER TABLE [dbo].[infoAdicional]  WITH CHECK ADD  CONSTRAINT [fk_infoAdicional_persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[infoAdicional] CHECK CONSTRAINT [fk_infoAdicional_persona]
GO
ALTER TABLE [dbo].[paqueteActividad]  WITH CHECK ADD  CONSTRAINT [fk_paqueteActividad_actividad] FOREIGN KEY([idActividad])
REFERENCES [dbo].[actividad] ([id])
GO
ALTER TABLE [dbo].[paqueteActividad] CHECK CONSTRAINT [fk_paqueteActividad_actividad]
GO
ALTER TABLE [dbo].[paqueteActividad]  WITH CHECK ADD  CONSTRAINT [fk_paqueteActividad_paquete] FOREIGN KEY([idPaquete])
REFERENCES [dbo].[paquete] ([id])
GO
ALTER TABLE [dbo].[paqueteActividad] CHECK CONSTRAINT [fk_paqueteActividad_paquete]
GO
ALTER TABLE [dbo].[paqueteRegla]  WITH CHECK ADD  CONSTRAINT [fk_paqueteRegla_paquete] FOREIGN KEY([idPaquete])
REFERENCES [dbo].[paquete] ([id])
GO
ALTER TABLE [dbo].[paqueteRegla] CHECK CONSTRAINT [fk_paqueteRegla_paquete]
GO
ALTER TABLE [dbo].[paqueteRegla]  WITH CHECK ADD  CONSTRAINT [fk_paqueteRegla_regla] FOREIGN KEY([idRegla])
REFERENCES [dbo].[regla] ([id])
GO
ALTER TABLE [dbo].[paqueteRegla] CHECK CONSTRAINT [fk_paqueteRegla_regla]
GO
ALTER TABLE [dbo].[persona]  WITH CHECK ADD  CONSTRAINT [fk_persona_cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[persona] CHECK CONSTRAINT [fk_persona_cliente]
GO
ALTER TABLE [dbo].[persona]  WITH CHECK ADD  CONSTRAINT [fk_persona_rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([id])
GO
ALTER TABLE [dbo].[persona] CHECK CONSTRAINT [fk_persona_rol]
GO
ALTER TABLE [dbo].[personaPaquete]  WITH CHECK ADD  CONSTRAINT [fk_personaPaquete_paquete] FOREIGN KEY([idPaquete])
REFERENCES [dbo].[paquete] ([id])
GO
ALTER TABLE [dbo].[personaPaquete] CHECK CONSTRAINT [fk_personaPaquete_paquete]
GO
ALTER TABLE [dbo].[personaPaquete]  WITH CHECK ADD  CONSTRAINT [fk_personaPaquete_persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[personaPaquete] CHECK CONSTRAINT [fk_personaPaquete_persona]
GO
ALTER TABLE [dbo].[rolPermiso]  WITH CHECK ADD  CONSTRAINT [fk_rolPermiso_idPermiso] FOREIGN KEY([idPermiso])
REFERENCES [dbo].[permiso] ([id])
GO
ALTER TABLE [dbo].[rolPermiso] CHECK CONSTRAINT [fk_rolPermiso_idPermiso]
GO
ALTER TABLE [dbo].[rolPermiso]  WITH CHECK ADD  CONSTRAINT [fk_rolPermiso_idRol] FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([id])
GO
ALTER TABLE [dbo].[rolPermiso] CHECK CONSTRAINT [fk_rolPermiso_idRol]
GO
