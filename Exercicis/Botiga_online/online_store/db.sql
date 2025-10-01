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
	"tipus"	INTEGER,
	"id_tipus"	varchar(32),
	PRIMARY KEY("ID"),
	FOREIGN KEY("id_tipus") REFERENCES "Familia (id)"
);

CREATE TABLE "CarritoCompra"(
    "ID" UNIQUEIDENTIFIER,
    "nom" varchar(10),
    PRIMARY KEY ("ID"),
);

CREATE TABLE "CarritoProd"(
    "ID"    UNIQUEIDENTIFIER,
    "ID_CARR" varchar(32),
    "ID_PROD" varchar(32),
    PRIMARY KEY ("ID"),
    FOREIGN KEY ("ID_CARR") REFERENCES "CarritoCompra (ID)",
    FOREIGN KEY ("ID_PROD") REFERENCES "Producte (ID)"
);
