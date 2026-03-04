USE InventoryDb;


CREATE TABLE order_items (
    item_id INT PRIMARY KEY,
    product_id INT NOT NULL,
    store_id INT NOT NULL,
    quantity INT NOT NULL,

    CONSTRAINT FK_orderitems_products
    FOREIGN KEY (product_id)
    REFERENCES products(product_id),

    CONSTRAINT FK_orderitems_stores
    FOREIGN KEY (store_id)
    REFERENCES stores(store_id)
);