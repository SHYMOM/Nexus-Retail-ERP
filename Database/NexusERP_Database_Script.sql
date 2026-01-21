USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'NexusERP')
BEGIN
    ALTER DATABASE NexusERP SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE NexusERP;
END
GO

CREATE DATABASE NexusERP;
GO

USE NexusERP;
GO

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Branches (
    BranchID INT PRIMARY KEY IDENTITY(1,1),
    BranchName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(250),
    Phone NVARCHAR(20),
    IsActive BIT DEFAULT 1
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Phone NVARCHAR(20) UNIQUE NOT NULL,
    CustomerName NVARCHAR(100),
    Email NVARCHAR(100),
    Address NVARCHAR(250),
    DOB DATE NULL,
    TotalSpent DECIMAL(18,2) DEFAULT 0,
    LoyaltyPoints INT DEFAULT 0
);


CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(250) NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    FullName NVARCHAR(100),
    Salary DECIMAL(18,2) DEFAULT 0,
    Phone NVARCHAR(20) UNIQUE NOT NULL,
    Address NVARCHAR(250),
    DOB DATE NULL,
    ProfileImagePath NVARCHAR(500),
    IsActive BIT DEFAULT 1,
    BranchID INT FOREIGN KEY REFERENCES Branches(BranchID),
    LastLogin DATETIME NULL
);

CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY(1,1),
    Date DATE DEFAULT CAST(GETDATE() AS DATE),
    CheckInTime DATETIME,
    CheckOutTime DATETIME NULL,
    UserID INT FOREIGN KEY REFERENCES Users(UserID)
);

CREATE TABLE AuditLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Action NVARCHAR(100) NOT NULL,
    TableName NVARCHAR(100),
    RecordID INT NULL,
    OldValue NVARCHAR(MAX),
    NewValue NVARCHAR(MAX),
    LogDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(150) NOT NULL,
    Description NVARCHAR(500),
    ProductImagePath NVARCHAR(500), 
    TaxRate DECIMAL(5,2) DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID)
);

CREATE TABLE Variants (
    VariantID INT PRIMARY KEY IDENTITY(1,1),
    VariantName NVARCHAR(100) NOT NULL,
    UOM NVARCHAR(50),
    CostPrice DECIMAL(18,2) DEFAULT 0,
    SalesPrice DECIMAL(18,2) NOT NULL,
    SKU NVARCHAR(50) UNIQUE,
    VariantImagePath NVARCHAR(500),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID)
);

CREATE TABLE Inventory (
    InventoryID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    VariantID INT NOT NULL FOREIGN KEY REFERENCES Variants(VariantID),
    BranchID INT NOT NULL FOREIGN KEY REFERENCES Branches(BranchID),
    CurrentStock INT DEFAULT 0,
    LowStockLimit INT DEFAULT 10
);

CREATE TABLE DamagedStock (
    DamageID INT PRIMARY KEY IDENTITY(1,1),
    Quantity INT NOT NULL,
    Reason NVARCHAR(200),
    ReportedDate DATETIME DEFAULT GETDATE(),
    BranchID INT FOREIGN KEY REFERENCES Branches(BranchID),
    VariantID INT FOREIGN KEY REFERENCES Variants(VariantID),
    ReportedBy INT FOREIGN KEY REFERENCES Users(UserID)
);

CREATE TABLE StockRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    RequestType NVARCHAR(50),
    Quantity INT NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Pending',
    RequestDate DATETIME DEFAULT GETDATE(),
    FromBranchID INT FOREIGN KEY REFERENCES Branches(BranchID),
    ToBranchID INT FOREIGN KEY REFERENCES Branches(BranchID),
    VariantID INT FOREIGN KEY REFERENCES Variants(VariantID),
    RequestedBy INT FOREIGN KEY REFERENCES Users(UserID)
);


CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    InvoiceNo NVARCHAR(50) UNIQUE,
    TransactionDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(18,2),
    DiscountAmount DECIMAL(18,2) DEFAULT 0,
    FinalAmount DECIMAL(18,2),
    PaymentMethod NVARCHAR(50),
    BranchID INT FOREIGN KEY REFERENCES Branches(BranchID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
);

CREATE TABLE TransactionDetails (
    DetailID INT PRIMARY KEY IDENTITY(1,1),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2),
    TaxAmount DECIMAL(18,2) DEFAULT 0,
    Subtotal DECIMAL(18,2),
    TransactionID INT FOREIGN KEY REFERENCES Transactions(TransactionID),
    VariantID INT FOREIGN KEY REFERENCES Variants(VariantID)
);

