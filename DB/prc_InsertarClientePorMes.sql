CREATE PROCEDURE prc_insertarClientePorMes
@cedula varchar (25),
@nombre varchar (50),
@apellido1 varchar (50),
@apellido2 varchar (50),
@telefono varchar (15),
@placa varchar (6),
@tipoServicio int

AS
BEGIN TRY
   BEGIN TRANSACTION 
      --Insertar en la tabla de cliente por mes
	  INSERT INTO ClientesPorMes (cedula,nombre,apellido1,apellido2,telefono,placa,tipoServicio)
	  VALUES
	  (@CEDULA,@nombre,@apellido1,@apellido2,@telefono,@placa,@tipoServicio)
   COMMIT TRANSACTION

END TRY
BEGIN CATCH
  IF @@TRANCOUNT > 0
     ROLLBACK TRANSACTION
END CATCH