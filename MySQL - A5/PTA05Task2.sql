-- To run your scripts:
-- cd C:\xampp\mysql\bin

-- cd "C:\Program Files (x86)\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < C:\Users\Patrick\Desktop\mysql\db_setup\swexpert.sql
-- mysql -u root -p < C:\Users\Patrick\Desktop\mysql\PTA05Task2.sql > C:\Users\Patrick\Desktop\mysql\PTA05Task2.out

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section #4';
SELECT '' AS 'Assignment #5: Task #2';

SELECT SYSDATE() AS 'Current System Date';

use swexpert;

SELECT '';
SELECT '' AS '*** Task 2, Q1. SWE Exercise 1 [4 points] ***';

SELECT ROUND(AVG(e.score), 2) AS average
FROM evaluation e INNER JOIN consultant c
WHERE CONCAT_WS(' ', c.c_first, c.c_last) = 'Janet Park';

SELECT '';
SELECT '' AS '*** Task 2, Q2. SWE Exercise 2 [4 points] ***';

SELECT p_id,
	   LPAD(c_id, 7, ' ') AS c_id,
       LPAD(TRUNCATE(DATEDIFF(roll_off_date, roll_on_date) / 30.4, 0), 10, ' ') AS months
FROM project_consultant;

SELECT '';
SELECT '' AS '*** Task 2, Q3. SWE Exercise 3 [5 points] ***';

SELECT LPAD(c.c_id, 4, ' ') AS c_id,
       RPAD(CONCAT(c.c_last, ', ', c.c_first), 20, ' ') AS consultant_full_name,
       LPAD(skill_id, 8, ' ') AS skill_id,
       RPAD(CASE cs.certification
				WHEN 'Y' THEN 'Certified'
				WHEN 'N' THEN 'Not Certified'
				ELSE 'Unknown'
			END CASE, 13, ' ') AS certification
FROM consultant c
	 INNER JOIN consultant_skill cs ON c.c_id = cs.c_id;