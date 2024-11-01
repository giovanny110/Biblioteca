
use master
CREATE DATABASE BibliotecaBD;
USE BibliotecaBD;


CREATE TABLE [autores] (
  [id] int identity(1,1) not null,
  [nombre] varchar(80) not null,
  [apellido_paterno] varchar(80) not null,
  [apellido_materno] varchar(80) not null,
  CONSTRAINT autores_pk PRIMARY KEY (id)
)
GO

CREATE TABLE [editoriales] (
  [id] int identity(1,1) not null,
  [nombre] varchar(150) not null,
  CONSTRAINT editoriales_pk PRIMARY KEY (id)
)
GO

CREATE TABLE [estados_libro] (
  [id] integer identity(1,1) not null,
  [descripcion] varchar(50) not null,
  CONSTRAINT estados_libo_pk PRIMARY KEY (id)
)
GO

CREATE TABLE [tipos_documento] (
  [id] int identity(1,1) not null,
  [descripcion] varchar(50),
  [abreviatura] varchar(10),
  CONSTRAINT tipos_documento_pk PRIMARY KEY (id)
)
GO


CREATE TABLE [ubigeo] (
  [id] int identity(1,1) not null,
  [codigo_departamento] char(2),
  [departamento] varchar(01),
  [codigo_provincia] char(2),
  [provincia] varchar(01),
  [codigo_distrito] char(2),
  [distrito] varchar(01),
  CONSTRAINT ubigeo_pk PRIMARY KEY (id)
)
GO


CREATE TABLE [estados_prestamo] (
  [id] int identity(1,1) not null,
  [descripcion] varchar(150),
  CONSTRAINT estados_prestamo_pk PRIMARY KEY (id)
)
GO


CREATE TABLE [usuarios] (
  [id] int identity(1,1) not null,
  [nombre] varchar(80),
  [apellido_paterno] varchar(80),
  [apellido_materno] varchar(80),
  [id_tipo_documento] integer,
  [numero_documento] varchar(150),
  [telefono] varchar(9),
  [email] varchar(200),
  [direccion] varchar(250),
  [id_ubigeo] int,
  [usuario] varchar(150),
  [password] varchar(150),
  [usuario_registro] varchar(150),
  [fecha_registro] datetime,
  [usuario_modificador] varchar(150),
  [fecha_modificacion] datetime,
  [flag_estado] bit,
  [flag_eliminado] bit,
  CONSTRAINT usuarios_pk PRIMARY KEY (id),
  CONSTRAINT usuario__tipo_documento_fk FOREIGN KEY (id_tipo_documento) REFERENCES [tipos_documento] ([id]),
  CONSTRAINT usuario__ubigeo_fk FOREIGN KEY (id_ubigeo) REFERENCES [ubigeo] ([id])
)
GO

CREATE TABLE [clientes] (
  [id] int identity(1,1) not null,
  [nombre] varchar(80),
  [apellido_paterno] varchar(80),
  [apellido_materno] varchar(80),
  [id_tipo_documento] integer,
  [numero_documento] integer,
  [telefono] varchar(9),
  [id_ubigeo] integer,
  [direccion] varchar(250),
  [email] varchar(200),
  [password] varchar(150),
  [flag_verificado] bit,
  [fecha_registro] datetime,
  [usuario_modificador] varchar(150),
  [fecha_modificacion] datetime,
  [flag_estado] bit,
  [flag_eliminado] bit,
  CONSTRAINT clientes_pk PRIMARY KEY (id),
  CONSTRAINT clientes__tipo_documento_fk FOREIGN KEY (id_tipo_documento) REFERENCES [tipos_documento] ([id]),
  CONSTRAINT clientes__ubigeo_fk FOREIGN KEY (id_ubigeo) REFERENCES [ubigeo] ([id])
)
GO

