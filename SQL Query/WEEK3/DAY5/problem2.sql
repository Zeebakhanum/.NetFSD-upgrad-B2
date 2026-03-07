use SampleDb1;

CREATE VIEW vw_ProductDetails
AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

select * from vw_ProductDetails;

select * from orders;

CREATE VIEW vw_OrderSummary
AS
SELECT
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
o.order_date,
o.order_status,
o.shipped_date,
o.required_date
FROM orders o
JOIN customers c
ON o.customer_id = c.customer_id;

select * from vw_OrderSummary;

