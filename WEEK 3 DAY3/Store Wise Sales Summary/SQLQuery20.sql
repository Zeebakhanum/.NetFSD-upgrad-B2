USE SalesDb;

INSERT INTO stores VALUES
(1, 'Bangalore Store'),
(2, 'Karwar Store'),
(3, 'Bhatkal Store');

USE SalesDb;

INSERT INTO orders VALUES
(101, 1, '2026-03-01', 4),
(102, 1, '2026-03-02', 1),
(103, 2, '2026-03-03', 4),
(104, 3, '2026-03-04', 4);

INSERT INTO order_items VALUES
(1, 101, 2, 1000, 0.10),
(2, 101, 1, 500, 0.05),
(3, 103, 3, 1500, 0.20),
(4, 104, 5, 800, 0.15);


SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM 
    stores s,
    orders o,
    order_items oi
WHERE 
    s.store_id = o.store_id
    AND o.order_id = oi.order_id
    AND o.order_status = 4
GROUP BY 
    s.store_name
ORDER BY 
    total_sales DESC;