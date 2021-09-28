Use Negocios2021
go

--PREGUNTA 1 

/*procedure donde liste los registros de tb_pedidoscabe (idpedido, fechaPedido, direccionDestinatario, ciudadDestinatario) 
por un año del campo FechaPedido */

create procedure  usp_lista_pedidos_anio

@y int

As

Select IdPedido,FechaPedido,DireccionDestinatario, CiudadDestinatario

from tb_pedidoscabe 

Where YEAR(FechaPedido)= @y

go

exec usp_lista_pedidos_anio 2010
go


/*Procedure donde liste los años del campo fechaPedido, los cuales no se repitan DISTINCT 
y ordenarlos por el año en forma ASC*/

create proc usp_listar_anio

As

Select DISTINCT (YEAR(FechaPedido))as Fecha from tb_pedidoscabe
order by  YEAR(FechaPedido) asc 
go

exec usp_listar_anio

--PREGUNTA 2


Use Negocios2021
Create table tb_productoBI
(
	idproducto int primary key,
	desproducto varchar(255) not null,
	umedida varchar(50) not null,
	idcategoria int references tb_categorias,
	idproveedor int references tb_proveedores,
	preUni decimal
)
go

insert tb_productoBI
Select IdProducto, NombreProducto,umedida,IdCategoria,IdProveedor,PrecioUnidad
from tb_productos
go

select * from tb_productoBI
go

/*CRUD procedures*/

--agregar
create proc usp_productoBI_add

@idproducto int,
@desproducto varchar(255),
@umedida varchar(50),
@idcategoria int,
@idproveedor int,
@preUni decimal

As

Insert tb_productoBI Values(@idproducto,@desproducto,@umedida,@idcategoria,@idproveedor,@preUni)

go


--eliminar
create proc usp_productoBI_delete

@idproducto int

As

Delete tb_productoBI 

Where idproducto=@idproducto

go


--listar prod
create proc usp_productoBI_listado

As

Select * from tb_productoBI

go


--listar categ
create procedure usp_categoria_listado

As

Select IdCategoria, NombreCategoria from tb_categorias

go

--listar proveedor
create procedure usp_proveedores_listado

As

Select IdProveedor, NombreCia from tb_proveedores

go


