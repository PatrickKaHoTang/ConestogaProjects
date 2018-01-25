-- If MySQL is not started, run Services and run MySQL57 service

-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\PTA01Task1.sql > G:\mysql\PTA01Task1.out

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section #4';
SELECT '' AS 'Assignment #1: Task #1';

SELECT SYSDATE() AS 'Current System Date';

USE ap;

SELECT '';
SELECT '' AS '*** Task 1, Q1. Textbook Exercise 3-06 (page 111) [2 points] ***';

SELECT vendor_name, vendor_contact_last_name, vendor_contact_first_name
FROM vendors
ORDER BY vendor_contact_last_name ASC, vendor_contact_first_name ASC
LIMIT 10;

SELECT '';
SELECT '' AS '*** Task 1, Q2. Textbook Exercise 3-07 (page 111) [1 point] ***';

SELECT CONCAT(vendor_contact_last_name, ', ', vendor_contact_first_name) AS full_name
FROM vendors
WHERE vendor_contact_last_name < 'D' OR vendor_contact_last_name LIKE 'E%'
ORDER BY full_name ASC;

SELECT '';
SELECT '' AS '*** Task 1, Q3. Textbook Exercise 3-08 (page 111) [1 point] ***';

SELECT invoice_due_date AS 'Due Date',
	   invoice_total AS 'Invoice Total',
	   invoice_total * 0.1 AS '10%',
       invoice_total * 1.1 AS 'Plus 10%'
FROM invoices
WHERE invoice_total >= 500 AND invoice_total <= 1000
ORDER BY invoice_due_date DESC;

SELECT '';
SELECT '' AS '*** Task 1, Q4. Textbook Exercise 3-09 (page 111) [2 point] ***';

SELECT invoice_number, 
	   invoice_total, 
	   payment_total + credit_total AS payment_credit_total, 
	   invoice_total - payment_total - credit_total AS balance_due
FROM invoices
WHERE invoice_number - payment_total - credit_total > 50
ORDER BY balance_due DESC
LIMIT 5;

SELECT '';
SELECT '' AS '*** Task 1, Q5. Textbook Exercise 3-10 (page 112) [2 point] ***';

SELECT invoice_number,
	   invoice_date,
       invoice_total - payment_total - credit_total AS balance_due,
       payment_date
FROM invoices
WHERE payment_date IS NULL;

SELECT '';
SELECT '' AS '*** Task 1, Q6. Textbook Exercise 3-11 (page 112) [1 point] ***';

SELECT CURRENT_DATE,
	DATE_FORMAT(CURRENT_DATE, '%m-%d-%Y') AS 'current_date';

SELECT '';
SELECT '' AS '*** Task 1, Q7. Textbook Exercise 3-12 (page 112) [1 point] ***';

SELECT 50000 AS starting_principal,
       50000 * 0.065 AS interest,
       50000 + (50000 * 0.065) AS principal_plus_interest;