CREATE TABLE FinancialRecords (
    RecordID INT PRIMARY KEY IDENTITY(1,1),
    TransactionID INT NULL FOREIGN KEY REFERENCES Transactions(TransactionID),
    PaymentMethod NVARCHAR(50) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    ReferenceNo NVARCHAR(100) NULL,
    Description NVARCHAR(200)
);
GO


INSERT INTO Categories (CategoryName) VALUES 
('Men''s Fashion'), 
('Electronics'), 
('Home Appliances'), 
('Groceries');

INSERT INTO Branches (BranchName, Location, Phone, IsActive) VALUES 
('Head Office', 'Gulshan-2, Dhaka', '01711000000', 1),
('Dhanmondi Outlet', 'Road 27, Dhanmondi', '01711000001', 1),
('Uttara Outlet', 'Sector 4, Uttara', '01711000002', 1);

INSERT INTO Customers (Phone, CustomerName, Email, Address, LoyaltyPoints, TotalSpent) VALUES 
('01900000000', 'Walk-in Customer', NULL, NULL, 0, 0),
('01755555555', 'Rahim Ahmed', 'rahim@test.com', 'Mirpur, Dhaka', 120, 15000.00),
('01888888888', 'Karim Ullah', 'karim@test.com', 'Banani, Dhaka', 50, 5000.00);

INSERT INTO Users (Username, PasswordHash, Role, FullName, Salary, Phone, BranchID, IsActive) VALUES 
('admin', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'Owner', 'Super Admin', 200000, '01500000001', 1, 1),
('manager_dh', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'Manager', 'Dhanmondi Manager', 60000, '01500000002', 2, 1),
('cashier_dh', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'Cashier', 'Dhanmondi Cashier', 30000, '01500000003', 2, 1),
('manager_ut', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'Manager', 'Uttara Manager', 60000, '01500000004', 3, 1),
('cashier_ut', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'Cashier', 'Uttara Cashier', 30000, '01500000005', 3, 1);


INSERT INTO Products (ProductName, Description, TaxRate, CategoryID) VALUES 
('Premium Polo Shirt', '100% Cotton, Export Quality', 5.00, 1),
('Wireless Mouse', 'Silent Click, 2.4GHz', 7.50, 2),
('Blender 750W', 'Heavy Duty Mixer Grinder', 7.50, 3),
('Basmati Rice', 'Premium Long Grain', 0.00, 4);

INSERT INTO Variants (VariantName, UOM, CostPrice, SalesPrice, SKU, ProductID) VALUES 
('Navy Blue - M', 'Pcs', 450, 950, 'POLO-NB-M', 1),
('Navy Blue - L', 'Pcs', 450, 950, 'POLO-NB-L', 1),
('Black - M', 'Pcs', 450, 950, 'POLO-BK-M', 1),
('Black Matte', 'Pcs', 350, 700, 'MOUSE-BLK', 2),
('White Glossy', 'Pcs', 350, 750, 'MOUSE-WHT', 2),
('Standard Model', 'Box', 2500, 4200, 'BLEND-750', 3),
('5KG Pack', 'Bag', 400, 650, 'RICE-5KG', 4);

INSERT INTO Inventory (ProductID, VariantID, BranchID, CurrentStock, LowStockLimit) VALUES 

(1, 1, 2, 50, 10),
(1, 2, 2, 3, 10),
(2, 4, 2, 0, 5),
(4, 7, 2, 100, 20),
(1, 1, 3, 20, 10),
(2, 4, 3, 45, 5);

INSERT INTO StockRequests (RequestType, Quantity, Status, RequestDate, FromBranchID, ToBranchID, VariantID, RequestedBy) VALUES 

('Restock', 100, 'Approved', DATEADD(day, -5, GETDATE()), 1, 2, 1, 2),
('Transfer', 10, 'Pending', GETDATE(), 3, 2, 4, 2);

INSERT INTO Transactions (InvoiceNo, TotalAmount, DiscountAmount, FinalAmount, PaymentMethod, BranchID, UserID, CustomerID, TransactionDate)
VALUES ('INV-TEST-001', 1900, 0, 1900, 'Cash', 2, 3, 1, DATEADD(hour, -4, GETDATE()));

INSERT INTO TransactionDetails (Quantity, UnitPrice, TaxAmount, Subtotal, TransactionID, VariantID) VALUES 
(2, 950, 0, 1900, 1, 1);

INSERT INTO FinancialRecords (TransactionID, PaymentMethod, Amount, TransactionDate, Description)
VALUES (1, 'Cash', 1900, DATEADD(hour, -4, GETDATE()), 'Sales Invoice INV-TEST-001');
GO
