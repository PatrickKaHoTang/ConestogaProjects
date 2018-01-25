-- To run your scripts:
-- cd C:\xampp\mysql\bin

-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\swexpert.sql
-- mysql -u root -p < G:\mysql\PTA03Task3.sql > G:\mysql\PTA03Task3.out
-- mysql -u root -p --force < G:\mysql\PTA04Task3.sql 1> G:\mysql\PTA04Task3.out 2> G:\mysql\PTA04Task3.err

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section #4';
SELECT '' AS 'Assignment #4: Task #3';

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

SELECT '';
SELECT '' AS '*** Task 3, Q1. SWE Exercise 4 [1 point] ***';

ALTER TABLE project_consultant
        ADD total_days    INT         DEFAULT          0;

UPDATE project_consultant
   SET total_days = DATEDIFF(roll_off_date, roll_on_date);

SELECT ROW_COUNT() AS 'UPDATE: rows affected';

SELECT *
  FROM project_consultant;
  
ALTER TABLE project_consultant
DROP COLUMN total_days;

SELECT '';
SELECT '' AS '*** Task 3, Q2. SWE Exercise 2 [4 points] ***';

DROP TABLE IF EXISTS evaluation_audit;

CREATE TABLE evaluation_audit
(
	audit_id        INT         PRIMARY KEY      AUTO_INCREMENT,
    audit_e_id      INT         NOT NULL,
    audit_score     INT         NULL,
    audit_user      VARCHAR(20)
);

INSERT INTO evaluation_audit
	        (audit_e_id, audit_score)
     VALUES (100, 90);

SELECT ROW_COUNT() as 'INSERT: rows affected';

SELECT *
  FROM evaluation_audit;

SELECT '';
SELECT '' AS '*** Task 3, Q3. SWE Exercise 3 [5 points] ***';

ALTER TABLE evaluation_audit
	 MODIFY audit_user VARCHAR(20) NOT NULL;

ALTER TABLE evaluation_audit
        ADD audit_date DATETIME;
  
INSERT INTO evaluation_audit
		    (audit_e_id, audit_score, audit_user, audit_date)
	 VALUES (100, 95, USER(), SYSDATE());
     
SELECT ROW_COUNT() AS 'INSERT: rows affected';
     
SELECT *
  FROM evaluation_audit;
  
INSERT INTO evaluation_audit
		    (audit_e_id, audit_score)
	 VALUES (100, 99);
  
SELECT ROW_COUNT() AS 'INSERT: rows affected (negative test: check err file)';

SELECT '';
SELECT '' AS '*** Task 3, Q4. SWE Exercise 4 [1 point] ***';

INSERT INTO project_skill 
		    (skill_id)
     VALUES (NULL);

SELECT ROW_COUNT() AS 'INSERT: rows affected (negative test: check err file)';

SELECT '';
SELECT '' AS '*** Task 3, Q5. SWE Exercise 5 [2 points] ***';

DELETE FROM consultant
WHERE c_id = 100;

SELECT ROW_COUNT() AS 'DELETE: rows affected (negative test: check err file)';