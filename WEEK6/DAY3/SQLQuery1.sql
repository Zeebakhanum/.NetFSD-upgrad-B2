USE ProductDB1;

CREATE TABLE Product1 (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

GO

CREATE PROCEDURE sp_InsertProduct1
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products VALUES (@ProductName, @Category, @Price);
END

GO

CREATE PROCEDURE sp_GetAllProduct1
AS
BEGIN
    SELECT * FROM Products;
END

GO

CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName=@ProductName, Category=@Category, Price=@Price
    WHERE ProductId=@ProductId;
END

GO

CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId=@ProductId;
END
