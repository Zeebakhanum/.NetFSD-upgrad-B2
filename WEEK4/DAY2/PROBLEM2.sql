USE SampleDb1;


BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @order_id INT = 101;   -- Order to cancel

    -- Savepoint before restoring stock
    SAVE TRANSACTION RestoreStockPoint;

    --------------------------------------------------
    -- Restore Stock
    --------------------------------------------------
    UPDATE s
    SET s.quantity = s.quantity + oi.quantity
    FROM stocks s
    JOIN order_items oi
        ON s.product_id = oi.product_id
    WHERE oi.order_id = @order_id;

    --------------------------------------------------
    -- Update Order Status to Rejected (3)
    --------------------------------------------------
    UPDATE orders
    SET order_status = 3
    WHERE order_id = @order_id;

    --------------------------------------------------
    -- Commit Transaction
    --------------------------------------------------
    COMMIT TRANSACTION;

    PRINT 'Order cancelled successfully and stock restored';

END TRY

BEGIN CATCH

    PRINT 'Error occurred while cancelling order';

    -- Rollback to savepoint if stock restoration fails
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION RestoreStockPoint;
    END

    -- Rollback entire transaction
    ROLLBACK TRANSACTION;

    PRINT ERROR_MESSAGE();

END CATCH;

BEGIN TRANSACTION


SAVE TRANSACTION RestoreStockPoint

SELECT * FROM products;

SELECT * FROM stocks;

SELECT * FROM orders;

SELECT * 
FROM orders
WHERE order_id = 101;

SELECT *
FROM stocks
WHERE product_id IN (
    SELECT product_id 
    FROM order_items 
    WHERE order_id = 101
);

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @order_id INT = 101;

    SAVE TRANSACTION RestoreStockPoint;

    UPDATE s
    SET s.quantity = s.quantity + oi.quantity
    FROM stocks s
    JOIN order_items oi
    ON s.product_id = oi.product_id
    WHERE oi.order_id = @order_id;

    UPDATE orders
    SET order_status = 3
    WHERE order_id = @order_id;

    COMMIT TRANSACTION;

    PRINT 'Order Cancelled Successfully';

END TRY
BEGIN CATCH

    ROLLBACK TRANSACTION RestoreStockPoint;
    ROLLBACK TRANSACTION;

    PRINT 'Error Occurred';
END CATCH


SELECT order_id, order_status
FROM orders
WHERE order_id = 101;

SELECT *
FROM stocks
WHERE product_id IN (
    SELECT product_id 
    FROM order_items 
    WHERE order_id = 101
);