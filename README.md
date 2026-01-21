# Nexus Retail ERP

**Nexus Retail ERP** is a comprehensive desktop-based Enterprise Resource Planning system designed for multi-branch retail businesses. Unlike standalone POS systems, Nexus ERP connects multiple store locations to a central Head Office, enabling real-time inventory synchronization, inter-branch stock transfers, and centralized management.

Built with **C# (Windows Forms)** and **Microsoft SQL Server**, this project addresses the complex logistical challenges of retail chains, such as balancing stock between outlets and securing sensitive data with SHA-256 encryption.

---

## 🚀 Key Features

### 1. 👑 Owner (Super Admin)
* **Global Dashboard:** View real-time revenue, sales, and inventory data across all branches.
* **Telegram Integration:** Receive instant alerts on your phone for staff logins, critical stock requests, and suspicious activity.
* **Audit Logging:** Track every user action (login, sale, edit) with timestamps and IP details.
* **Master Control:** Approve complex stock movements and manage employee access roles.

### 2. 🏢 Branch Manager
* **Stock Logistics:**
    * **Request Restock:** Order new inventory from the Head Office.
    * **Inter-Branch Transfer:** Request specific items (e.g., "Mouse Black") directly from other branches (e.g., "Uttara Outlet") if local stock is low.
* **Approval System:** Review and approve/reject incoming stock requests from other branches.
* **Low Stock Alerts:** Visual indicators (Red/Orange highlights) when inventory dips below the defined limit.

### 3. 🛒 Cashier (POS)
* **Point of Sale:** Fast, keyboard-friendly interface for processing sales (Cash/Card/Mobile).
* **Stock Validation:** Prevents adding items to the cart if local stock is insufficient.
* **Transfer Requests:** If an item is out of stock, the cashier can initiate a transfer request on behalf of the customer directly from the POS.
* **Invoice Generation:** Auto-generates unique invoices and financial records.

### 4. 🖥️ Customer Kiosk Module
* **Self-Service Browsing:** A touch-friendly, full-screen interface for customers to explore products.
* **Location-Aware Stock:**
    * Shows **"In Stock"** if available at the current branch.
    * Shows **"Available at [Branch Name]"** if out of stock locally.
* **Security:** Runs in a locked full-screen mode. Exiting requires a specific "Hidden Action" (Double-click Title) and an Admin PIN.

---

## 🛠️ Technology Stack

* **Language:** C# (.NET Core / .NET Framework)
* **Framework:** Windows Forms (WinForms)
* **Database:** Microsoft SQL Server (2019/2022)
* **Security:** SHA-256 Password Hashing
* **Notifications:** Telegram Bot API
* **Reporting:** Microsoft RDLC / DataGridView Exports

---

## 🗄️ Database Structure

The system uses a highly normalized Relational Database (3NF) consisting of **14 interconnected tables**:
* **Core:** `Users`, `Branches`, `Customers`
* **Inventory:** `Products`, `Variants` (Color/Size), `Inventory` (Links Branch-Variant)
* **Logistics:** `StockRequests` (Tracks From/To Branch movements)
* **Sales:** `Transactions`, `TransactionDetails`, `FinancialRecords`

---

## ⚙️ Installation & Setup

### Prerequisites
* Visual Studio 2019 or 2022
* Microsoft SQL Server Management Studio (SSMS)
* .NET Desktop Runtime

### Step 1: Database Setup
1.  Open **SSMS**.
2.  Open the `NexusERP_Database_Script.sql` file located in the `Database` folder.
3.  Execute the script to create the `NexusERP` database and populate it with mock test data.

### Step 2: Configuration
1.  Open the solution file `NexusERP.sln` in Visual Studio.
2.  Open `App.config` (or `DbContext` settings).
3.  Update the **Connection String** to match your local SQL Server instance:
    ```xml
    <add name="NexusDB" connectionString="Data Source=YOUR_PC_NAME;Initial Catalog=NexusERP;Integrated Security=True;" providerName="System.Data.SqlClient" />
    ```

### Step 3: Run the Application
1.  Press **F5** to build and run.
2.  Use the following default credentials for testing:

| Role | Username | Password | Notes |
| :--- | :--- | :--- | :--- |
| **Owner** | `admin` | `1234` | Full Access |
| **Manager** | `manager_dh` | `1234` | Dhanmondi Branch |
| **Cashier** | `cashier_dh` | `1234` | Dhanmondi POS |

---

## 📸 Usage Scenarios

1.  **Testing Low Stock:** Log in as `manager_dh` and check the Dashboard for items marked in Red.
2.  **Testing Kiosk:** Launch the Kiosk form. Search for "Mouse". See if it directs you to the Uttara branch.
3.  **Testing Security:** Try to login with a wrong password and check the `AuditLogs` table in SQL.

---

## 📄 License
This project is developed for academic purposes and is open-source.
