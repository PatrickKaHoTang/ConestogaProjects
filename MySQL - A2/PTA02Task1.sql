-- If MySQL is not started, run Services and run MySQL57 service

-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_my_guitar_shop.sql
-- mysql -u root -p < G:\mysql\PTA02Task1.sql > G:\mysql\PTA02Task1.out

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section 4';
SELECT '' AS 'Assignment 2: Task 1';

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;

SELECT '';
SELECT '' AS '*** Task 1, Q1. MGS Exercise 4-1 [5 points] ***';

SELECT category_name,
	   product_name,
       list_price
FROM categories
	JOIN products
	  ON categories.category_id = products.category_id
ORDER BY category_name, 
		 product_name ASC;

SELECT '';
SELECT '' AS '*** Task 1, Q2. MGS Exercise 4-2 [5 points] ***';

SELECT first_name, 
	   last_name, 
	   line1, 
	   city, 
	   state, 
	   zip_code
FROM customers
	JOIN addresses
	  ON customers.customer_id = addresses.customer_id
WHERE email_address LIKE 'allan.sherwood@yahoo.com';

SELECT '';
SELECT '' AS '*** Task 1, Q3. MGS Exercise 4-4 [5 points] ***';

SELECT last_name,
	   first_name,
	   order_date,
	   product_name,
	   item_price,
       discount_amount,
       quantity
FROM customers c
	JOIN orders o
	  ON c.customer_id = o.customer_id
	JOIN order_items oi
	  ON o.order_id = oi.order_id
	JOIN products p
	  ON oi.product_id = p.product_id
ORDER BY last_name,
		 order_date,
		 product_name;

SELECT '';
SELECT '' AS '*** Task 1, Q4. MGS Exercise 4-5 [5 points] ***';

SELECT DISTINCT p1.product_id,
				p1.product_name,
				p1.list_price
FROM products p1 
	JOIN products p2
WHERE p1.product_id <> p2.product_id AND
	  p1.list_price = p2.list_price;

SELECT '';
SELECT '' AS '*** Task 1, Q5. MGS Exercise 4-7 [5 points] ***';

SELECT 'SHIPPED' AS ship_status,
	   order_id,
	   order_date
FROM orders
	WHERE ship_date IS NOT NULL
UNION
SELECT 'NOT SHIPPED' AS ship_status,
	   order_id,
	   order_date
FROM orders
	WHERE ship_date IS NULL
ORDER BY order_date ASC;