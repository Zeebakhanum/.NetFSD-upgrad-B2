USE ProductDb;

INSERT INTO brands VALUES
(1, 'Samsung'),
(2, 'Apple'),
(3, 'Sony');



INSERT INTO categories VALUES
(1, 'Mobile'),
(2, 'Laptop'),
(3, 'Television');


INSERT INTO products VALUES
(101, 'Galaxy S23', 1, 1, 2024, 75000),
(102, 'iPhone 15', 2, 1, 2024, 90000),
(103, 'Bravia TV', 3, 3, 2023, 65000),
(104, 'Budget Phone', 1, 1, 2022, 15000),
(105, 'MacBook Air', 2, 2, 2024, 120000);

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM 
    products p,
    brands b,
    categories c
WHERE 
    p.brand_id = b.brand_id
    AND p.category_id = c.category_id
    AND p.list_price > 500
ORDER BY 
    p.list_price ASC;