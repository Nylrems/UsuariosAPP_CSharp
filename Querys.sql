--Insertar Usuarios
create proc insertar_usuarios
@Usuario as varchar(150),
@Pass varchar(150),
@Icono image,
@Estado varchar(150)
as 
if Exists (Select Usuario from Usuarios where Usuario=@Usuario)
Raiserror('El usuario ya se encuentra registrado', 16, 1)
else
insert into Usuarios
values(@Usuario, @Pass, @Icono, @Estado)

--Mostrar usuarios

create proc mostrar_usuarios
as 
select*from Usuarios

--Editar Usuarios

create proc editar_usuarios
@Id_usuario int,
@Usuario as varchar(150),
@Pass varchar(150),
@Icono image,
@Estado varchar(150)
as
if exists (select Usuario from Usuarios where Usuario = @Usuario and Id_usuario<>@Id_usuario)
raiserror ('El usuario está en uso, elige otro nombre de usuario', 16,1)
else
update Usuarios set Usuario=@Usuario, Pass = @Pass, Icono = @Icono, Estado = @Estado
where Id_usuario = @Id_usuario

--Eliminar Usuarios

create proc eliminar_usuarios
@Id_usuario int
as
delete from Usuarios where Id_usuario=@Id_usuario

--Buscar Usuarios

create proc buscar_usuarios
@buscador varchar(50)
as
select * from Usuarios
where Usuario+Pass like '%' + @buscador + '%'


