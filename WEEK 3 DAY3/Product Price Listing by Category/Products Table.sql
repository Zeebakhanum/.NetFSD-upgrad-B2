USE ProductDb;

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