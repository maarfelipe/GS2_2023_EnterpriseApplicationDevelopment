DROP TABLE IF EXISTS public."Consultas" CASCADE;
DROP INDEX IF EXISTS public."IX_Consultas_id_consultorio" CASCADE;
DROP INDEX IF EXISTS public."IX_Consultas_id_medico" CASCADE;
DROP INDEX IF EXISTS public."IX_Consultas_id_usuario" CASCADE;

DROP TABLE IF EXISTS public."Medicos" CASCADE;
DROP TABLE IF EXISTS public."MedicosConsultorios" CASCADE;
DROP INDEX IF EXISTS public."IX_MedicosConsultorios_id_consultorio" CASCADE;

DROP TABLE IF EXISTS public."Imagens" CASCADE;
DROP INDEX IF EXISTS public."IX_Imagens_id_usuario" CASCADE;

DROP TABLE IF EXISTS public."Enderecos" CASCADE;
DROP INDEX IF EXISTS public."IX_Enderecos_id_consultorio" CASCADE;

DROP TABLE IF EXISTS public."Consultorios" CASCADE;

DROP TABLE IF EXISTS public."Usuarios" CASCADE;

DROP TABLE IF EXISTS public."__EFMigrationsHistory" CASCADE;
