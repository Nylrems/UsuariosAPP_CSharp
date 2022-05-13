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

