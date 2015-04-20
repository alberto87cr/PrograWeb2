CREATE FUNCTION fn_hayEspaciosDisponibles()
returns bit
as
begin
	declare @disponibles bit;
	declare @vacios int;
	select @vacios=count(id) from EspacioParqueo where disponible=1;
	if(@vacios>=1)
	begin
		set @disponibles=1;
	end
	else
		set @disponibles=0;

	return @disponibles;--retorna si existen espacios disponibles en el parqueo 
end;