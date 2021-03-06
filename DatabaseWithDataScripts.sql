USE [Nimap]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 30-03-2020 9.15.51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 30-03-2020 9.15.51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[CategoryId] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [IsActive]) VALUES (1, N'Electronics', 1)
INSERT [dbo].[Category] ([Id], [Name], [IsActive]) VALUES (8, N'Motor Bike', 0)
INSERT [dbo].[Category] ([Id], [Name], [IsActive]) VALUES (9, N'Eatables', 1)
INSERT [dbo].[Category] ([Id], [Name], [IsActive]) VALUES (10, N'Kitchen & Dining', 1)
INSERT [dbo].[Category] ([Id], [Name], [IsActive]) VALUES (11, N'Books', 1)
INSERT [dbo].[Category] ([Id], [Name], [IsActive]) VALUES (12, N'Movies', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (1, N'iPhone', 70000, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (8, N'Laptop', 50000, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (9, N'Powerbank', 1999, 1, 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (11, N'Mouse', 300, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (12, N'Ice cream', 40, 9, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (13, N'Spoons', 50, 10, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (14, N'Plates', 300, 10, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (15, N'Knives', 250, 10, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (16, N'Lighter', 100, 10, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (17, N'Grater', 1200, 10, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (18, N'Vegetable peeler ', 500, 10, 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (19, N'Mixing bowl ', 60, 10, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (20, N'Saucepans ', 230, 10, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (22, N'Big Mac', 50, 9, 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (23, N'Chicken McNuggets', 200, 9, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (24, N'French Fries', 150, 9, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (25, N'BBQ Ranch Burger', 600, 9, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (26, N'Side Salad', 100, 9, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (27, N'3 Idiots', 300, 12, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (28, N'Agneepath ', 300, 12, 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (29, N'Andaz Apna Apna ', 300, 12, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (30, N'Bajrangi Bhaijaan', 300, 12, 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (31, N'The Gremlins', 200, 11, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (32, N'The Magic Finger', 200, 11, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (33, N'Matilda', 200, 11, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (34, N'The BFG', 200, 11, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (35, N'The Immortals of Meluha', 300, 11, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (36, N'The Secret of the Nagas', 300, 11, 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (37, N'The Oath of the Vayuputras ', 350, 11, 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId], [IsActive]) VALUES (38, N'Wise And Otherwise', 350, 11, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
/****** Object:  StoredProcedure [dbo].[DeleteByIdCategory_sp]    Script Date: 30-03-2020 9.15.51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteByIdCategory_sp]
	@Id BIGINT   
AS
BEGIN
    DELETE FROM Category
	WHERE Id = @Id 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductById_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProductById_sp]
	@Id BIGINT   
AS
BEGIN
    DELETE FROM [dbo].[Product]
	WHERE Id = @Id 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategory_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategory_sp]
AS
BEGIN

    SELECT *
    FROM [dbo].[Category]
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategoryByIsActiveStatus_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategoryByIsActiveStatus_sp]
AS
BEGIN

    SELECT *
    FROM [dbo].[Category]
	WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProduct_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProduct_sp]
AS
BEGIN

    SELECT p.Id, p.Name AS "Product Name", p.Price, p.CategoryId AS "Category Id", c.Name AS "Category Name", p.IsActive
    FROM [dbo].[Product] p 
	JOIN [dbo].[Category] c ON p.CategoryId = c.Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryById_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryById_sp]
(
    @Id INT
)
AS
BEGIN

    SELECT *
    FROM [dbo].[Category]
WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductById_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductById_sp]
(
    @Id INT
)
AS
BEGIN

    SELECT *
    FROM [dbo].[Product]
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCategory_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCategory_sp]
    @Name       NVARCHAR(50),
	@IsActive BIT
AS
BEGIN
    INSERT INTO [dbo].[Category]
VALUES(
       @Name,
	   @IsActive)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertProduct_sp]
    (
	@Name       NVARCHAR(50),
	@Price INT,
	@CategoryId BIGINT,
	@IsActive BIT
	)
AS
BEGIN
    INSERT INTO [dbo].[Product]
VALUES(		
		@Name,     
		@Price ,
		@CategoryId,
		@IsActive
		)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoryById_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCategoryById_sp]
	@Id BIGINT,
    @Name       NVARCHAR(50),
	@IsActive BIT
AS
BEGIN
    UPDATE [dbo].[Category]
SET
   Name = @Name,
   IsActive = @IsActive

    WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductById_sp]    Script Date: 30-03-2020 9.15.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProductById_sp]
	(
	@Id BIGINT,
	@Name NVARCHAR(50),
	@Price INT,
	@CategoryId BIGINT,
	@IsActive BIT
	)
AS
BEGIN
    UPDATE [dbo].[Product]
SET
   Name = @Name,
   Price = @Price,
   CategoryId = @CategoryId,
   IsActive = @IsActive
   
   WHERE Id = @Id
END
GO
