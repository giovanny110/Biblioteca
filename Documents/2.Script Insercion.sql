USE BibliotecaBD;

INSERT INTO [dbo].[tipos_documento] (descripcion, abreviatura)
VALUES ('Documento Nacional de Identidad', 'DNI');

INSERT INTO [dbo].[autores] ([nombre], [apellido_paterno], [apellido_materno])
VALUES ('Juanjo', 'Gutierrez', 'PErez');

INSERT INTO [dbo].[estados_libro]([descripcion])
VALUES ('Disponible');

INSERT INTO [dbo].[estados_prestamo]([descripcion])
VALUES ('PENDIENTE'),
	   ('DEVUELTO');

INSERT INTO [dbo].[libros]([titulo], [fecha_publicacion], [id_autor], [usuario_registro], [fecha_registro], [flag_estado], [flag_eliminado])
VALUES ('ABC', GETDATE(), 1, 'ADMIN', GETDATE(), 1, 0),
	('100 años de soledad', GETDATE(), 1, 'ADMIN', GETDATE(), 1, 0),
	('Alicia en el pais de las maravillas', GETDATE(), 1, 'ADMIN', GETDATE(), 1, 0),
	('Harry Potter', GETDATE(), 1, 'ADMIN', GETDATE(), 1, 0),
	('El señor de los anillos', GETDATE(), 1, 'ADMIN', GETDATE(), 1, 0),
	('Historia de 2 ciudades', GETDATE(), 1, 'ADMIN', GETDATE(), 1, 0),
	('El principito', GETDATE(), 1, 'ADMIN', GETDATE(), 1, 0);

INSERT INTO [dbo].[clientes] ([nombre]
      ,[apellido_paterno]
      ,[apellido_materno]
      ,[id_tipo_documento]
      ,[numero_documento]
      ,[telefono]
      ,[direccion]
      ,[email]
      ,[flag_verificado]
      ,[fecha_registro]
      ,[flag_estado]
      ,[flag_eliminado])
VALUES ('Juan', 'Prueba', 'Test', 1,  '70584251', '94563115', 'por ahi', 'nose@gmail.com', 1, '2024-10-10 00:00:00.000', 1, 1),
('Pedro', 'Ruiz', 'Flips', 1,  '45682316', '94687523', 'al frente', 'pedro@hotmail.com', 1, '2024-10-10 00:00:00.000', 1, 1);


INSERT INTO [dbo].[detalle_libros] ([id_libro], [codigo_barras], [id_estado_libro], [usuario_registro], [fecha_registro], [flag_estado], [flag_eliminado])
VALUES (2, '123-456-789-121', 1, 'ADMIN', GETDATE(), 1, 0),
	(2, '123-987-789-122', 1, 'ADMIN', GETDATE(), 1, 0),
	(2, '123-456-123-123', 1, 'ADMIN', GETDATE(), 1, 0),
	(2, '222-456-123-221', 1, 'ADMIN', GETDATE(), 1, 0),
	(2, '222-456-123-222', 1, 'ADMIN', GETDATE(), 1, 0);