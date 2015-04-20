USE PARQUEODB
GO
/**Tipo de Servicio por mes**/
CREATE TABLE TipoServicio(
	id int not null,
	descripcion varchar (50) not null
	CONSTRAINT pk_tipoServicio PRIMARY KEY (id),
)


/**Clientes por mes**/
CREATE TABLE Clientes(
	id int identity,
	cedula varchar (25) NOT NULL,
	nombre varchar (50) NOT NULL,
	apellido1 varchar (50) NOT NULL,
	apellido2 varchar (50) NOT NULL,
	telefono varchar (15) NOT NULL,
	placa varchar (6)  NOT NULL,
	tipoServicio int not null,
	estado bit default 1 not null
	CONSTRAINT pk_clientesXMes PRIMARY KEY (id),
	CONSTRAINT fk_cliente_tipoServicio FOREIGN KEY (tipoServicio) references tipoServicio (id)
)

/**Servicio por mes**/
CREATE TABLE ServicioPorMes(
	idServicio int identity,
	idCliente int,
	fechaDeInicio smalldatetime,
	fechaFinal smalldatetime
	CONSTRAINT pk_ServicioPorMes PRIMARY KEY (idServicio)
)

/**Servicio por hora**/
CREATE TABLE ServicioPorHora(
	idServicio int identity,
	idCliente int,
	cedula varchar (25),
	placa varchar (6) NOT NULL,
	clienteXMes varchar (1) NOT NULL,--indica si es cliente mensual
	exento int not null,--indica si debe pagar por el servicio o no 
	horaDeEntrada smalldatetime NOT NULL,
	horaDeSalida smalldatetime,
	CONSTRAINT pk_clientesXHora PRIMARY KEY (idServicio)
)

/**Facturacion por Mes**/
CREATE TABLE FacturaPorMes(
	idCliente int,
	fechaDePago smalldatetime NOT NULL,
	monto decimal NOT NULL,
	CONSTRAINT pk_clientesXMesFacturaMes PRIMARY KEY (cedulaCliente,fechaDePago),
	CONSTRAINT FK_CLIENTE_MES FOREIGN KEY (idCliente) references ClientesPorMes (id)
)

/**Facturacion por hora**/
CREATE TABLE FacturaPorHora(
	idFactura int identity,
	idServicio int,
	monto decimal,
	fechaDePago smalldatetime,
	CONSTRAINT pk_clientesXMesFacturaHora PRIMARY KEY (idFactura),
	CONSTRAINT FK_Factura_ServicioHora FOREIGN KEY (idServicio) references ServicioPorHora (idServicio)
)

/** Tipo Tarifas**/
CREATE TABLE TipoTarifas(
	tipoTarifa int,
	descripcion varchar (50)
	CONSTRAINT pk_TipoTarifa PRIMARY KEY (tipoTarifa),
)

/**Tarifas**/
CREATE TABLE Tarifas(
	tipoTarifa int,
	monto decimal
	CONSTRAINT pk_Tarifa PRIMARY KEY (tipoTarifa),
	CONSTRAINT FK_Tarifa_TipoTarifa FOREIGN KEY (tipoTarifa) references TipoTarifas (tipoTarifa)
)

/**Roles: admin,usuario **/
CREATE TABLE Roles(
	id int NOT NULL,
	descripcion varchar (15),
	CONSTRAINT pk_idRol PRIMARY KEY (id)
)

/**Usuarios**/
CREATE TABLE Usuarios(
	cedula varchar (9) NOT NULL,
	rol int,
	CONSTRAINT pk_usuarioCedula PRIMARY KEY (cedula),
	constraint fk_rol FOREIGN KEY (rol) REFERENCES Roles (id)
)

/**Espacios del parqueo**/
CREATE TABLE EspacioParqueo(
	id int NOT NULL,
	disponible bit not null,--indica si esta vacio o no
	CONSTRAINT pk_idParqueo PRIMARY KEY (id)
)

/**Cambio dolar**/
CREATE TABLE Dolar (
	tipoDeCambio decimal
)







