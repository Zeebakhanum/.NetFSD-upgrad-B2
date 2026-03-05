USE InventoryDb;

INSERT INTO products (product_id, product_name) VALUES
(1, 'Laptop'),
(2, 'Mobile'),
(3, 'Headphones'),
(4, 'Keyboard');

INSERT INTO stores (store_id, store_name) VALUES
(1, 'Bangalore Store'),
(2, 'Hyderabad Store');

INSERT INTO stocks (stock_id, product_id, store_id, quantity) VALUES
(1, 1, 1, 50),   -- Laptop in Bangalore
(2, 2, 1, 100),  -- Mobile in Bangalore
(3, 3, 1, 75),   -- Headphones in Bangalore
(4, 1, 2, 30),   -- Laptop in Hyderabad
(5, 4, 2, 60);   -- Keyboard in Hyderabad

INSERT INTO order_items (item_id, product_id, store_id, quantity) VALUES
(1, 1, 1, 5),   -- 5 Laptops sold in Bangalore
(2, 1, 1, 3),   -- 3 more Laptops sold in Bangalore
(3, 2, 1, 10),  -- 10 Mobiles sold in Bangalore
(4, 1, 2, 2);   -- 2 Laptops sold in Hyderabad

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock_quantity,
    COALESCE(SUM(oi.quantity), 0) AS total_quantity_sold
FROM stocks st
LEFT JOIN products p 
    ON st.product_id = p.product_id
LEFT JOIN stores s 
    ON st.store_id = s.store_id
LEFT JOIN order_items oi 
    ON st.product_id = oi.product_id 
    AND st.store_id = oi.store_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY 
    p.product_name;