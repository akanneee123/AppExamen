CREATE DATABASE DataBaseGestionPersonalProyectos;
GO

USE DataBaseGestionPersonalProyectos;
GO

-- Tabla Categorias
CREATE TABLE Categorias (
    ID_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria NVARCHAR(50) NOT NULL UNIQUE
);

-- Insertar valores iniciales para las categorías
INSERT INTO Categorias (NombreCategoria) VALUES ('Administrador');
INSERT INTO Categorias (NombreCategoria) VALUES ('Operario');
INSERT INTO Categorias (NombreCategoria) VALUES ('Peón');

-- Tabla Empleados
CREATE TABLE Empleados (
    ID_Empleado INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Direccion NVARCHAR(100) DEFAULT 'San José',
    Telefono NVARCHAR(15) NULL,
    Correo NVARCHAR(100) UNIQUE NOT NULL,
    Salario DECIMAL(10,2) DEFAULT 250000 CHECK (Salario >= 250000 AND Salario <= 500000),
    ID_Categoria INT NOT NULL,
    FOREIGN KEY (ID_Categoria) REFERENCES Categorias(ID_Categoria)
);

-- Crear tabla de Proyectos
CREATE TABLE Proyectos (
    ID_Proyecto INT IDENTITY(1,1) PRIMARY KEY,
    NombreProyecto NVARCHAR(100) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NULL
);

-- Restricción CHECK para FechaFin
ALTER TABLE Proyectos
ADD CONSTRAINT CHK_FechaFin CHECK (FechaFin IS NULL OR FechaFin >= FechaInicio);

-- Tabla Asignaciones (relación muchos a muchos)
CREATE TABLE Asignaciones (
    ID_Asignacion INT IDENTITY(1,1) PRIMARY KEY,
    ID_Empleado INT NOT NULL,
    ID_Proyecto INT NOT NULL,
    FechaAsignacion DATE NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ID_Empleado) REFERENCES Empleados(ID_Empleado),
    FOREIGN KEY (ID_Proyecto) REFERENCES Proyectos(ID_Proyecto),
    CONSTRAINT UQ_Empleado_Proyecto UNIQUE (ID_Empleado, ID_Proyecto) -- Un empleado no puede ser asignado dos veces al mismo proyecto
);

-- Insertar un ejemplo de empleado
INSERT INTO Empleados (NombreCompleto, FechaNacimiento, Correo, ID_Categoria)
VALUES ('Juan Pérez', '1990-05-15', 'juan.perez@empresa.com', 1);

-- Insertar un ejemplo de proyecto
INSERT INTO Proyectos (NombreProyecto, FechaInicio)
VALUES ('Construcción de Puente Principal', '2024-01-01');

-- Asignar empleado a proyecto
INSERT INTO Asignaciones (ID_Empleado, ID_Proyecto)
VALUES (1, 1);

-- Consultar datos
SELECT * FROM Empleados;
SELECT * FROM Proyectos;
SELECT * FROM Asignaciones;

-- Ver todas las asignaciones
SELECT A.ID_Asignacion, E.NombreCompleto, P.NombreProyecto, A.FechaAsignacion
FROM Asignaciones A
JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
JOIN Proyectos P ON A.ID_Proyecto = P.ID_Proyecto;

-- Mostrar asignaciones con nombre del proyecto por empleado específico
DECLARE @ID_Empleado INT = 1; -- ID de prueba
SELECT 
    A.ID_Asignacion, 
    P.NombreProyecto, 
    A.FechaAsignacion
FROM Asignaciones A
JOIN Proyectos P ON A.ID_Proyecto = P.ID_Proyecto
WHERE A.ID_Empleado = @ID_Empleado;

-- Mostrar asignaciones con nombre del empleado por proyecto específico
DECLARE @ID_Proyecto INT = 1; -- ID de prueba
SELECT 
    E.NombreCompleto, 
    A.FechaAsignacion
FROM Asignaciones A
JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
WHERE A.ID_Proyecto = @ID_Proyecto;


