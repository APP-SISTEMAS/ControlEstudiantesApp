-- Crear la base de datos
CREATE DATABASE ControlEstudiantes
GO

-- Usar la base de datos creada
USE ControlEstudiantes
GO

-- Crear la tabla Departamento
CREATE TABLE Departamento (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre VARCHAR(30) UNIQUE NOT NULL
)
GO

-- Crear la tabla Municipio
CREATE TABLE Municipio (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    id_departamento INT NOT NULL,
    municipio VARCHAR(30) UNIQUE NOT NULL,
    FOREIGN KEY (id_departamento) REFERENCES Departamento(id)
)
GO

-- Crear la tabla Tipo_Sangre
CREATE TABLE Tipo_Sangre (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre VARCHAR(5) UNIQUE NOT NULL
)
GO

-- Crear la tabla Estudiante
CREATE TABLE Estudiante (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre VARCHAR(20) NOT NULL,
    apellido VARCHAR(20) NOT NULL,
    fecha_nacimiento SMALLDATETIME NOT NULL,
    identidad VARCHAR(20) NOT NULL,
    genero CHAR(1) NOT NULL CHECK (genero IN ('M', 'F')),
    activo BIT NOT NULL,
    telefono VARCHAR(20),
    id_departamento INT NOT NULL,
    id_municipio INT NOT NULL,
    direccion VARCHAR(100) NOT NULL,
    correo VARCHAR(30),
    id_tipo_sangre INT NOT NULL,
    tutor VARCHAR(50) NOT NULL,
    FOREIGN KEY (id_departamento) REFERENCES Departamento(id),
    FOREIGN KEY (id_municipio) REFERENCES Municipio(id),
    FOREIGN KEY (id_tipo_sangre) REFERENCES Tipo_Sangre(id)
)
GO

-- Crear la tabla Estudiante_Activo
CREATE TABLE Estudiante_Activo (
    id_estudiante INT PRIMARY KEY NOT NULL,
    estado BIT NOT NULL,
    motivo VARCHAR(100),
    FOREIGN KEY (id_estudiante) REFERENCES Estudiante(id)
)
GO

-- Crear la tabla Asignatura
CREATE TABLE Asignatura (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre VARCHAR(20) NOT NULL
)
GO

-- Crear la tabla Notas
CREATE TABLE Notas (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    id_estudiante INT NOT NULL,
    id_asignatura INT NOT NULL,
    nota1 DECIMAL(5, 2),
    nota2 DECIMAL(5, 2),
    nota3 DECIMAL(5, 2),
    nota4 DECIMAL(5, 2),
    promedio DECIMAL(5, 2),
    aprobado BIT,
    FOREIGN KEY (id_estudiante) REFERENCES Estudiante(id),
    FOREIGN KEY (id_asignatura) REFERENCES Asignatura(id)
)
GO