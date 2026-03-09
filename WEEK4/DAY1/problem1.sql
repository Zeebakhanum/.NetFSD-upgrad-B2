USE SampleDb1;

USE SampleDb1;
GO

CREATE PROCEDURE sp_GetTotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_name,
        SUM(oi.quantity * oi.list_price) AS total_sales
    FROM stores s
    LEFT JOIN stocks st
        ON s.store_id = st.store_id
    LEFT JOIN order_items oi
        ON st.product_id = oi.product_id
    GROUP BY s.store_name
    ORDER BY s.store_name;
END;

EXEC sp_GetTotalSalesPerStore;

select * from orders;

CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        order_id,
        customer_id,
        order_status,
        order_date
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
    ORDER BY order_date;
END;

EXEC sp_GetOrdersByDateRange 
@StartDate='2016-01-01',
@EndDate='2016-12-31';


CREATE FUNCTION fn_CalculatePriceAfterDiscount
(
    @price DECIMAL(10,2),
    @discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @final_price DECIMAL(10,2)

    SET @final_price = @price - (@price * ISNULL(@discount,0) / 100)

    RETURN @final_price
END;

SELECT dbo.fn_CalculatePriceAfterDiscount(1000,10) AS FinalPrice;


CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS total_sold
    FROM products p
    JOIN order_items oi
        ON p.product_id = oi.product_id
    GROUP BY p.product_name
    ORDER BY total_sold DESC
);

SELECT * 
FROM dbo.fn_Top5SellingProducts();