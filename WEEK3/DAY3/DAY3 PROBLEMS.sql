USE SampleDb1;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATETIME NOT NULL,
    order_status INT NOT NULL,
    
    CONSTRAINT FK_orders_customers
    FOREIGN KEY (customer_id)
    REFERENCES customers(customer_id)
);
 USE SampleDb1;

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
);


CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);


CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    brand_id INT NOT NULL,
    category_id INT NOT NULL,
    model_year INT NOT NULL,
    list_price DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_products_brands
    FOREIGN KEY (brand_id)
    REFERENCES brands(brand_id),

    CONSTRAINT FK_products_categories
    FOREIGN KEY (category_id)
    REFERENCES categories(category_id)
);

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



	INSERT INTO customers VALUES
(1, 'Ravi', 'Kumar', 'ravi@gmail.com'),
(2, 'Priya', 'Sharma', 'priya@gmail.com'),
(3, 'Amit', 'Verma', 'amit@gmail.com');



INSERT INTO orders VALUES
(101, 1, '2026-03-01', 1),
(102, 2, '2026-03-02', 4),
(103, 3, '2026-03-03', 2),
(104, 1, '2026-03-04', 4);



SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM 
    customers c, orders o
WHERE 
    c.customer_id = o.customer_id
    AND (o.order_status = 1 OR o.order_status = 4)
ORDER BY 
    o.order_date DESC;

	CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100) NOT NULL
);

CREATE TABLE order_items (
    item_id INT PRIMARY KEY,
    order_id INT NOT NULL,
    quantity INT NOT NULL,
    list_price DECIMAL(10,2) NOT NULL,
    discount DECIMAL(4,2) NOT NULL,

    CONSTRAINT FK_orderitems_orders
    FOREIGN KEY (order_id)
    REFERENCES orders(order_id)
);

INSERT INTO stores VALUES
(1, 'Bangalore Store'),
(2, 'Karwar Store'),
(3, 'Bhatkal Store');

INSERT INTO order_items VALUES
(1, 101, 2, 1000, 0.10),
(2, 101, 1, 500, 0.05),
(3, 103, 3, 1500, 0.20),
(4, 104, 5, 800, 0.15);


CREATE TABLE stocks (
    stock_id INT PRIMARY KEY,
    product_id INT NOT NULL,
    store_id INT NOT NULL,
    quantity INT NOT NULL,

    CONSTRAINT FK_stocks_products
    FOREIGN KEY (product_id)
    REFERENCES products(product_id),

    CONSTRAINT FK_stocks_stores
    FOREIGN KEY (store_id)
    REFERENCES stores(store_id)
);


INSERT INTO stocks (stock_id, product_id, store_id, quantity) VALUES
(1, 1, 1, 50),   -- Laptop in Bangalore
(2, 2, 1, 100),  -- Mobile in Bangalore
(3, 3, 1, 75),   -- Headphones in Bangalore
(4, 1, 2, 30),   -- Laptop in Hyderabad
(5, 4, 2, 60);   -- Keyboard in Hyderabad



USE SampleDb1;
INSERT INTO products VALUES
(101, 'Galaxy S23', 1, 1, 2024, 75000),
(102, 'iPhone 15', 2, 1, 2024, 90000),
(103, 'Bravia TV', 3, 3, 2023, 65000),
(104, 'Budget Phone', 1, 1, 2022, 15000),
(105, 'MacBook Air', 2, 2, 2024, 120000);

SELECT * FROM PRODUCTS;

SELECT * FROM STORES;

INSERT INTO stocks VALUES
(1, 101, 1, 50),
(2, 102, 1, 40),
(3, 103, 2, 30),
(4, 104, 3, 20),
(5, 105, 1, 60);

INSERT INTO stores VALUES
(1, 'Bangalore Store'),
(2, 'Karwar Store'),
(3, 'Bhatkal Store');

INSERT INTO orders VALUES
(201, 1, '2026-03-01', 4),
(202, 1, '2026-03-02', 1),
(203, 2, '2026-03-03', 4),
(204, 3, '2026-03-04', 4);

SELECT * FROM STORES;

SELECT *FROM ORDER_ITEMS;

SELECT * FROM PRODUCTS;



USE SampleDb1;

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'order_items';

	USE SampleDb1;

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES;


	USE SampleDb1;

SELECT * FROM ORDER_ITEMS;

ALTER TABLE order_items
ADD product_id INT,
    store_id INT;


	ALTER TABLE order_items
ADD CONSTRAINT FK_orderitems_products
FOREIGN KEY (product_id)
REFERENCES products(product_id);

ALTER TABLE order_items
ADD CONSTRAINT FK_orderitems_stores
FOREIGN KEY (store_id)
REFERENCES stores(store_id);

SELECT * FROM PRODUCTS;
SELECT * FROM STORES;
SELECT * FROM ORDERS;


SELECT * FROM ORDER_ITEMS;


USE SampleDb1;

INSERT INTO order_items
(item_id, order_id, quantity, list_price, discount, product_id, store_id)
VALUES
(9, 104, 5, 800, 0.15, 101, 1);

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'order_items';


INSERT INTO order_items
(item_id, order_id, quantity, list_price, discount, product_id, store_id)
VALUES
(10, 104, 3, 1200, 0.10, 102, 1);

INSERT INTO order_items
(item_id, order_id, quantity, list_price, discount, product_id, store_id)
VALUES
(11, 105, 2, 50000, 0.05, 103, 2);

INSERT INTO order_items
(item_id, order_id, quantity, list_price, discount, product_id, store_id)
VALUES
(12, 106, 1, 750, 0.00, 101, 2);

INSERT INTO order_items
(item_id, order_id, quantity, list_price, discount, product_id, store_id)
VALUES
(13, 107, 4, 1500, 0.20, 102, 1);

INSERT INTO order_items
(item_id, order_id, quantity, list_price, discount, product_id, store_id)
VALUES
(14, 108, 6, 900, 0.08, 103, 2);

SELECT 
    st.product_id,
    st.store_id,
    -- Get product name using subquery
    (SELECT product_name 
     FROM products p 
     WHERE p.product_id = st.product_id) AS product_name,
    -- Get store name using subquery
    (SELECT store_name 
     FROM stores s 
     WHERE s.store_id = st.store_id) AS store_name,
    -- Available stock directly
    st.quantity AS available_stock,
    -- Total quantity sold using subquery
    ISNULL((
        SELECT SUM(oi.quantity)
        FROM order_items oi
        WHERE oi.product_id = st.product_id
          AND oi.store_id = st.store_id
    ), 0) AS total_quantity_sold
FROM stocks st
ORDER BY 
    (SELECT product_name 
     FROM products p 
     WHERE p.product_id = st.product_id);