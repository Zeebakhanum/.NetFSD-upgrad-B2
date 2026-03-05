USE SampleDb1;

CREATE TABLE archived_orders
(
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    shipped_date DATE,
    required_date DATE
);

SELECT * FROM orders;

ALTER TABLE orders
ADD shipped_date DATE,
    required_date DATE;

	SELECT * FROM orders;

	SELECT * FROM archived_orders;

	INSERT INTO archived_orders (order_id, customer_id, order_status, order_date, shipped_date, required_date)

SELECT order_id, customer_id, order_status, order_date, shipped_date, required_date
FROM orders
WHERE order_status = 3;

DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());


SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) = 
(
    SELECT COUNT(*)
    FROM orders o2
    WHERE o2.customer_id = orders.customer_id
    AND order_status = 1
);

SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders;
	
	SELECT 
order_id,
order_date,
required_date,
shipped_date,
CASE 
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS delivery_status
FROM orders;

SELECT 
    order_id,
    order_date,
    required_date,
    shipped_date,
    CASE 
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS delivery_status
FROM orders;