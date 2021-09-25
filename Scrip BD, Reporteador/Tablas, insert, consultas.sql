create database provisional;
use provisional;

Create Table departamentos (
IdDepartamento varchar(15) NOT NULL,
PRIMARY KEY (IdDepartamento),
nombredepartamento varchar(50) NOT NULL,
estado boolean NOT NULL
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

insert into departamentos values ('D1','Contabilidad',1);
insert into departamentos values ('D2','Analisis',1);
insert into departamentos values ('D3','Disenio',1);
insert into departamentos values ('D4','Infraestrutura',1);
insert into departamentos values ('D5','Seguridad',1);

Create Table Reportes (
idReporte varchar(15) NOT NULL,
PRIMARY KEY (idReporte),
nombreReporte varchar(20) NOT NULL,
rutaReporte varchar(100) NOT NULL,
IdDepartamento varchar(20) NOT NULL,
estado boolean NOT NULL,
foreign key (IdDepartamento) references departamentos (IdDepartamento)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

INSERT INTO Reportes (idReporte, nombreReporte, rutaReporte, IdDepartamento, estado) 
VALUES (1, 'Pagos agosto','C:\Users\alvar\source\repos\Report\VistaReport\bin\Debug','D1', 1);

INSERT INTO Reportes (idReporte, nombreReporte, rutaReporte, IdDepartamento, estado) 
VALUES (2, 'Pagos septiembre','C:\Users\source\repos\Report\bin\Debug','D2', 1);

INSERT INTO Reportes (idReporte, nombreReporte, rutaReporte, IdDepartamento, estado) 
VALUES (3, 'Pagos octubre','C:\Users\source\repos\Report\VistaReport\bin','D1', 1);

delete from departamentos;
select * from departamentos;
select * from Reportes;
-- delete from Reportes;

Select IdDepartamento from departamentos where nombredepartamento = "Seguridad";