CREATE TABLE [libros] (
  [id] int identity(1,1) not null,
  [titulo] varchar(max),
  [fecha_publicacion] datetime,
  [id_autor] int,
  [id_editorial] int,
  usuario_registro varchar(100),
  [fecha_registro] datetime,
  usuario_modificacion varchar(100),
  [fecha_modificacion] datetime,
  [flag_estado] bit,
  [flag_eliminado] bit,
  CONSTRAINT libros_pk PRIMARY KEY (id),
  CONSTRAINT libros__autores_fk FOREIGN KEY ([id_autor]) REFERENCES autores(id),
  CONSTRAINT libros__editoriales_fk FOREIGN KEY ([id_editorial]) REFERENCES editoriales(id)
)
GO

CREATE TABLE [detalle_libros] (
  [id_libro] int not null,
  [codigo_barras] char(15) not null,
  [id_estado_libro] integer,
  [fecha_perdida] datetime,
  [monto_cobrado_perdida] numeric(5,2),
  [id_cliente_perdida] integer,
  [usuario_registro] varchar(150),
  [fecha_registro] datetime,
  [usuario_modificador] varchar(150),
  [fecha_modificacion] datetime,
  [flag_estado] bit,
  [flag_eliminado] bit,
  constraint detalle_libros_pk PRIMARY KEY ([id_libro], [codigo_barras]),
  CONSTRAINT detalle_libros__estado_libro_fk FOREIGN KEY ([id_estado_libro]) REFERENCES [estados_libro] ([id]),
  CONSTRAINT detalle_libros__cliente_fk FOREIGN KEY ([id_cliente_perdida]) REFERENCES [clientes] ([id])
)
GO


CREATE TABLE [prestamos] (
  [id] int identity(1,1) not null,
  [id_cliente_solicitante] integer,
  [id_usuario_aprobador] integer,
  [id_libro] integer,
  [libro_codigo_barras] char(15),
  [id_estado_prestamo] integer,
  [fecha_atencion_solicitud] datetime,
  [motivo_rechazo] varchar(250),
  [fecha_prestamo] datetime,
  [fecha_devolucion] datetime,
  [fecha_registro] datetime,
  [usuario_modificador] varchar(150),
  [fecha_modificacion] datetime,
  [flag_estado] bit,
  [flag_eliminado] bit,
  constraint prestamos_pk PRIMARY KEY ([id]),
  CONSTRAINT prestamos__cliente_solicitante_fk FOREIGN KEY ([id_cliente_solicitante]) REFERENCES [clientes] ([id]),
  CONSTRAINT prestamos__usuario_aprobador_fk FOREIGN KEY ([id_usuario_aprobador]) REFERENCES [usuarios] ([id]),
  CONSTRAINT prestamos__estado_prestamo_fk FOREIGN KEY ([id_estado_prestamo]) REFERENCES [estados_prestamo] ([id]),
  CONSTRAINT [fk_prestamos_detalle_libro] FOREIGN KEY ([id_libro], [libro_codigo_barras]) REFERENCES [detalle_libros] ([id_libro], [codigo_barras])
)
GO

CREATE TABLE [lista_negra] (
  [id_cliente] integer not null,
  [id_solicitud] integer not null,
  [usuario_registro] varchar(150),
  [fecha_registro] datetime,
  [usuario_modificador] varchar(150),
  [fecha_modificacion] datetime,
  [flag_estado] bit,
  [flag_eliminado] bit,
  constraint lista_negra_pk PRIMARY KEY ([id_cliente]),
  CONSTRAINT lista_negra__cliente_fk FOREIGN KEY ([id_cliente]) REFERENCES [clientes] ([id]),
  CONSTRAINT lista_negra__solicitud_fk FOREIGN KEY ([id_solicitud]) REFERENCES [prestamos] (id)
)
GO

CREATE TABLE [solicitudes_otp] (
  [id] int identity(1,1) not null,
  [codigo] char(8),
  [id_cliente_solicitante] integer,
  [fecha_vencimiento] datetime,
  [fecha_registro] datetime,
  constraint solicitud_otp_pk PRIMARY KEY ([id]),
  CONSTRAINT solicitud_otp__cliente_fk FOREIGN KEY ([id_cliente_solicitante]) references [clientes] ([id])
)
GO

