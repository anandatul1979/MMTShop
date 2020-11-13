Use MMTShop
Go
IF (Not EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Categories'))
Begin
	CREATE TABLE Categories
	(
		CategoryId INT NOT NULL CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED,
		CategoryName VARCHAR(255) NOT NULL,
		CategoryProductsFeatured BIT NOT NULL
			CONSTRAINT DF_Categories_CategoryProductsFeatured DEFAULT (0)
	)
	
CREATE UNIQUE NONCLUSTERED INDEX UIDX_Categories_CategoryName ON Categories (CategoryName)
End
Go
IF (Not EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Products'))
Begin
	CREATE TABLE Products
	(
		ProductId INT NOT NULL IDENTITY (1,1) 
			CONSTRAINT PK_Products PRIMARY KEY CLUSTERED,
		CategoryId INT NOT NULL
			CONSTRAINT FK_Products_Categories_CategoryId FOREIGN KEY REFERENCES Categories (CategoryId),
		ProductName VARCHAR(255) NOT NULL,
		ProductPrice DECIMAL(17,2) NOT NULL
			CONSTRAINT DF_Products_ProductPrice DEFAULT (99999999999.99),
		ProductDescription VARCHAR(MAX) NOT NULL,
		ProductFeatured BIT NOT NULL
			CONSTRAINT DF_Products_ProductFeatured DEFAULT (0),
		ProductSku AS CAST(CategoryId AS VARCHAR(10)) + RIGHT('0000'+CAST(ProductId AS VARCHAR(4)),4)
	)

	CREATE NONCLUSTERED INDEX IDX_Products_CategoryId ON Products (CategoryId)
End
Go
IF not EXISTS(SELECT 1 FROM dbo.Categories WITH(NOLOCK) WHERE CategoryName = 'Home')
BEGIN
	INSERT Categories (CategoryId, CategoryName, CategoryProductsFeatured)
	VALUES	(1, 'Home', 1)
End
IF not EXISTS(SELECT 1 FROM dbo.Categories WITH(NOLOCK) WHERE CategoryName = 'Garden')
BEGIN
	INSERT Categories (CategoryId, CategoryName, CategoryProductsFeatured)
	VALUES	(2, 'Garden', 1)
End
IF not EXISTS(SELECT 1 FROM dbo.Categories WITH(NOLOCK) WHERE CategoryName = 'Electronics')
BEGIN
	INSERT Categories (CategoryId, CategoryName, CategoryProductsFeatured)
	VALUES	(3, 'Electronics', 1)
End
IF not EXISTS(SELECT 1 FROM dbo.Categories WITH(NOLOCK) WHERE CategoryName = 'Fitness')
BEGIN
	INSERT Categories (CategoryId, CategoryName, CategoryProductsFeatured)
	VALUES	(4, 'Fitness', 0)
End
IF not EXISTS(SELECT 1 FROM dbo.Categories WITH(NOLOCK) WHERE CategoryName = 'Toys')
BEGIN
	INSERT Categories (CategoryId, CategoryName, CategoryProductsFeatured)
	VALUES	(5, 'Toys', 0)
End
Go

IF Not EXISTS(SELECT 1 FROM dbo.Products WITH(NOLOCK) WHERE ProductName = 'P0001')
BEGIN
	INSERT Products (CategoryId, ProductName, ProductDescription, ProductPrice, ProductFeatured)
	VALUES (1, 'P0001', 'Home 0001', 15.10, 1)
End
Go
IF Not EXISTS(SELECT 1 FROM dbo.Products WITH(NOLOCK) WHERE ProductName = 'P0002')
BEGIN
	INSERT Products (CategoryId, ProductName, ProductDescription, ProductPrice, ProductFeatured)
	VALUES (2, 'P0002', 'Garden 0002', 18.20, 1)
End
Go
IF Not EXISTS(SELECT 1 FROM dbo.Products WITH(NOLOCK) WHERE ProductName = 'P0003')
BEGIN
	INSERT Products (CategoryId, ProductName, ProductDescription, ProductPrice, ProductFeatured)
	VALUES (3, 'P0003', 'Electronics 0003', 20.25, 1)
End
Go
IF Not EXISTS(SELECT 1 FROM dbo.Products WITH(NOLOCK) WHERE ProductName = 'P0004')
BEGIN
	INSERT Products (CategoryId, ProductName, ProductDescription, ProductPrice, ProductFeatured)
	VALUES (4, 'P0004', 'Fitness 0004', 13.20, 0)
End
Go
IF Not EXISTS(SELECT 1 FROM dbo.Products WITH(NOLOCK) WHERE ProductName = 'P0005')
BEGIN
	INSERT Products (CategoryId, ProductName, ProductDescription, ProductPrice, ProductFeatured)
	VALUES (5, 'P0005', 'Toys 0005', 27.20, 0)
End
Go

CREATE or Alter PROC spGetCategories
AS
BEGIN
	SELECT C.CategoryId, C.CategoryName FROM Categories C
END
Go

CREATE or Alter PROC spGetFeaturedProducts
AS
BEGIN
	SELECT P.ProductId, P.ProductSku, P.ProductName, P.ProductDescription, P.ProductPrice
	FROM Products P
		INNER JOIN Categories C
			 ON P.CategoryId = C.CategoryId
	WHERE
		C.[CategoryProductsFeatured] = 1
		OR P.ProductFeatured = 1
END
Go

CREATE or Alter PROC spGetProductsByCategoryId
	@CategoryId INT
AS
BEGIN
	SELECT P.ProductId, P.ProductSku, P.ProductName, P.ProductDescription, P.ProductPrice
	FROM Products P
	WHERE
		P.CategoryId = @CategoryId
END