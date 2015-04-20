CREATE PROCEDURE prc_eliminarClientePorMes
@cedula varchar (25),
@placa varchar (6)
AS
BEGIN TRY
   BEGIN TRANSACTION 
      --Actualizar el estado en la tabla de cliente por mes
	  UPDATE ClientesPorMes SET ESTADO=0 WHERE CEDULA=@cedula AND PLACA=@placa

   COMMIT TRANSACTION

END TRY
BEGIN CATCH
  IF @@TRANCOUNT > 0
     ROLLBACK TRANSACTION
END CATCH