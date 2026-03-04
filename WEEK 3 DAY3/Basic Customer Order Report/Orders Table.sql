USE SampleDb

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATETIME NOT NULL,
    order_status INT NOT NULL,
    
    CONSTRAINT FK_orders_customers
    FOREIGN KEY (customer_id)
    REFERENCES customers(customer_id)
);