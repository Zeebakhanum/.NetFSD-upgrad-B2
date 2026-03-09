use SampleDb1;

CREATE TRIGGER trg_ValidateOrderStatus
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY

        -- Check if status is updated to 4 but shipped_date is NULL
        IF EXISTS (
            SELECT 1
            FROM inserted
            WHERE order_status = 4
            AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR ('Shipped date must be provided when order status is Completed.',16,1)
            ROLLBACK TRANSACTION
            RETURN
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT 'Error occurred while validating order status'
    END CATCH
END;


UPDATE orders
SET shipped_date = GETDATE(),
    order_status = 4
WHERE order_id = 101;

select * from orders;