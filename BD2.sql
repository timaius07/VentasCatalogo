CREATE TABLE articulo
(
  cod_art text NOT NULL,
  nombre_art text,
  cantidad_invt integer,
  precio_cost numeric,
  porc_util numeric,
  precio_venta numeric,
  cod_marca integer NOT NULL,
  cod_categoria integer NOT NULL,
  fecha_compra date,
  impuesto boolean,
  aplicadesc boolean,
  CONSTRAINT pk_articulo PRIMARY KEY (cod_art),
  CONSTRAINT articulo_nombre_art_key UNIQUE (nombre_art)
)

CREATE TABLE categoria
(
  id_categ serial NOT NULL,
  descrip_categ text,
  CONSTRAINT pk_departamento PRIMARY KEY (id_categ),
  CONSTRAINT categoria_descrip_categ_key UNIQUE (descrip_categ)
)

CREATE TABLE marca
(
  id_marca serial NOT NULL,
  descrip_marca text,
  CONSTRAINT pk_catalogo PRIMARY KEY (id_marca),
  CONSTRAINT uq_marca_descrip_marca UNIQUE (descrip_marca)
)

CREATE TABLE cliente
(
  id_cliente serial NOT NULL,
  cedula text,
  nombre text,
  apellidos text,
  direcion text,
  email text,
  numtelf text,
  numcel text,
  cuentas_pend boolean,
  CONSTRAINT pk_cliente PRIMARY KEY (id_cliente)
)
CREATE TABLE facturaprov
(
  id_factprov serial not null,
  num_factprov text NOT NULL,
  idprove integer,
  fecha date,
  formapago text,
  observaciones text,
  apllicainv boolean,
  finalfact boolean,
  montofact numeric,
  CONSTRAINT pk_facturaprov PRIMARY KEY (id_factprov),
  CONSTRAINT fk_provedor_facturaprov FOREIGN KEY (idprove)
      REFERENCES provedor (id_provedor) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT facturaprov_num_factprov_key UNIQUE (num_factprov)
)

CREATE TABLE articprove
(
  id_artprov serial NOT NULL,
  num_factartp text NOT NULL,
  descripart text NOT NULL,
  cantidad integer,
  precio numeric,
  subtotal numeric,
  porcdesc numeric,
  montodec numeric,
  subtodesc numeric,
  montociv numeric,
  subtoiv numeric,
  totalfin numeric,
  cod_arti text,
  iv boolean,
  rel_factprove integer not null,
  CONSTRAINT pk_articprove PRIMARY KEY (id_artprov),
  CONSTRAINT fk_articprove_facturaprov FOREIGN KEY (rel_factprove)
      REFERENCES facturaprov (id_factprov) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
**************************************************************************

CREATE TABLE usuario
(
  id_usuario serial NOT NULL,
  nomb_usu text NOT NULL,
  pass_usu text NOT NULL,
  CONSTRAINT pk_usuario PRIMARY KEY (id_usuario)
)

CREATE TABLE provedor
(
  id_provedor serial NOT NULL,
  cedula text,
  razonsocial text,
  razoncomercial text,
  direcion text,
  email text,
  numtelf text,
  numcel text,
  diascredito integer,
  CONSTRAINT pk_provedor PRIMARY KEY (id_provedor)
)

agregar nuevo campo en tabla
ALTER TABLE articulo ADD aplicadesc boolean;
establecer columna unique despues de crear
ALTER TABLE facturaprov 
ADD UNIQUE (num_factprov)

***selecciona de 2 tablas relacionadas join
select facturaprov.num_factprov, provedor.razonsocial, facturaprov.montofact
FROM
 facturaprov  Natural JOIN  provedor where(facturaprov.idprove = provedor.id_provedor)


//*** se crean las llaves foraneas para catalogo y departamento
--relacion entre la tabla articulo y la tabla catalogo
ALTER TABLE articulo ADD CONSTRAINT FK_articuloo_marca FOREIGN KEY (cod_marca) REFERENCES marca (id_marca)
--relacion entre la tabla articulo y tabla departamento
ALTER TABLE articulo ADD CONSTRAINT FK_articuloo_categoria FOREIGN KEY (cod_categoria) REFERENCES categoria (id_categ)
--relacion entre la tabla provedor y tabla facturaprov
ALTER TABLE provedor ADD CONSTRAINT FK_provedor_facturaprov FOREIGN KEY (id_provedor) REFERENCES facturaprov (idprove)





//*********************************tablas pendientes
 CREATE TABLE Pedido(
	id_pedido serial NOT NULL,
	cod_articulo varchar NOT NULL,
	cod_cliente integer NOT NULL,
	cantidad integer NULL,
	estado_pedi boolean NOT NULL,
	fecha_pedi date null,
CONSTRAINT PK_Pedido PRIMARY KEY (id_pedido))


 CREATE TABLE Abono(
	id_abono serial NOT NULL,
	cod_fact integer NOT NULL,
	fecha_abon date NULL,
	monto_abono float NOT NULL,
 CONSTRAINT PK_Abono PRIMARY KEY (id_abono))


CREATE TABLE CUENTASXCOBRAR(

)

--relacion entre la tabla Pedido y la tabla Articulo (obtener informacion de la Articulo necesaria en el pedido)
ALTER TABLE Pedido ADD CONSTRAINT FK_Pedido_Articulo FOREIGN KEY (cod_articulo) REFERENCES Articulo (cod_art)
--relacion entre la tabla pedido y la tabla cliente
ALTER TABLE Pedido ADD  CONSTRAINT FK_Pedido_Cliente FOREIGN KEY(cod_cliente) REFERENCES Cliente (id_cliente)
--relacion entre la tabla factura y la tabla cliente 
ALTER TABLE Factura ADD CONSTRAINT FK_Factura_Cliente FOREIGN KEY (cod_cliente) REFERENCES Cliente (id_cliente)
--relacion entre la tabla abono y la tabla factura
ALTER TABLE Abono ADD CONSTRAINT FK_Abono_Factura FOREIGN KEY (cod_fact) REFERENCES Factura (num_fact)
--relacion entre la tabla articulo y la tabla catalogo
ALTER TABLE Articulo ADD CONSTRAINT FK_Articulo_Catalogo FOREIGN KEY (cod_catalogo) REFERENCES Catalogo (id_catalogo)
--relacion entre la tabla articulo y tabla departamento
ALTER TABLE Articulo ADD CONSTRAINT FK_Articulo_Familia FOREIGN KEY (cod_familia) REFERENCES Departamento (id_depart)


select factura.num_fact, cliente.nombre
FROM
 factura  Natural JOIN  Cliente where(factura.cod_cliente= cliente.id_cliente)
agregar columna
ALTER TABLE articulo add  impuesto bool

88877348