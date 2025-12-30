#     Enterprise-Resource-Planning ERP 🛒

![Status](https://img.shields.io/badge/Status-Development-yellow)
![Platform](https://img.shields.io/badge/Platform-Windows_Forms-blue)
![Database](https://img.shields.io/badge/Database-SQL_Server-red)
![Language](https://img.shields.io/badge/Language-C%23_.NET-purple)

**Enterprise-Resource-Planning** is a centralized, multi-branch Enterprise Resource Planning system designed for large-scale retail businesses. Unlike standard POS software, Nexus synchronizes inventory, sales, and staff management across a Head Office and multiple satellite branches in real-time.

---

## 🚀 Project Overview

The primary goal of Enterprise-Resource-Planning is to solve the problem of fragmented data in retail chains. It features a "God Mode" administration panel for business owners and a streamlined Point of Sale (POS) interface for branch staff.

**Key Highlights:**
* **Centralized Database:** A single SQL Server instance manages data for all branches.
* **Inter-Branch Synchronization:** Check stock levels at *other* branches directly from the POS.
* **Loyalty System:** Automated customer account creation and discount logic based on phone numbers.
* **Digital Indent Protocol:** A strict "Request & Approve" workflow for moving stock between branches.

---

## 📸 Screenshots
*(screenshots)*

| **Login Portal** | **Admin Dashboard** | **POS Interface** |
|:---:|:---:|:---:|
| ![Login](https://via.placeholder.com/250x150?text=Login+Screen) | ![Dashboard](https://via.placeholder.com/250x150?text=Admin+Dashboard) | ![POS](https://via.placeholder.com/250x150?text=POS+Screen) |

---

## 🛠 Tech Stack

* **Frontend:** C# Windows Forms (WinForms) with .NET Framework.
* **Backend:** Microsoft SQL Server.
* **Architecture:** Layered Architecture (UI, Business Logic, Data Access).
* **Reporting:** Microsoft RDLC Reports / MS Chart Controls.

---

## ✨ Key Features

### 1. Head Office (Super Admin)
* **Global Dashboard:** Real-time view of total sales, profit, and low-stock alerts across the company.
* **Master Product Entry:** Create products and manage variants (Sizes/Colors) centrally.
* **Approval Hub:** Review and approve/reject stock transfer requests from Branch Managers.

### 2. Branch Operations (Manager)
* **Stock Requisition:** Send digital "Indents" (requests) to Head Office for inventory replenishment.
* **Staff Management:** Manage cashier accounts and track shift attendance.
* **Expense Tracking:** Log daily operational costs (utilities, maintenance).

### 3. Point of Sale (Cashier)
* **Smart Billing:** Barcode-compatible interface with automated tax calculation.
* **Loyalty Integration:** Enter a phone number to instantly fetch customer details and apply "Regular Customer" discounts.
* **Global Search:** "Out of stock here? Let me check our other branch for you."

### 4. Public Kiosk (Customer View)
* **Price Checker:** A simple, read-only interface for customers to scan items and view prices.

---

## 💾 Database Schema (Brief)

The system is built on a relational SQL model:
* `Users` (Linked to `Branches`)
* `Inventory` (Links `Products` + `Branches` + `Variants`)
* `Transactions` (Master) & `TransactionDetails` (Child)
* `StockRequests` (Tracks status: Pending -> Approved -> Completed)

---

## ⚙️ Installation & Setup

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/SHYMOM/Enterprise-Resource-Planning.git
    ```
2.  **Database Setup:**
    * Open **SQL Server Management Studio (SSMS)**.
    * Create a new database named `NexusERP`.
    * Run the `Database_Script.sql` file located in the `SqlScripts` folder.
3.  **Configure Connection:**
    * Open the Solution in **Visual Studio**.
    * Navigate to `App.config` (or `DBHelper.cs`).
    * Update the `ConnectionString` with your local SQL Server name.
4.  **Run:**
    * Build and Start the project.
    * Default Admin Credentials: `admin` / `1234` (or whatever you set in your script).

---

## 🔮 Future Roadmap

* [ ] Mobile App for Owners to view sales on the go.
* [ ] Offline Mode with local database synchronization.
* [ ] Advanced BI (Business Intelligence) analytics.

---
