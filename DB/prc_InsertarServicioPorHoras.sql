CREATE PROCEDURE prc_insertarServicioPorHoras
@idCliente int,--en caso de que no sea un cliente mensual, se envia un -1 desde la aplicacion en este parametro,
@cedula varchar (25),--en caso de que no sea un cliente mensual, se envia un string vacio desde la aplicacion en este parametro,
@placa varchar (6)--en caso de que no sea un cliente mensual, se envia un string vacio desde la aplicacion en este parametro
AS
declare @exento int
declare @horaEntrada smalldatetime
declare @horaSalida smalldatetime
declare @tipoServicio int
declare @idClienteVar int
BEGIN TRY
   BEGIN TRANSACTION 
		set @idClienteVar=@idCliente
		--VERIFICAR SI ES CLIENTE POR MES Y SU TIPO DE SERVICIO PARA DETERMINAR SI ES EXENTO O NO

		IF(@idClienteVar!=-1)
		BEGIN
			SELECT @tipoServicio=ISNULL (tipoServicio,-1) FROM ClientesPorMes WHERE ID=@idCliente
			SELECT @cedula=CEDULA FROM ClientesPorMes where id=@idCliente;--setear la cedula para insertarla en la tabla
		END

		IF(LEN(@cedula)>0)
		BEGIN
			SELECT @tipoServicio=ISNULL (tipoServicio,-1) FROM ClientesPorMes WHERE CEDULA=@cedula
			SELECT @idClienteVar=id from ClientesPorMes  WHERE CEDULA=@cedula--setear el id para insertarlo en la tabla
		END
		
		IF(LEN(@placa)>0)
		BEGIN
			SELECT @tipoServicio=ISNULL (tipoServicio,-1) FROM ClientesPorMes WHERE PLACA=@placa
		END
		
		IF(@tipoServicio=-1)--si no es cliente mensual insertar el servicio por horas simple
			BEGIN
				SET @exento=0
				INSERT INTO ServicioPorHora(placa,clienteXMes,exento,horaDeEntrada) values (@placa,'N',0,getdate());
			END
			ELSE
			BEGIN
				IF(@tipoServicio=1)--MES COMPLETO
					BEGIN
						SET @exento=1;
					END
				ELSE 
					BEGIN
						IF(@tipoServicio=2 and (DATEPART(hour,getdate())<17))--MES DIURNO y es antes de las 5 de la tarde 
							BEGIN
								SET @exento=1;
							END
							ELSE
							BEGIN 
								IF(DATEPART(hour,getdate())<5)--MES NOCTURNO y es antes de las 5 de la MANANA
									BEGIN
										SET @exento=1;
									END
							END
					END
				INSERT INTO ServicioPorHora(idCliente,cedula,placa,clienteXMes,exento,horaDeEntrada) 
				values (@idClienteVar,@cedula,@placa,'Y',@exento,getdate());--INSERTAR EL SERVICIO POR HORAS PARA UN CLIENTE MENSUAL
			END


   COMMIT TRANSACTION

END TRY
BEGIN CATCH
  IF @@TRANCOUNT > 0
     ROLLBACK TRANSACTION
END CATCH