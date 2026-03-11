CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if stock is sufficient
    IF EXISTS (
        SELECT 1
        FROM stocks s
        JOIN inserted i 
        ON s.product_id = i.product_id
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR('Stock not sufficient for one or more products',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i
    ON s.product_id = i.product_id;
END



BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @order_id INT;

    -- Insert into Orders table
    INSERT INTO orders (customer_id, order_date, order_status)
    VALUES (1, GETDATE(), 1);

    -- Get generated order id
    SET @order_id = SCOPE_IDENTITY();

    -- Insert order items
    INSERT INTO order_items (order_id, product_id, quantity, list_price)
    VALUES 
    (@order_id, 1, 2, 500),
    (@order_id, 2, 1, 800);

    -- Commit if everything is successful
    COMMIT TRANSACTION;

    PRINT 'Order placed successfully';

END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION;

    PRINT 'Order failed due to insufficient stock or error';
END CATCH




SELECT * FROM orders;

SELECT * FROM order_items;