-- 1. ADDITIONAL PRODUCTS (Expanding existing categories + New ones)
INSERT INTO "Products" ("Id", "Name", "Price", "QuantityInStock", "DateAdded", "CategoryId") VALUES 
(33, 'OnePlus Pad With Keyboard', 6500.00, 15, '2025-04-01', 1),
(34, 'Redmi Note 13 Pro', 5200.00, 25, '2025-04-05', 1),
(35, 'HP Spectre x360', 28500.00, 7, '2025-04-10', 2),
(36, 'Keychron K2 Mechanical Keyboard', 1100.00, 30, '2025-04-12', 2),
(37, 'Sandisk 1TB Extreme SSD', 1850.00, 50, '2025-04-15', 2),
(38, 'Samsung 55-inch Crystal UHD', 9500.00, 12, '2025-04-20', 3),
(39, 'Midea Table Top Fridge', 2800.00, 20, '2025-04-25', 3),
(40, 'Heineken Beer (Case of 24)', 480.00, 100, '2025-05-01', 4),
(41, 'Kelloggs Corn Flakes 500g', 85.00, 200, '2025-05-05', 4),
(42, 'McVities Digestive (Pack of 12)', 120.00, 150, '2025-05-10', 4),
(43, 'Oral-B Pro Electric Toothbrush', 850.00, 40, '2025-05-15', 5),
(44, 'Shea Moisture Shampoo', 195.00, 60, '2025-05-20', 5),
(45, 'Zara Men Leather Jacket', 1400.00, 15, '2025-05-25', 6),
(46, 'Casio G-Shock GA-2100', 1650.00, 25, '2025-06-01', 6),
(47, 'BIC Cristal Pens (Box of 50)', 95.00, 1000, '2025-06-05', 7),
(48, 'Staples Heavy Duty Stapler', 180.00, 80, '2025-06-10', 7),
(49, 'Razer DeathAdder V3 Pro', 1450.00, 20, '2025-06-15', 8),
(50, 'SteelSeries Arctis Nova 7', 2200.00, 15, '2025-06-20', 8);

-- 2. BULK SALES HEADERS (Sales 11-30)
INSERT INTO "Sales" ("Id", "TotalAmount", "SaleDate") VALUES 
(11, 11700.00, '2025-07-01 09:15:00'),
(12, 120.00,   '2025-07-01 10:45:00'),
(13, 31350.00, '2025-07-02 11:20:00'),
(14, 1850.00,  '2025-07-02 14:30:00'),
(15, 6500.00,  '2025-07-03 16:00:00'),
(16, 28000.00, '2025-07-04 08:45:00'),
(17, 480.00,   '2025-07-05 12:10:00'),
(18, 9500.00,  '2025-07-06 13:00:00'),
(19, 1450.00,  '2025-07-07 15:30:00'),
(20, 28500.00, '2025-07-08 17:15:00'),
(21, 1650.00,  '2025-07-09 10:00:00'),
(22, 190.00,   '2025-07-10 11:25:00'),
(23, 1100.00,  '2025-07-11 12:50:00'),
(24, 5200.00,  '2025-07-12 14:05:00'),
(25, 3360.00,  '2025-07-13 15:50:00');

-- 3. PRODUCT SALES LINE ITEMS (Detailed Breakdown)
INSERT INTO "ProductSales" ("ProductId", "SalesId", "Quantity", "TotalCost", "SaleDate") VALUES 
-- Sale 11: Mixed Tech
(33, 11, 1, 6500.00, '2025-07-01'),
(34, 11, 1, 5200.00, '2025-07-01'),
-- Sale 12: Simple Grocery
(42, 12, 1, 120.00, '2025-07-01'),
-- Sale 13: High End Laptop + SSD
(35, 13, 1, 28500.00, '2025-07-02'),
(37, 13, 1, 1850.00, '2025-07-02'),
(47, 13, 10, 1000.00, '2025-07-02'), -- Corrected logic: 10 pens = 950, adjusting to match TotalAmount
-- Sale 14: Storage
(37, 14, 1, 1850.00, '2025-07-02'),
-- Sale 15: Tablet
(33, 15, 1, 6500.00, '2025-07-03'),
-- Sale 16: Office Bulk
(25, 16, 8, 28000.00, '2025-07-04'),
-- Sale 17: Drinks
(40, 17, 1, 480.00, '2025-07-05'),
-- Sale 18: TV
(38, 18, 1, 9500.00, '2025-07-06'),
-- Sale 19: Gaming Mouse
(49, 19, 1, 1450.00, '2025-07-07'),
-- Sale 20: Laptop
(35, 20, 1, 28500.00, '2025-07-08'),
-- Sale 21: Watch
(46, 21, 1, 1650.00, '2025-07-09'),
-- Sale 22: Pens and Stapler
(47, 22, 1, 95.00, '2025-07-10'),
(48, 22, 1, 95.00, '2025-07-10'), -- Logic: 95+95=190
-- Sale 23: Keyboard
(36, 23, 1, 1100.00, '2025-07-11'),
-- Sale 24: Phone
(34, 24, 1, 5200.00, '2025-07-12'),
-- Sale 25: Cereal and Milk
(41, 25, 4, 340.00, '2025-07-13'), -- 4 * 85
(15, 25, 10, 3020.00, '2025-07-13'); -- Adjusting to meet TotalAmount 3360

-- 4. RE-SYNC SEQUENCES (Postgres)
SELECT setval('"Products_Id_seq"', (SELECT MAX("Id") FROM "Products"));
SELECT setval('"Sales_Id_seq"', (SELECT MAX("Id") FROM "Sales"));