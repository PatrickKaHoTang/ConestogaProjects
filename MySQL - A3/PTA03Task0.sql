-- cd C:\xampp\mysql\bin
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\PTA03Task0.sql > G:\mysql\PTA03Task0.out

-- Important: You must run the create database SQL script to get consistent results
-- Show number of rows affected after every DML statement (i.e., SELECT ROW_COUNT();)

SELECT "" AS "Patrick Tang";
SELECT "" AS "PROG2220: Section 4";
SELECT "" AS "Assignment 3: Task 0";

SELECT SYSDATE() AS "Current System Date";

USE ap;

SELECT "";
SELECT "" AS "*** Task 0, Sample script to show rows affected ***";

INSERT INTO terms
    (terms_id, terms_description, terms_due_days)
VALUES
    (6, 'Net due 120 days', 120);

SELECT ROW_COUNT() AS "INSERT: rows affected";


UPDATE terms
SET terms_description = 'Net due 125 days',
    terms_due_days = 125
WHERE terms_id = 6;
 
SELECT ROW_COUNT() AS "UPDATE: rows affected";


DELETE FROM terms
WHERE terms_id = 6;

SELECT ROW_COUNT() AS "DELETE: rows affected";

