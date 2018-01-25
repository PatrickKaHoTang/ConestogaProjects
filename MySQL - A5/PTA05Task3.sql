-- To run your scripts:
-- cd C:\xampp\mysql\bin

-- cd "C:\Program Files (x86)\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < C:\Users\Patrick\Desktop\mysql\db_setup\create_my_guitar_shop.sql
-- mysql -u root -p < C:\Users\Patrick\Desktop\mysql\PTA05Task3.sql > C:\Users\Patrick\Desktop\mysql\PTA05Task3.out

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section #4';
SELECT '' AS 'Assignment #5: Task #3';

SELECT SYSDATE() AS 'Current System Date';

use my_guitar_shop;

SELECT '';
SELECT '' AS '*** Task 3, Q1. MGS Exercise 12-3 [5 points] ***';

CREATE VIEW PT_order_item_products AS
	 SELECT o.order_id, 
	        o.order_date, 
            o.tax_amount, 
            o.ship_date,
		    ot.item_price, 
            ot.discount_amount, 
            ot.item_price - ot.discount_amount AS final_price, 
            ot.quantity, 
            (ot.item_price - ot.discount_amount) * ot.quantity AS item_total,
            p.product_name
	   FROM orders o
		   JOIN order_items ot ON o.order_id = ot.order_id
		   JOIN products p ON p.product_id = ot.product_id;

SELECT '';
SELECT '' AS '*** Task 3, Q2. MGS Exercise 12-4 [2 points] ***';

SELECT order_id,
	   product_name,
       item_total
FROM PT_order_item_products
ORDER BY item_total DESC;

SELECT '';
SELECT '' AS '*** Task 3, Q3. MGS Exercise 12-5 [4 points] ***';

CREATE VIEW PT_product_summary AS
	SELECT product_name, 
           COUNT(product_name) AS order_count, 
           SUM(item_total) AS order_total
	FROM PT_order_item_products
	GROUP BY product_name;

SELECT '';
SELECT '' AS '*** Task 3, Q4. MGS Exercise 12-6 [2 points] ***';

SELECT product_name, 
	   order_total
FROM PT_product_summary
ORDER BY order_total DESC
LIMIT 5;