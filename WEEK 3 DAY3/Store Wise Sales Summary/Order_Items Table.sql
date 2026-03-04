USE SalesDb;

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