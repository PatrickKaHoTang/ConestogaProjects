-- To run your scripts:
-- cd C:\xampp\mysql\bin

-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_my_guitar_shop.sql
-- mysql -u root -p < G:\mysql\PTA04Task1.sql > G:\mysql\PTA04Task1.out

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section #4';
SELECT '' AS 'Assignment #4: Task #1';

SELECT SYSDATE() AS 'Current System Date';

use my_guitar_shop;

SELECT '';
SELECT '' AS '*** Task 1, Q1. MGS Exercise 6-1 [3 points] ***';

SELECT COUNT(order_id) AS 'order_count',
	   SUM(tax_amount) AS 'tax_total'
FROM orders;

SELECT '';
SELECT '' AS '*** Task 1, Q2. MGS Exercise 6-2 [4 points] ***';

SELECT c.category_name, 
	   COUNT(p.product_id) AS 'product_count', 
	   MAX(p.list_price) AS 'most_expensive_product'
FROM categories c, products p
WHERE c.category_id = p.category_id
GROUP BY c.category_name
ORDER BY MAX(p.product_id);

SELECT '';
SELECT '' AS '*** Task 1, Q3. MGS Exercise 6-6 [3 points] ***';

SELECT p.product_name, 
	   SUM((oi.item_price - oi.discount_amount) * oi.quantity) AS product_total
FROM products p JOIN order_items oi ON p.product_id = oi.product_id
GROUP BY p.product_name WITH ROLLUP;

SELECT '';
SELECT '' AS '*** Task 1, Q4. MGS Exercise 7-3 [3 points] ***';

SELECT category_name
FROM categories c
WHERE NOT EXISTS
	(SELECT *
	   FROM products p
	  WHERE p.category_id = c.category_id);