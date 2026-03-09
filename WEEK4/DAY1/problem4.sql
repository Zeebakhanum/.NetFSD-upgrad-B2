BEGIN TRY

    BEGIN TRANSACTION

    -- Temporary table to store revenue
    CREATE TABLE #RevenueTemp
    (
        store_id INT,
        order_id INT,
        revenue DECIMAL(12,2)
    )

    DECLARE @order_id INT
    DECLARE @store_id INT
    DECLARE @revenue DECIMAL(12,2)

    -- Cursor to fetch completed orders
    DECLARE order_cursor CURSOR FOR
    SELECT order_id
    FROM orders
    WHERE order_status = 4

    OPEN order_cursor

    FETCH NEXT FROM order_cursor INTO @order_id

    WHILE @@FETCH_STATUS = 0
    BEGIN

        -- Calculate revenue for each order
        SELECT 
            @store_id = store_id,
            @revenue = SUM(quantity * list_price * (1 - discount))
        FROM order_items
        WHERE order_id = @order_id
        GROUP BY store_id

        -- Insert into temp table
        INSERT INTO #RevenueTemp(store_id, order_id, revenue)
        VALUES (@store_id, @order_id, @revenue)

        FETCH NEXT FROM order_cursor INTO @order_id
    END

    CLOSE order_cursor
    DEALLOCATE order_cursor

    -- Display store-wise revenue summary
    SELECT 
        store_id,
        SUM(revenue) AS total_store_revenue
    FROM #RevenueTemp
    GROUP BY store_id

    COMMIT TRANSACTION

END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION
    PRINT 'Error occurred while calculating revenue'
END CATCH

SELECT order_id
FROM orders
WHERE order_status = 4


SELECT 
    store_id,
    SUM(revenue) AS total_store_revenue
FROM #RevenueTemp
GROUP BY store_id;