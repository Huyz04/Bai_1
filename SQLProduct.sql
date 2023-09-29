--------------------------TESSTT-------------------------------
Create Table test (
ID INT IDENTITY(1,1) PRIMARY KEY,
NAME VARCHAR(10) 
)

INSERT INTO test (NAME) VALUES ('THANH TU');
DECLARE @nextID INT;
SET @nextID = SCOPE_IDENTITY();
PRINT(@nextID);

SELECT * FROM test;

DECLARE @currentID INT;
DECLARE @a VARCHAR(9);

SET @currentID = IDENT_CURRENT('Products');
SET @a = 'P' + CONVERT(VARCHAR(8),@currentID+1);
PRINT(@a);






------------------------------------------------------------
CREATE DATABASE BAI1;
USE BAI1;
DROP DATABASE BAI1;

CREATE TABLE Products (
  ID INT IDENTITY(1,1) NOT NULL ,
  Code VARCHAR(9) NOT NULL,
  Name VARCHAR(90) NOT NULL,
  Category VARCHAR(28) NOT NULL,
  Brand VARCHAR(28) DEFAULT NULL,
  Type VARCHAR(21) DEFAULT NULL,
  Description VARCHAR(180) DEFAULT NULL,
  Created_at DATETIME DEFAULT GETDATE(),
  Updated_at DATETIME DEFAULT GETDATE(),
  PRIMARY KEY (id),
) 

DROP TABLE Products;

ALTER TABLE Products
ADD CONSTRAINT UX_product_code UNIQUE (code);

Select * FROM Products;

INSERT INTO Products (Code, Name, Category, Brand, Type, Description) VALUES ('P001', 'MASK ADULT Surgical 3 ply 50''S MEDICOS with box', 'Health Accessories', 'Medicos', 'Hygiene', 'Colour: Blue (ear loop outside, ear loop inside- random assigned), Green, Purple, White, Lime Green, Yellow, Pink');
INSERT INTO Products  (Code, Name, Category, Brand, Description) VALUES ('P002', 'Party Cosplay Player Unknown Battlegrounds Clothes Hallowmas PUBG', 'Men''s Clothing', 'No Brand', 'Suitable for adults and children.');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P003', 'Xiaomi REDMI 8A Official Global Version 5000 mAh battery champion 31 days 2GB+32GB', 'Mobile & Gadgets', 'Xiaomi', 'Mobile Phones', 'Xiaomi Redmi 8A');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P004', 'Naelofar Sofis - Printed Square', 'Hijab', 'Naelofar', 'Multi Colour Floral', 'Ornate Iris flower composition with intricate growing foliage');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P005', 'Philips HR2051 / HR2056 / HR2059 Ice Crushing Blender Jar Mill', 'Small Kitchen Appliances', 'Philips', 'Mixers & Blenders', 'Philips HR2051 Blender (350W, 1.25L Plastic Jar, 4 stars stainless steel blade)');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P006', 'Gemei GM-6005 Rechargeable Trimmer Hair Cutter Machine', 'Hair Styling Tools', 'Gemei', 'Trimmer', 'The GEMEI hair clipper is intended for professional use.');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P007', 'Oreo Crumb Small Crushed Cookie Pieces 454g', 'Snacks', 'Oreo', 'Biscuits & Cookies', 'Oreo Crumb Small Crushed Cookie Pieces 454g - Retail & Wholesale New Stock Long Expiry!!!');
INSERT INTO Products  (Code, Name, Category, Brand, Description) VALUES ('P008', 'Non-contact Infrared Forehead Thermometer ABS', 'Kids Health & Skincare', 'No Brand', 'Non-contact Infrared Forehead Thermometer ABS for Adults and Children with LCD Display Digital');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P009', 'Nordic Marble Starry Sky Bedding Sets', 'Bedding', 'No Brand', 'Bedding Sheets', 'Printing process: reactive printing. Package:quilt cover ,bed sheet ,pillow case. Not include comforter or quilt.');
INSERT INTO Products (Code, Name, Category, Brand, Type, Description) VALUES ('P010', 'Samsung Galaxy Tab A 10.1''', 'Mobile & Gadgets', 'Samsung', 'Tablets', '4GB RAM. - 64GB ROM. - 1.5 ghz Processor. - 10.1 inches LCD Display');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P011', 'REALME 5 PRO 6+128GB', 'Mobile & Gadgets', 'Realme', 'Mobile Phones', 'REALME 5 PRO 6+128GB');
INSERT INTO Products (Code, Name, Category, Brand, Type, Description) VALUES ('P012', 'Nokia 2.3 - Cyan Green', 'Mobile & Gadgets', 'Nokia', 'Mobile Phones', 'Nokia smartphones get 2 years of software upgrades and 3 years of monthly security updates.');
INSERT INTO Products (Code, Name, Category, Brand, Type, Description) VALUES ('P013', 'AKEMI Cotton Select Fitted Bedsheet Set - Adore 730TC', 'Bedding', 'Akemi', 'Bedding Sheets', '100% Cotton Twill. Super Single.');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P014', 'Samsung Note10+ Phone', 'Mobile & Gadgets', 'OEM', 'Mobile Phones', 'OEM Phone Models');
INSERT INTO Products  (Code, Name, Category, Brand, Type, Description) VALUES ('P015', 'Keknis Basic Wide Long Shawl', 'Hijab', 'No Brand', 'Plain Shawl', '1.8m X 0.7m (+/-). Heavy chiffon (120 gsm).');


COMMIT;


