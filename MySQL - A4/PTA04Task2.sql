-- To run your scripts:
-- cd C:\xampp\mysql\bin

-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\swexpert.sql
-- mysql -u root -p < G:\mysql\PTA04Task2.sql > G:\mysql\PTA04Task2.out

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section #4';
SELECT '' AS 'Assignment #4: Task #2';

SELECT SYSDATE() AS 'Current System Date';

use swexpert;

SELECT '';
SELECT '' AS '*** Task 2, Q1. SWE Exercise 1 [2 points] ***';

SELECT AVG(ROUND(score, 1)) AS 'Average Score'
  FROM evaluation
 WHERE evaluatee_id = 105;

SELECT '';
SELECT '' AS '*** Task 2, Q2. SWE Exercise 2 [2 points] ***';

SELECT COUNT(c.c_id) AS 'Number of Certified'
  FROM consultant c JOIN consultant_skill cs
 WHERE c.c_id = cs.c_id AND
	   cs.skill_id = '1';

SELECT '';
SELECT '' AS '*** Task 2, Q3. SWE Exercise 3 [4 points] ***';
            
SELECT c.c_first, c.c_last
  FROM consultant c
 WHERE c.c_id IN
    (SELECT DISTINCT pc.c_id
	   FROM project_consultant pc
	  WHERE pc.p_id IN
		(SELECT pc.p_id
		   FROM project_consultant pc
		  WHERE pc.c_id = 100));

SELECT '';
SELECT '' AS '*** Task 2, Q4. SWE Exercise 4 [5 points] ***';

SELECT p_id, project_name
  FROM project
 WHERE p_id IN
	(SELECT p_id
	   FROM evaluation)
UNION
SELECT p_id, project_name
  FROM project
 WHERE mgr_id IN
	(SELECT c_id
	   FROM consultant
	  WHERE LEFT(c_last, 1) = 'z');