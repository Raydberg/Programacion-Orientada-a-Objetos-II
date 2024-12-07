# Procedimientos Almacenados usados de la base de datos BDVIAJES2022_CL02

## Procedimiento Almacenado: `ListarViajes`

```sql
CREATE PROCEDURE ListarViajes
    @cod_rut CHAR(4) = NULL,
    @cod_chof CHAR(4) = NULL,
    @hrs_sal VARCHAR(5) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        v.cod_rut,
        v.cod_chof,
        c.nom_chof,
        r.des_rut,
        v.hrs_sal,
        v.costo_via,
        v.nro_via
    FROM 
        Viajes v
    INNER JOIN 
        Chofer c ON v.cod_chof = c.cod_chof
    INNER JOIN 
        Rutas r ON v.cod_rut = r.cod_rut
    WHERE 
        (@cod_rut IS NULL OR v.cod_rut = @cod_rut) AND
        (@cod_chof IS NULL OR v.cod_chof = @cod_chof) AND
        (@hrs_sal IS NULL OR v.hrs_sal = @hrs_sal);
END;
# Ejemplo de uso
EXEC ListarViajes @cod_rut = 'LMTA', @cod_chof = 'C001', @hrs_sal = '10:30';
```

## Procedimiento Almacenado: `ActualizarViaje`

```sql
CREATE PROCEDURE ActualizarViaje
    @nro_via CHAR(6), 
    @cod_rut CHAR(4) = NULL,
    @cod_chof CHAR(4) = NULL,
    @hrs_sal VARCHAR(5) = NULL,
    @costo_via DECIMAL(8, 2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Viajes
    SET 
        cod_rut = COALESCE(@cod_rut, cod_rut),
        cod_chof = COALESCE(@cod_chof, cod_chof),
        hrs_sal = COALESCE(@hrs_sal, hrs_sal),
        costo_via = COALESCE(@costo_via, costo_via)
    WHERE 
        nro_via = @nro_via;
END;
# Ejemplo de uso
EXEC ActualizarViaje
    @nro_via = '100001', @costo_via= 89.00
```
