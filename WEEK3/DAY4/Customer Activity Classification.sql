USE SampleDb1;

SELECT * FROM CUSTOMERS;

SELECT * FROM ORDERS;

SELECT TOP 5 * FROM ORDERS;

SELECT * FROM ORDER_ITEMS;

SELECT 
    c.first_name + ' ' + c.last_name AS full_name,
    ISNULL((
        SELECT SUM(oi.quantity * (oi.list_price - oi.discount))
        FROM orders o
        JOIN order_items oi ON o.order_id = oi.order_id
        WHERE o.customer_id = c.customer_id
    ), 0) AS total_order_value,
    CASE 
        WHEN ISNULL((
            SELECT SUM(oi.quantity * (oi.list_price - oi.discount))
            FROM orders o
            JOIN order_items oi ON o.order_id = oi.order_id
            WHERE o.customer_id = c.customer_id
        ), 0) > 10000 THEN 'Premium'
        WHEN ISNULL((
            SELECT SUM(oi.quantity * (oi.list_price - oi.discount))
            FROM orders o
            JOIN order_items oi ON o.order_id = oi.order_id
            WHERE o.customer_id = c.customer_id
        ), 0) BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS customer_type
FROM customers c
ORDER BY full_name;

SELECT * FROM customers;


SELECT * FROM categories;

SELECT * FROM products;