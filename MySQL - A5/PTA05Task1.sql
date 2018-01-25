-- To run your scripts:
-- cd C:\xampp\mysql\bin

-- cd "C:\Program Files (x86)\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < C:\Users\Patrick\Desktop\mysql\db_setup\create_my_guitar_shop.sql
-- mysql -u root -p < C:\Users\Patrick\Desktop\mysql\PTA05Task1.sql > C:\Users\Patrick\Desktop\mysql\PTA05Task1.out

SELECT '' AS 'Patrick Tang';
SELECT '' AS 'PROG2220: Section #4';
SELECT '' AS 'Assignment #5: Task #1';

SELECT SYSDATE() AS 'Current System Date';

use my_guitar_shop;

SELECT '';
SELECT '' AS '*** Task 1, Q1. MGS Exercise 8-1 [4 points] ***';

SELECT FORMAT(list_price, 2) AS price_format,
	   CAST(discount_percent AS SIGNED) AS discount_cast,
       ROUND(list_price * (discount_percent * 0.01), 2) AS discount_amount,
       DATE_FORMAT(date_added, '%m-%d') AS month_day_added
FROM products;

SELECT '';
SELECT '' AS '*** Task 1, Q2. MGS Exercise 9-2 [4 points] ***';

SELECT order_date,
	   DATE_FORMAT(order_date, '%Y') AS order_year,
       DATE_FORMAT(order_date, '%b-%d-%Y') AS order_date_formatted,
       DATE_FORMAT(order_date, '%h:%i:%s %p') AS order_time,
       DATE_FORMAT(order_date, '%m/%d/%y %H:%i') AS order_datetime
FROM orders;

SELECT '';
SELECT '' AS '*** Task 1, Q3. MGS Exercise 9-3 [5 points] ***';

SELECT card_number,
	   LENGTH(card_number) AS card_number_length,
       SUBSTRING(card_number, -4) last_four_digits,
	   LPAD(SUBSTRING(card_number, -4), 19, 'XXXX-') AS formatted_number
FROM orders;

SELECT '';
SELECT '' AS '*** Task 1, Q4. MGS Exercise 9-4 [5 points] ***';

SELECT order_id,
       order_date,
       DATE_ADD(order_date, INTERVAL 2 DAY) AS est_ship_date,
	   IFNULL(ship_date, 'Not Shipped'),
       DATEDIFF(ship_date, order_date) AS days_to_ship
FROM orders
WHERE order_date BETWEEN '2015-04-01' AND '2015-04-30';