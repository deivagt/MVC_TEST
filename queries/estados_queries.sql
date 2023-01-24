create table estados
(
    id int IDENTITY(1,1) PRIMARY KEY,
    estado varchar(50)
);


select * from estados;

INSERT INTO estados values ('Como nuevo');
INSERT INTO estados values ('Muy bueno');
INSERT INTO estados values ('Bueno');
INSERT INTO estados values ('Regular');
INSERT INTO estados values ('Danado');
INSERT INTO estados values ('Muy Danado');

-- create PROCEDURE insertar_estado
--    @estado varchar(50)
-- AS
-- INSERT INTO dbo.estados
-- VALUES
--     (@estado)
--     GO


-- CREATE PROCEDURE obtener_estado
--     @id int
-- AS
-- SELECT *
-- FROM dbo.estados
-- where id = @id;
--     GO



    -- CREATE PROCEDURE eliminar_estado
    --     @id int
    -- AS
    -- DELETE FROM dbo.estados where id = @id
    -- GO



-- CREATE PROCEDURE actualizar_estado
-- @id int,
--     @estado varchar(50)
-- AS
-- UPDATE dbo.estados SET
--         estado = @estado
--     WHERE id = @id 
--     GO
