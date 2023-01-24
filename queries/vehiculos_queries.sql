

create TABLE vehiculos
(
    id int IDENTITY(100,1) PRIMARY KEY NOT NULL,
    marca varchar(25),
    color varchar(15),
    modelo int,
    precio money,
    fechaRec DATETIME,
    idEstado int FOREIGN KEY REFERENCES dbo.estados(id)
)
drop table vehiculos
SELECT * from vehiculos;

insert into vehiculos values ('bmw', 'rojo',2005,100000.00, '2010-01-01', 3);
insert into vehiculos values ('subaru', 'azul',2013,10000.00, '2013-01-01', 3);
insert into vehiculos values ('Toyota', 'Negro',2015,40000.00, '2016-01-01', 3);


-- ALTER PROCEDURE insertar_Vehiculo
--     @marca varchar(25),
--     @color varchar(15),
--     @modelo int,
--     @precio money,
--     @fechaRec DATETIME,
--     @idEstado int
-- AS
-- INSERT INTO dbo.vehiculos
-- VALUES
--     (@marca, @color, @modelo,@precio, @fechaRec,@idEstado)
--     GO

-- CREATE PROCEDURE obtener_vehiculo_estado
-- @id int
-- AS
-- SELECT dbo.vehiculos.*, dbo.estados.estado FROM dbo.vehiculos  
-- JOIN dbo.estados ON dbo.vehiculos.idEstado =  dbo.estados.id
--  where dbo.vehiculos.idEstado = @id;
--     GO


-- ALTER PROCEDURE obtener_Vehiculo
--     @id int
-- AS
-- SELECT dbo.vehiculos.*, dbo.estados.estado FROM dbo.vehiculos  
-- JOIN dbo.estados ON dbo.vehiculos.idEstado =  dbo.estados.id
--  where dbo.vehiculos.id = @id;
--     GO

-- EXEC obtener_Vehiculo 101

-- --     CREATE PROCEDURE eliminar_Vehiculo
-- --         @id int
-- --     AS
-- --     DELETE FROM dbo.vehiculos where id = @id
-- --     GO



-- ALTER PROCEDURE actualizar_Vehiculo
-- @id int,
--     @marca varchar(25),
--     @color varchar(15),
--     @modelo int,
--     @precio money,
--     @fechaRec DATETIME,
--     @idEstado int
-- AS
-- UPDATE dbo.vehiculos SET
--         marca = @marca,
--         color = @color,
--         modelo = @modelo,
--         precio = @precio,
--         fechaRec = @fechaRec,
--         idEstado = @idEstado
--     WHERE id = @id 
--     GO
