USE SampleDb1;

SELECT * FROM PRODUCTS;

SELECT * FROM CATEGORIES;

SELECT 
    CONCAT(p.product_name, ' (', p.model_year, ')') AS product_full_name,
    p.list_price,
    -- Calculate difference between product price and category average
    p.list_price - (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p2.category_id = p.category_id
    ) AS price_difference
FROM products p
WHERE p.list_price > (
    -- Nested query to get category average
    SELECT AVG(p2.list_price)
    FROM products p2
    WHERE p2.category_id = p.category_id
)
ORDER BY p.product_name;


