SET IDENTITY_INSERT [dbo].[Brands] ON 
GO
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (2, N'Vedata')
GO
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (3, N'Fortune')
GO
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (4, N'Aashirvaad')
GO
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (5, N'Tata')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryCode], [CategoryName]) VALUES (1, N'DL', N'Dals')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryCode], [CategoryName]) VALUES (2, N'FL', N'Flours')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryCode], [CategoryName]) VALUES (3, N'OL', N'Oil')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryCode], [CategoryName]) VALUES (4, N'SG', N'Sugar')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryCode], [CategoryName]) VALUES (5, N'RC', N'Rice')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Groceries] ON 
GO
INSERT [dbo].[Groceries] ([GroceryID], [GroceryName], [Price], [CategoryID], [BrandID]) VALUES (1, N'Black Chana 1 Kg', 95, 1, 2)
GO
INSERT [dbo].[Groceries] ([GroceryID], [GroceryName], [Price], [CategoryID], [BrandID]) VALUES (2, N'Red Masoor Whole 1 Kg', 115, 1, 2)
GO
INSERT [dbo].[Groceries] ([GroceryID], [GroceryName], [Price], [CategoryID], [BrandID]) VALUES (3, N'Toor Dal 1Kg', 127, 1, 2)
GO
INSERT [dbo].[Groceries] ([GroceryID], [GroceryName], [Price], [CategoryID], [BrandID]) VALUES (4, N'Unpolished Moong Dal 500 g', 89, 1, 5)
GO
INSERT [dbo].[Groceries] ([GroceryID], [GroceryName], [Price], [CategoryID], [BrandID]) VALUES (5, N'Chitra Rajma 1 Kg', 175, 1, 5)
GO
INSERT [dbo].[Groceries] ([GroceryID], [GroceryName], [Price], [CategoryID], [BrandID]) VALUES (6, N'Chana Besan 1Kg', 103, 2, 3)
GO
INSERT [dbo].[Groceries] ([GroceryID], [GroceryName], [Price], [CategoryID], [BrandID]) VALUES (7, N'Multigrain 5 Kg', 355, 2, 4)
GO
SET IDENTITY_INSERT [dbo].[Groceries] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderID], [GroceryID], [Quantity], [CustomerName], [ContactNo], [OrderDate]) VALUES (1, 1, 2, N'JOhn', N'6145859663', CAST(N'2021-06-06T20:44:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