SELECT * FROM Products;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--proc insert
CREATE OR ALTER PROCEDURE Insert_product
	@Name VARCHAR(90),
	@Category VARCHAR(28),
	@Brand VARCHAR(28),
	@Type VARCHAR(21),
	@Description VARCHAR(180)
AS
BEGIN
	SET NOCOUNT OFF;

	-- Khai báo biến Code và currentID
	DECLARE @Code VARCHAR(9);
	DECLARE @currentID INT;

	-- Lấy giá trị ID hiện tại của bảng Products
	SET @currentID = IDENT_CURRENT('Products');

	-- Tính toán giá trị Code
	SET @Code = 'P' + CONVERT(VARCHAR(8), @currentID + 1);

	-- Chèn dữ liệu mới vào bảng và sử dụng biến đầu ra trực tiếp
	INSERT INTO Products
		(Code, Name, Category, Brand, Type, Description) 
	VALUES 
		(
			@Code, 
			@Name,
			@Category, 
			@Brand ,
			@Type ,
			@Description 
		);

	-- Select lại PRODUCTS đã thêm vào
	SELECT * FROM Products
	WHERE I;
	
END
GO


EXEC Insert_product @Name='IP14',@Category='ajfs',@Brand='fasfa' ,@Type = 'sfasf',@Description='safasf';
PRINT(@ID+'  '+@OCode);



-- Gọi quy trình lưu trữ và nhận giá trị đầu ra
EXEC Insert_product 
    @Name = 'Sản phẩm A',
    @Category = 'Danh mục A',
    @Brand = 'Nhãn hiệu A',
    @Type = 'Loại A',
    @Description = 'Mô tả sản phẩm A',
    @ID = @ProductID OUTPUT,
    @OCode = @ProductCode OUTPUT;

-- In giá trị đầu ra
PRINT 'ID của sản phẩm mới là: ' + CAST(@ProductID AS VARCHAR);
PRINT 'Mã sản phẩm mới là: ' + @ProductCode;

SET IDENTITY_INSERT product ON;
-- proc update
CREATE or alter PROCEDURE Update_product
	@ID INT,
	@Code VARCHAR(9),
	@Name VARCHAR(90),
	@Category VARCHAR(28),
	@Brand VARCHAR(28),
	@Type VARCHAR(21),
	@Description VARCHAR(180)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE Products
	SET Code = @Code,
		Name = @Name,
		Category = @Category,
		Brand = @Brand,
		Type = @Type,
		Description = @Description
	WHERE ID = @ID;
END
GO

-- proc xoa
CREATE or alter PROCEDURE Delete_product
	@ID INT
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM Products
	WHERE ID = @ID;
END
GO

exec Delete_product @ID = 16;
-- proc select all
CREATE or alter PROCEDURE Select_all_product
	@Page INT,
	@PageSize INT
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * 
	FROM Products
	ORDER BY ID
	OFFSET (@Page-1)*@PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
GO

exec Select_all_product @Page=3, @PageSize =5;

-- proc select dựa vào ID
CREATE or alter PROCEDURE Select_ID_product
@ID INT
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * FROM Products
	WHERE ID = @ID;
END
GO

exec Select_ID_product @ID =1;
-- Proc Find
CREATE or alter PROCEDURE Find_Product
@Info VARCHAR(90),
@Type VARCHAR(20),
@Page INT,
@PageSize INT
AS
BEGIN
	SET NOCOUNT OFF;
		IF @Type = 'Name'
		BEGIN
			SELECT * FROM Products
			WHERE Name LIKE '%'+@Info+'%'
			ORDER BY ID
			OFFSET (@Page-1)*@PageSize ROWS
			FETCH NEXT @PageSize ROWS ONLY;
		END
		ELSE
		BEGIN
			SELECT * FROM Products
			WHERE Brand LIKE '%'+@Info+'%'
			ORDER BY ID
			OFFSET (@Page-1)*@PageSize ROWS
			FETCH NEXT @PageSize ROWS ONLY;
		END
END
GO

EXEC Find_Product @Info ='o', @Type = 'Name', @Page =3, @PageSize =5
----------------

-- Proc phân trang
CREATE or alter PROCEDURE Paging
@Ignore INT,
@Size INT
AS
BEGIN
	SELECT *
	FROM Products
	ORDER BY ID
	OFFSET @Ignore ROWS
	FETCH NEXT @Size ROWS ONLY;
END
GO

EXECUTE Paging @Ignore = 13, @Size =5;
------
SELECT *
FROM product
ORDER BY ID
OFFSET 5 ROWS
FETCH NEXT 3 ROWS ONLY;

SELECT COUNT(*) AS TOTAL FROM product;

--total
CREATE or alter PROCEDURE Total
@Info VARCHAR(90),
@Type VARCHAR(20)
AS
BEGIN
	IF(@Info ='' AND @Type ='')
	BEGIN
		SELECT COUNT(*) AS TOTAL FROM Products;
	END
	ELSE
	BEGIN
		IF @Type = 'Name'
	BEGIN
		SELECT COUNT(*) AS TOTAL FROM Products
		WHERE Name LIKE '%'+@Info+'%';
	END
	ELSE
	BEGIN
		SELECT COUNT(*) AS TOTAL FROM Products
		WHERE Brand LIKE '%'+@Info+'%';
	END
	END
END
GO

EXECUTE Total @Info='', @Type ='';
			SELECT * FROM Products
			WHERE Name LIKE '%o%'
			ORDER BY ID
			OFFSET 3 ROWS
			FETCH NEXT 3 ROWS ONLY;


