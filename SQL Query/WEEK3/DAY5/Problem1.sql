USE SampleDb1;

SELECT * FROM categories;

SELECT * FROM customers;

SELECT * FROM products;

SELECT * FROM stores;

SELECT * FROM brands;

SELECT 
p.product_name,
b.brand_name,
c.category_name
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;

ALTER TABLE customers
ADD city VARCHAR(50);



UPDATE customers
SET city = 'Delhi'
WHERE customer_id = 1;

UPDATE customers
SET city = 'Banglore'
WHERE customer_id = 2;

UPDATE customers
SET city = 'Mumbai'
WHERE customer_id = 3;

SELECT *
FROM customers
WHERE city = 'Delhi';