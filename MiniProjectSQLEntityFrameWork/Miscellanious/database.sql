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
INSERT INTO "public"."kha_project" ("project_name") VALUES ('C#');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('JAVASCRIPTS');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('FRONTEND');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('BACKENDS');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('HTML');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('CSS');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('SQL');
INSERT INTO "public"."kha_project" ("project_name") VALUES ('POSTGRES');
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 8);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (2, 6, 6);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (6, 7, 6);
INSERT INTO "public"."kha_project_person" ("project_id", "person_id", "hours") VALUES (1, 3, 8);
INSERT INTO "public"."kha_person" ("person_name") VALUES ('OAISHI');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('HASAN');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('KRILLE');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('TOMAS');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('DANIAL');
INSERT INTO "public"."kha_person" ("person_name") VALUES ('RUHUL');
ALTER TABLE "public"."kha_project" ENABLE TRIGGER ALL;
ALTER TABLE "public"."kha_project_person" ENABLE TRIGGER ALL;
ALTER TABLE "public"."kha_person" ENABLE TRIGGER ALL;
ALTER TABLE "public"."kha_project_person" ADD CONSTRAINT "FK_kha_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."kha_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."kha_project_person" ADD CONSTRAINT "FK_kha_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."kha_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
