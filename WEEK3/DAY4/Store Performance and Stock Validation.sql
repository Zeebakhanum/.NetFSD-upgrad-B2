USE SampleDb1;

SELECT * FROM stores;

SELECT * FROM products;

SELECT * FROM order_items;

SELECT * FROM stocks;

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM(oi.quantity * (oi.list_price - oi.discount)) AS total_revenue
FROM order_items oi
JOIN stores s ON oi.store_id = s.store_id
JOIN products p ON oi.product_id = p.product_id
JOIN stocks st ON st.store_id = s.store_id AND st.product_id = p.product_id
WHERE st.quantity = 0
GROUP BY s.store_name, p.product_name
ORDER BY s.store_name, p.product_name;

UPDATE stocks
SET quantity = 0
WHERE quantity < 1;