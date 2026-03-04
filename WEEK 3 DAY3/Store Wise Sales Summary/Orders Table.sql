USE SalesDb;

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    store_id INT NOT NULL,
    order_date DATETIME NOT NULL,
    order_status INT NOT NULL,

    CONSTRAINT FK_orders_stores
    FOREIGN KEY (store_id)
    REFERENCES stores(store_id)
);