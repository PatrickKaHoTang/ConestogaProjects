-- cd C:\xampp\mysql\bin
-- mysql -u root -p < G:\mysql\db_setup\swexpert.sql
-- mysql -u root -p < G:\mysql\PTA03Task3.sql > G:\mysql\PTA03Task3.out

-- Important: You must run the create database SQL script to get consistent results
-- Show number of rows affected after every DML statement (i.e., SELECT ROW_COUNT();)

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section 4';
SELECT '' AS 'Assignment 3: Task 3';

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

SELECT '';
SELECT '' AS '*** Task 3, Q1. SWE Exercise 1 [2 points] ***';

INSERT INTO consultant
VALUES (106, 
		'Tang', 
		'Patrick', 
		'K', 
		'123 Fake Street', 
		'Fakesville', 
		'FK', 
		'A1B2C3', 
		'5195555555', 
		'fake123@fakemail.com');
        
SELECT ROW_COUNT() AS 'INSERT: rows affected';

SELECT '';
SELECT '' AS '*** Task 3, Q2. SWE Exercise 2 [2 points] ***';

INSERT INTO client
VALUES (17, 
		'City of Waterloo', 
		'Jaworsky', 
		'Dave', 
		'5198861550');
        
SELECT ROW_COUNT() AS 'INSERT: rows affected';

SELECT '';
SELECT '' AS '*** Task 3, Q3. SWE Exercise 3 [3 points] ***';

INSERT INTO project 
			(p_id, 
			project_name)
VALUES 		(88, 
			'ION Rapid Transit');

SELECT ROW_COUNT() AS 'INSERT: rows affected';

SELECT '';
SELECT '' AS '*** Task 3, Q4. SWE Exercise 4 [3 points] ***';

UPDATE project
SET parent_p_id = 88
WHERE parent_p_id IS NULL
  AND p_id != 88;
  
SELECT ROW_COUNT() AS 'UPDATE: rows affected';