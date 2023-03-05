ALTER TABLE "public"."kha_project_person" DROP CONSTRAINT "FK_kha_project_person_project_id";
ALTER TABLE "public"."kha_project_person" DROP CONSTRAINT "FK_kha_person_project_person_id";
DROP TABLE IF EXISTS "public"."kha_project";
DROP TABLE IF EXISTS "public"."kha_project_person";
DROP TABLE IF EXISTS "public"."kha_person";
CREATE TABLE "public"."kha_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "kha_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."kha_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "kha_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."kha_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "kha_person_pkey" PRIMARY KEY ("id")
);
TRUNCATE TABLE "public"."kha_project";
TRUNCATE TABLE "public"."kha_project_person";
TRUNCATE TABLE "public"."kha_person";
ALTER TABLE "public"."kha_project" DISABLE TRIGGER ALL;
ALTER TABLE "public"."kha_project_person" DISABLE TRIGGER ALL;
ALTER TABLE "public"."kha_person" DISABLE TRIGGER ALL;
INSERT INTO "public"."kha_project" ("project_name") VALUES ('CSS');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('JAVASCRIPTS');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('FRONTEND');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('BACKEND');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('HTML 5');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('C#');
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (2, 4, 1);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (1, 2, 5);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (6, 2, 6);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (1, 2, 0);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (1, 2, 0);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (2, 3, 5);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (1, 3, 6);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (1, 5, 7);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (3, 3, 8);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (7, 10, 6);
INSERT INTO "public"."kha_person" ("person_name") VALUES ('SHOBUZ HASAN');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('RUHUL AMIN');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('MUSFIQURE RAHMAN HILALY');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('SADIA RASHID');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('MK');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('NURUZ ZAMAN');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('SHAWON HASAN');
ALTER TABLE "public"."kha_project" ENABLE TRIGGER ALL;
ALTER TABLE "public"."kha_project_person" ENABLE TRIGGER ALL;
ALTER TABLE "public"."kha_person" ENABLE TRIGGER ALL;
ALTER TABLE "public"."kha_project_person" ADD CONSTRAINT "FK_kha_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."kha_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."kha_project_person" ADD CONSTRAINT "FK_kha_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."kha_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;

