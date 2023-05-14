CREATE TABLE "Vozilo" (
    "id_vozila" SERIAL NOT NULL,
    "model_vozila" int   NOT NULL,
    "broj_sasije" varchar(20)   NOT NULL,
    "registracijska_oznaka" varchar(20)   NOT NULL,
    "godina_proizvodnje" int   NOT NULL,
    "vrsta_vozila" int   NOT NULL,
    "id_lokacije" int   NOT NULL,
    "gorivo" varchar(20)   NOT NULL,
    "kategorija" varchar(5)   NOT NULL,
    CONSTRAINT "pk_Vozilo" PRIMARY KEY (
        "id_vozila"
     )
);

CREATE TABLE "Vrsta_vozila" (
    "vrsta_id" SERIAL  NOT NULL,
    "naziv" varchar(30)   NOT NULL,
    CONSTRAINT "pk_Vrsta_vozila" PRIMARY KEY (
        "vrsta_id"
     )
);

CREATE TABLE "Marka" (
    "id" SERIAL  NOT NULL,
    "naziv" varchar(30)   NOT NULL,
    CONSTRAINT "pk_Marka" PRIMARY KEY (
        "id"
     )
);

CREATE TABLE "Model_vozila" (
    "id" SERIAL NOT NULL,
    "naziv" varchar(30)   NOT NULL,
    "id_marke" int   NOT NULL,
    CONSTRAINT "pk_Model_vozila" PRIMARY KEY (
        "id"
     )
);

CREATE TABLE "lokacija_vozila" (
    "id" SERIAL  NOT NULL,
    "naziv_lokacije" varchar(30)   NOT NULL,
    CONSTRAINT "pk_lokacija_vozila" PRIMARY KEY (
        "id"
     )
);

CREATE TABLE "Uposlenik" (
    "id_uposlenik" SERIAL   NOT NULL,
    "ime" varchar(30)   NOT NULL,
    "prezime" varchar(30)   NOT NULL,
    "pozicija_id" int   NOT NULL,
    "adresa" varchar(30)   NOT NULL,
    "broj_mobitela" varchar(30)   NOT NULL,
    "jmbg" varchar(15)   NOT NULL,
    "email" varchar(30)   NOT NULL,
    "datum_rodjenja" date   NOT NULL,
    CONSTRAINT "pk_Uposlenik" PRIMARY KEY (
        "id_uposlenik"
     )
);

CREATE TABLE "Pozicija" (
    "pozicija_id" SERIAL   NOT NULL,
    "naziv" varchar(30)   NOT NULL,
    CONSTRAINT "pk_Pozicija" PRIMARY KEY (
        "pozicija_id"
     )
);

CREATE TABLE "Kategorija" (
    "id_kategorije" SERIAL   NOT NULL,
    "naziv_kategorije" varchar(30)   NOT NULL,
    "opis_kategorije" varchar(40)   NOT NULL,
    CONSTRAINT "pk_Kategorija" PRIMARY KEY (
        "id_kategorije"
     )
);

CREATE TABLE "Uposlenik_kategorija" (
    "id" SERIAL   NOT NULL,
    "id_uposlenik" int   NOT NULL,
    "id_kategorije" int   NOT NULL,
    CONSTRAINT "pk_Uposlenik_kategorija" PRIMARY KEY (
        "id"
     )
);

CREATE TABLE "Dodjela_vozila" (
    "id" SERIAL   NOT NULL,
    "id_uposlenika" int   NOT NULL,
    "id_vozila" int   NOT NULL,
    "dodjeljeno" date   NOT NULL,
    "vratiti_do" date   NOT NULL,
    "dodatak" varchar(50)   NOT NULL,
    CONSTRAINT "pk_Dodjela_vozila" PRIMARY KEY (
        "id"
     )
);

ALTER TABLE "Vozilo" ADD CONSTRAINT "fk_Vozilo_model_vozila" FOREIGN KEY("model_vozila")
REFERENCES "Model_vozila" ("id");

ALTER TABLE "Vozilo" ADD CONSTRAINT "fk_Vozilo_vrsta_vozila" FOREIGN KEY("vrsta_vozila")
REFERENCES "Vrsta_vozila" ("vrsta_id");

ALTER TABLE "Vozilo" ADD CONSTRAINT "fk_Vozilo_id_lokacije" FOREIGN KEY("id_lokacije")
REFERENCES "lokacija_vozila" ("id");

ALTER TABLE "Model_vozila" ADD CONSTRAINT "fk_Model_vozila_id_marke" FOREIGN KEY("id_marke")
REFERENCES "Marka" ("id");

ALTER TABLE "Uposlenik" ADD CONSTRAINT "fk_Uposlenik_pozicija_id" FOREIGN KEY("pozicija_id")
REFERENCES "Pozicija" ("pozicija_id");

ALTER TABLE "Uposlenik_kategorija" ADD CONSTRAINT "fk_Uposlenik_kategorija_id_uposlenik" FOREIGN KEY("id_uposlenik")
REFERENCES "Uposlenik" ("id_uposlenik");

ALTER TABLE "Uposlenik_kategorija" ADD CONSTRAINT "fk_Uposlenik_kategorija_id_kategorije" FOREIGN KEY("id_kategorije")
REFERENCES "Kategorija" ("id_kategorije");

ALTER TABLE "Dodjela_vozila" ADD CONSTRAINT "fk_Dodjela_vozila_id_uposlenika" FOREIGN KEY("id_uposlenika")
REFERENCES "Uposlenik" ("id_uposlenik");

ALTER TABLE "Dodjela_vozila" ADD CONSTRAINT "fk_Dodjela_vozila_id_vozila" FOREIGN KEY("id_vozila")
REFERENCES "Vozilo" ("id_vozila");