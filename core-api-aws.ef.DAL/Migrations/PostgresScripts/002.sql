﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241022070744_initMigration') THEN
        IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'sample_poc') THEN
            CREATE SCHEMA sample_poc;
        END IF;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241022070744_initMigration') THEN
    CREATE TABLE sample_poc."Students" (
        "Id" text NOT NULL,
        "FirstName" text,
        "LastName" text,
        "Class" integer NOT NULL,
        "Country" text,
        CONSTRAINT "PK_Students" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241022070744_initMigration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241022070744_initMigration', '9.0.0-rc.2.24474.1');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241022173517_ClasDetailsWithHistory') THEN
    ALTER TABLE sample_poc."Students" RENAME COLUMN "Class" TO "ClassId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241022173517_ClasDetailsWithHistory') THEN
    CREATE TABLE sample_poc."Classes" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Name" text NOT NULL,
        CONSTRAINT "PK_Classes" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241022173517_ClasDetailsWithHistory') THEN
    CREATE TABLE sample_poc."ClassesHistory" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "ClassId" integer NOT NULL,
        "Year" integer NOT NULL,
        "PassPercentage" double precision NOT NULL,
        "MaxPercentage" double precision NOT NULL,
        "TeacherName" text,
        CONSTRAINT "PK_ClassesHistory" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241022173517_ClasDetailsWithHistory') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241022173517_ClasDetailsWithHistory', '9.0.0-rc.2.24474.1');
    END IF;
END $EF$;
COMMIT;

