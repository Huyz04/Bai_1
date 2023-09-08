CREATE DATABASE BAI1;
USE BAI1;


CREATE TABLE product (
  ID INT  NOT NULL ,
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

ALTER TABLE product
ADD CONSTRAINT UX_product_code UNIQUE (code);


INSERT INTO product (ID, Code, Name, Category, Brand, Type, Description) VALUES (1, 'P001', 'MASK ADULT Surgical 3 ply 50''S MEDICOS with box', 'Health Accessories', 'Medicos', 'Hygiene', 'Colour: Blue (ear loop outside, ear loop inside- random assigned), Green, Purple, White, Lime Green, Yellow, Pink');
INSERT INTO product  (ID, Code, Name, Category, Brand, Description) VALUES (2, 'P002', 'Party Cosplay Player Unknown Battlegrounds Clothes Hallowmas PUBG', 'Men''s Clothing', 'No Brand', 'Suitable for adults and children.');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (3, 'P003', 'Xiaomi REDMI 8A Official Global Version 5000 mAh battery champion 31 days 2GB+32GB', 'Mobile & Gadgets', 'Xiaomi', 'Mobile Phones', 'Xiaomi Redmi 8A');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (4, 'P004', 'Naelofar Sofis - Printed Square', 'Hijab', 'Naelofar', 'Multi Colour Floral', 'Ornate Iris flower composition with intricate growing foliage');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (5, 'P005', 'Philips HR2051 / HR2056 / HR2059 Ice Crushing Blender Jar Mill', 'Small Kitchen Appliances', 'Philips', 'Mixers & Blenders', 'Philips HR2051 Blender (350W, 1.25L Plastic Jar, 4 stars stainless steel blade)');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (6, 'P006', 'Gemei GM-6005 Rechargeable Trimmer Hair Cutter Machine', 'Hair Styling Tools', 'Gemei', 'Trimmer', 'The GEMEI hair clipper is intended for professional use.');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (7, 'P007', 'Oreo Crumb Small Crushed Cookie Pieces 454g', 'Snacks', 'Oreo', 'Biscuits & Cookies', 'Oreo Crumb Small Crushed Cookie Pieces 454g - Retail & Wholesale New Stock Long Expiry!!!');
INSERT INTO product  (ID, Code, Name, Category, Brand, Description) VALUES (8, 'P008', 'Non-contact Infrared Forehead Thermometer ABS', 'Kids Health & Skincare', 'No Brand', 'Non-contact Infrared Forehead Thermometer ABS for Adults and Children with LCD Display Digital');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (9, 'P009', 'Nordic Marble Starry Sky Bedding Sets', 'Bedding', 'No Brand', 'Bedding Sheets', 'Printing process: reactive printing. Package:quilt cover ,bed sheet ,pillow case. Not include comforter or quilt.');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (10, 'P010', 'Samsung Galaxy Tab A 10.1''', 'Mobile & Gadgets', 'Samsung', 'Tablets', '4GB RAM. - 64GB ROM. - 1.5 ghz Processor. - 10.1 inches LCD Display');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (11, 'P011', 'REALME 5 PRO 6+128GB', 'Mobile & Gadgets', 'Realme', 'Mobile Phones', 'REALME 5 PRO 6+128GB');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (12, 'P012', 'Nokia 2.3 - Cyan Green', 'Mobile & Gadgets', 'Nokia', 'Mobile Phones', 'Nokia smartphones get 2 years of software upgrades and 3 years of monthly security updates.');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (13, 'P013', 'AKEMI Cotton Select Fitted Bedsheet Set - Adore 730TC', 'Bedding', 'Akemi', 'Bedding Sheets', '100% Cotton Twill. Super Single.');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (14, 'P014', 'Samsung Note10+ Phone', 'Mobile & Gadgets', 'OEM', 'Mobile Phones', 'OEM Phone Models');
INSERT INTO product  (ID, Code, Name, Category, Brand, Type, Description) VALUES (15, 'P015', 'Keknis Basic Wide Long Shawl', 'Hijab', 'No Brand', 'Plain Shawl', '1.8m X 0.7m (+/-). Heavy chiffon (120 gsm).');


COMMIT;

SELECT * FROM product; 

SELECT

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
CREATE PROCEDURE Insert_product
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
	INSERT INTO product 
	(ID, Code, Name, Category, Brand, Type, Description) 
	VALUES 
	(
		@ID,
		@Code, 
		@Name,
		@Category, 
		@Brand ,
		@Type ,
		@Description 
	);

END
GO

SET IDENTITY_INSERT product ON;
-- proc update
CREATE PROCEDURE Update_product
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
	UPDATE product
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
CREATE PROCEDURE Delete_product
	@ID INT
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM product
	WHERE ID = @ID;
END
GO

-- proc select all
CREATE PROCEDURE Select_all_product
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * 
	FROM product;
END
GO

-- proc select dựa vào ID
CREATE PROCEDURE Select_ID_product
@ID INT
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * FROM product
	WHERE ID = @ID;
END
GO

exec Select_all_product;

-- proc select dựa vào Name
CREATE PROCEDURE Find_Product_Name
@Name VARCHAR(90)
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * FROM product
	WHERE Name LIKE '%'+@Name+'%';
END
GO

-- Proc select dựa vào Brand
CREATE or alter PROCEDURE Find_Product_Brand
@Brand VARCHAR(28)
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * FROM product
	WHERE Brand LIKE '%'+@Brand+'%';
END
GO

execute Find_Product_Brand @Brand = 'Samsung';

----------------

-- Proc phân trang
CREATE or alter PROCEDURE Paging
@Ignore INT,
@Size INT
AS
BEGIN
	SELECT *
	FROM product
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

CREATE or alter PROCEDURE Total
AS
BEGIN
	SELECT COUNT(*) AS TOTAL FROM product;
END
GO

EXECUTE Total;


