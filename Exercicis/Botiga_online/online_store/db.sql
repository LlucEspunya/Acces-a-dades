create database Store;
use Store
CREATE TABLE "Familia" (
    "ID" UNIQUEIDENTIFIER,
	"Familia"	NVARCHAR(20),
	"Desc"	NVARCHAR(MAX),
	PRIMARY KEY("ID")
);

CREATE TABLE "Producte" (
	"ID"	UNIQUEIDENTIFIER,
    "CODI"  CHAR(8),
	"Desc"	TEXT,
	"Preu"	DECIMAL(10, 2),
    "DTE"    DECIMAL(10, 2),
	"tipus"	INTEGER,
	"id_tipus"	UNIQUEIDENTIFIER,
	PRIMARY KEY("ID"),
	FOREIGN KEY("id_tipus") REFERENCES "Familia (id)"
);

CREATE TABLE "Carrito"(
    "ID" UNIQUEIDENTIFIER,
    "nom" varchar(10),
    PRIMARY KEY ("ID"),
);

CREATE TABLE "CarritoProd"(
    "ID"    UNIQUEIDENTIFIER,
    "ID_CARR" UNIQUEIDENTIFIER,
    "ID_PROD" UNIQUEIDENTIFIER,
    PRIMARY KEY ("ID"),
    FOREIGN KEY ("ID_CARR") REFERENCES "Carrito (ID)",
    FOREIGN KEY ("ID_PROD") REFERENCES "Producte (ID)"
);
