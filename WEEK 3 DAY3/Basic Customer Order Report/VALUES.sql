USE SampleDb;

INSERT INTO customers VALUES
(1, 'Ravi', 'Kumar', 'ravi@gmail.com'),
(2, 'Priya', 'Sharma', 'priya@gmail.com'),
(3, 'Amit', 'Verma', 'amit@gmail.com');

USE SampleDb;

INSERT INTO orders VALUES
(101, 1, '2026-03-01', 1),
(102, 2, '2026-03-02', 4),
(103, 3, '2026-03-03', 2),
(104, 1, '2026-03-04', 4);

USE SampleDb;

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