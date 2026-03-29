-- 1. SEED CATEGORIES
INSERT INTO "Categories" ("Id", "Name") VALUES 
(1, 'Phones & Tablets'),
(2, 'Laptops & Accessories'),
(3, 'Home Appliances'),
(4, 'Groceries & Provisions'),
(5, 'Health & Beauty'),
(6, 'Fashion & Apparel'),
(7, 'Office Stationery'),
(8, 'Gaming & VR'),
(9, 'Outdoor & Sports'),
(10, 'Automotive');

-- 2. SEED PRODUCTS
-- Prices in GHS based on 2026 market projections.
INSERT INTO "Products" ("Id", "Name", "Price", "QuantityInStock", "DateAdded", "CategoryId") VALUES 
(1, 'Samsung Galaxy S24 Ultra', 15500.0, 20, '2025-01-10', 1),
(2, 'iPhone 15 Pro Max 256GB', 18200.0, 15, '2025-01-15', 1),
(3, 'Google Pixel 8 Pro', 12400.0, 12, '2025-02-01', 1),
(4, 'OnePlus 12 512GB', 9500.0, 18, '2025-02-05', 1),
(5, 'MacBook Pro M3 Max 16-inch', 48500.0, 8, '2025-01-04', 2),
(6, 'Dell XPS 15 OLED', 32000.0, 10, '2025-01-20', 2),
(7, 'Asus ROG Strix G16', 28500.0, 12, '2025-02-12', 2),
(8, 'Logitech MX Master 3S', 1200.0, 45, '2025-03-01', 2),
(9, 'LG French Door Refrigerator', 22000.0, 5, '2025-02-10', 3),
(10, 'Panasonic Microwave 25L', 3500.0, 30, '2025-02-15', 3),
(11, 'Whirlpool Washer 9kg', 8500.0, 8, '2025-03-05', 3),
(12, 'Philips Steam Iron', 750.0, 50, '2025-03-10', 3),
(13, 'Gino Tomato Paste (Box of 50)', 145.0, 100, '2025-01-05', 4),
(14, 'Frytol Vegetable Oil 5L', 185.0, 200, '2025-01-12', 4),
(15, 'Ideal Milk (Crate of 24)', 320.0, 40, '2025-01-20', 4),
(16, 'Basmati Rice 5kg', 280.0, 150, '2025-02-01', 4),
(17, 'Cerave Moisturizing Cream', 350.0, 80, '2025-01-10', 5),
(18, 'Dyson Airwrap Styler', 7200.0, 12, '2025-02-14', 5),
(19, 'Sunscreen SPF 50+', 180.0, 100, '2025-03-01', 5),
(20, 'Nike Air Force 1 07', 1850.0, 40, '2025-01-25', 6),
(21, 'Levis 501 Original Fit', 850.0, 60, '2025-02-05', 6),
(22, 'Adidas Ultraboost Light', 2200.0, 35, '2025-02-10', 6),
(23, 'A4 Paper Box (5 Riams)', 320.0, 250, '2025-01-05', 7),
(24, 'Parker Jotter Special Edition', 150.0, 500, '2025-01-10', 7),
(25, 'Epson EcoTank L3210 Printer', 3500.0, 15, '2025-02-15', 7),
(26, 'PlayStation 5 Console', 9800.0, 25, '2025-01-01', 8),
(27, 'Xbox Series X 1TB', 8900.0, 20, '2025-01-05', 8),
(28, 'Nintendo Switch OLED', 4500.0, 30, '2025-01-10', 8),
(29, 'Yoga Mat 6mm Non-slip', 250.0, 100, '2025-02-01', 9),
(30, 'Dumbbell Set 20kg', 1200.0, 40, '2025-02-10', 9),
(31, 'Castrol Edge 5W-30 4L', 550.0, 120, '2025-01-15', 10),
(32, 'Car Air Freshener Vanilla', 25.0, 1000, '2025-01-20', 10);

-- 3. SEED SALES (Headers)
INSERT INTO "Sales" ("Id", "TotalAmount", "SaleDate") VALUES 
(1, 33700.00, '2025-03-20 10:30:00'),
(2, 1965.00,  '2025-03-21 14:15:00'),
(3, 48500.00, '2025-03-22 09:00:00'),
(4, 980.00,   '2025-03-23 16:45:00'),
(5, 18200.00, '2025-03-24 11:20:00'),
(6, 25500.00, '2025-03-25 08:10:00'),
(7, 3500.00,  '2025-03-26 13:40:00'),
(8, 1200.00,  '2025-03-27 15:55:00'),
(9, 15500.00, '2025-03-28 10:00:00'),
(10, 2800.00, '2025-03-29 17:20:00');

-- 4. SEED PRODUCTSALES (Line Items)
INSERT INTO "ProductSales" ("ProductId", "SalesId", "Quantity", "TotalCost", "SaleDate") VALUES 
-- Sale 1
(1, 1, 1, 15500.00, '2025-03-20'),
(2, 1, 1, 18200.00, '2025-03-20'),
-- Sale 2
(14, 2, 5, 925.00, '2025-03-21'),
(13, 2, 4, 580.00, '2025-03-21'),
(16, 2, 1, 280.00, '2025-03-21'),
(24, 2, 1, 150.00, '2025-03-21'),
-- Sale 3
(5, 3, 1, 48500.00, '2025-03-22'),
-- Sale 4
(15, 4, 2, 640.00, '2025-03-23'),
(23, 4, 1, 320.00, '2025-03-23'),
(32, 4, 1, 20.00,  '2025-03-23'),
-- Sale 5
(2, 5, 1, 18200.00, '2025-03-24'),
-- Sale 6
(3, 6, 1, 12400.00, '2025-03-25'),
(11, 6, 1, 8500.00, '2025-03-25'),
(28, 6, 1, 4500.00, '2025-03-25'),
(19, 6, 1, 100.00,  '2025-03-25'),
-- Sale 7
(10, 7, 1, 3500.00, '2025-03-26'),
-- Sale 8
(8, 8, 1, 1200.00, '2025-03-27'),
-- Sale 9
(1, 9, 1, 15500.00, '2025-03-28'),
-- Sale 10
(30, 10, 2, 2400.00, '2025-03-29'),
(21, 10, 1, 400.00, '2025-03-29');

-- 5. UPDATE SEQUENCES
-- Essential for PostgreSQL to know where to start the next auto-incremented ID.
SELECT setval('"Categories_Id_seq"', (SELECT MAX("Id") FROM "Categories"));
SELECT setval('"Products_Id_seq"', (SELECT MAX("Id") FROM "Products"));
SELECT setval('"Sales_Id_seq"', (SELECT MAX("Id") FROM "Sales"));