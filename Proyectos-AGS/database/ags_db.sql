     

create database AGS_db
use AGS_db

create table usuarios (id int not null auto_increment, 
nombre varchar(50), 
apellido varchar(50),
mail varchar(50),
telefono varchar(50), primary key(id))

create table servicios (idServicio int not null auto_increment, 
nombreServicio varchar(50),
descripcionServicios varchar(1000), primary key(idServicio))

create table proyectos_completados (idProyectos int not null auto_increment, 
nombreProyecto varchar(50),
descripcionProyectos varchar(1000), 
nombre_img varchar(50), primary key(idProyectos))

create table empleados(idEmpleado int not null auto_increment, 
nombreEmpleado varchar(50), 
apellidoEmpleado varchar(50),
puesto varchar(50), primary key(idEmpleado))




