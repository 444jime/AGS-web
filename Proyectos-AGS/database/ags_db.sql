select * from carrusel

create table user (
id int not null auto_increment, 
nombre varchar(50), 
apellido varchar(50),
contrasena varchar(255), 
mail varchar(50),
telefono varchar(50),
requiere_cambio_contrasena varchar(255),
primary key(id)
)

create table Proyecto (
id int not null auto_increment, 
nombre varchar(50), 
descripcion varchar(255),
imagen varchar(50), 
primary key(id)
)