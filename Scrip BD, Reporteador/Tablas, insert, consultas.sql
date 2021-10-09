-- -----------------------------------------------------
-- BD prov
-- -----------------------------------------------------
create database provisional;
use provisional;

Create Table Modulos (
IdModulo varchar(15) NOT NULL,
PRIMARY KEY (IdModulo),
Nombre varchar(50) NOT NULL,
Estado boolean NOT NULL
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

INSERT INTO Modulos VALUES ('D1','Contabilidad',1);
INSERT INTO Modulos VALUES ('D2','RRHH',1);
INSERT INTO Modulos VALUES ('D3','Hoteleria',1);
INSERT INTO Modulos VALUES ('D4','Compras',1);
INSERT INTO Modulos VALUES ('D5','Seguridad',1);
INSERT INTO Modulos VALUES ('D6','Bancos',1);

Create Table Aplicacion (
IdAplicacion varchar(15) NOT NULL,
PRIMARY KEY (IdAplicacion),
Nombre varchar(45) NOT NULL,
IdModulo varchar(15) NOT NULL,
Estado varchar(1) NOT NULL,
foreign key (IdModulo) references Modulos (IdModulo)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

INSERT INTO Aplicacion VALUES ('A1','Aplicacion1','D1',1);
INSERT INTO Aplicacion VALUES ('A2','Aplicacion2','D2',1);
INSERT INTO Aplicacion VALUES ('A3','Aplicacion3','D3',1);
INSERT INTO Aplicacion VALUES ('A4','Aplicacion4','D4',1);

Create Table Reportes (
IdReporte varchar(15) NOT NULL,
PRIMARY KEY (IdReporte),
Nombre varchar(20) NOT NULL,
Ruta varchar(2500) NOT NULL,
IdAplicacion varchar(20) NOT NULL,
Estado boolean NOT NULL,
foreign key (IdAplicacion) references Aplicacion (IdAplicacion)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

INSERT INTO Reportes VALUES ('R1', 'Reporte1',"C:\Users\Grupo4\OCReporteador2.0\ObjetoReporteador\Report1.rpt", 'A1', 1);
INSERT INTO Reportes VALUES ('R2', 'Reporte2',"C:\Users\Grupo4\OCReporteador2.0\ObjetoReporteador\Report1.rpt", 'A2', 1);
INSERT INTO Reportes VALUES ('R3', 'Reporte3',"C:\Users\Grupo4\OCReporteador2.0\ObjetoReporteador\Report1.rpt", 'A3', 1);
INSERT INTO Reportes VALUES ('R4', 'Reporte4',"C:\Users\Grupo4\OCReporteador2.0\ObjetoReporteador\Report1.rpt", 'A4', 1);

select * from Reportes;
select * from aplicacion;
select * from modulos;

SELECT aplicacion.IdAplicacion, aplicacion.Nombre, aplicacion.IdModulo, aplicacion.Estado, modulos.Nombre, modulos.Estado
FROM aplicacion  
INNER JOIN modulos  
ON aplicacion.IdModulo = modulos.IdModulo;

SELECT aplicacion.IdAplicacion, aplicacion.Nombre, aplicacion.Estado, aplicacion.IdModulo, modulos.Nombre, modulos.Estado
FROM aplicacion  
INNER JOIN modulos  
ON aplicacion.IdModulo = modulos.IdModulo;

#delete from Reportes;
#delete from departamentos;

#Select IdDepartamento from departamentos where nombredepartamento = "Seguridad";
#Select * from Reportes where nombreReporte = "Pagos";
#Select IdDepartamento from departamentos where nombredepartamento = 'Bancos'; 