-- ==================================================
-- Author:		Mario Beltran
-- Create Date: 2024/02/17
-- Description: creacion de la DB para FleetRutePro
-- ==================================================

PRINT 'creacion de la DB'
GO
IF NOT EXISTS(SELECT NAME FROM SYSDATABASES WHERE NAME = 'Fleet_Rute_Pro')
BEGIN
    CREATE DATABASE Fleet_Rute_Pro
END 
GO

USE Fleet_Rute_Pro
GO

PRINT 'creacion de la tabla Users'
IF NOT EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Users')
BEGIN
    CREATE TABLE dbo.Users(
        ID           VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT '', /*id interno del registro*/
        Users        VARCHAR(1000) NOT NULL DEFAULT '',          /*correo del usuario*/
        passw        VARCHAR(255) NOT NULL DEFAULT '',          /*Contraseña del usuario (almacenar hashes seguros en lugar de contraseñas en texto plano)*/
        Rol          VARCHAR(60) NOT NULL DEFAULT 'Cliente',   /*Rol del usuario*/       
        Fechalog     SMALLDATETIME DEFAULT CURRENT_TIMESTAMP  /*log fecha*/
    ) 
END
GO

PRINT 'creacion de la tabla Vehicles'
IF NOT EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Vehicles')
BEGIN
    CREATE TABLE dbo.Vehicles(
        ID            VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT '', /*id interno del registro*/
        Descriptionn  VARCHAR(1000) NOT NULL DEFAULT '',          /*descripcion del vehiculo*/
        Yearr         INT NOT NULL DEFAULT '',                   /*año de fabricacion del vehiculo*/
        Make          VARCHAR(60) NOT NULL DEFAULT '',          /*marca del vehiculo*/       
        Capacity      INT NOT NULL DEFAULT '',                 /*capacidad del vehiculo*/
        Active        BIT NOT NULL DEFAULT 1                  /*estado del vehiculo*/
    ) 
END
GO

PRINT 'creacion de la tabla Routes'
IF NOT EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Routes')
BEGIN
    CREATE TABLE dbo.Routes(
        ID              VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT '', /*id interno del registro*/
        Descriptionn    VARCHAR(1000) NOT NULL DEFAULT '',          /*descripcion de la ruta*/
        DriverId        VARCHAR(36) NOT NULL DEFAULT '',           /*id del conductor de la ruta*/
        VehicleId       VARCHAR(36) NOT NULL DEFAULT '',          /*id del vehiculo de la ruta*/       
        Active          BIT NOT NULL DEFAULT 1                   /*estado de la ruta*/
    ) 
END
GO

PRINT 'creacion de la tabla Schedules'
IF NOT EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Schedules')
BEGIN
    CREATE TABLE dbo.Schedules(
        ID           VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT '', /*id interno del registro*/
        RouteId      VARCHAR(36) NOT NULL DEFAULT '',            /*id de la ruta*/
        WeekNum      INT NOT NULL DEFAULT '',                   /*numero de la semana*/
        Fromm        VARCHAR(60) NOT NULL DEFAULT '',          /*desde*/       
        Too          VARCHAR(60) NOT NULL DEFAULT '',         /*hasta*/
        Active       BIT NOT NULL DEFAULT 1                  /*estado del horario*/
    ) 
END
GO

PRINT 'creacion de la tabla Drivers'
IF NOT EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Drivers')
BEGIN
    CREATE TABLE dbo.Drivers(
        ID           VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT '', /*id interno del registro*/
        Last_Name    VARCHAR(1000) NOT NULL DEFAULT '',          /*apellido del conductor*/
        First_Name   VARCHAR(255) NOT NULL DEFAULT '',          /*nombre del conductor*/
        Ssn          VARCHAR(60) NOT NULL DEFAULT '',          /*ssn del conductor*/       
        Dob          SMALLDATETIME NOT NULL DEFAULT '',       /*fecha de nacimiento del conductor*/
        Addresss     VARCHAR(1000) NOT NULL DEFAULT '',      /*direccion del conductor*/
        City         VARCHAR(1000) NOT NULL DEFAULT '',     /*ciudad del conductor*/
        Zip          VARCHAR(1000) NOT NULL DEFAULT '',    /*zip del conductor*/
        Phone        INT NOT NULL DEFAULT '',             /*telefono del conductor*/
        Active       BIT NOT NULL DEFAULT 1              /*estado del conductor*/
    ) 
END
GO