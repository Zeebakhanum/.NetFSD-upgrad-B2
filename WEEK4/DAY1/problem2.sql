use SampleDb1;


USE SampleDb1;


CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        -- Check if stock is sufficient
        IF EXISTS (
            SELECT 1
            FROM stocks s
            JOIN inserted i
            ON s.product_id = i.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR ('Insufficient stock available.',16,1)
            ROLLBACK TRANSACTION
            RETURN
        END

        -- Reduce stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT 'Error occurred while updating stock'
    END CATCH
END;

select * from order_items;

SELECT MAX(item_id) + 1 AS next_id
FROM order_items


SELECT order_id FROM orders;

SELECT product_id FROM products;

SELECT store_id FROM stores;

INSERT INTO order_items
(item_id, order_id, product_id, store_id, quantity, list_price, discount)
VALUES
(15, 101, 101, 1, 7, 400, 0.25);

SELECT order_id FROM orders WHERE order_id = 101;

SELECT product_id FROM products WHERE product_id = 101;

SELECT store_id FROM stores WHERE store_id = 1;

SELECT *
FROM stocks
WHERE product_id = 101
AND store_id = 1;

select * from stocks;