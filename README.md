# Arena REST API

## Base URL
https://hovedopgteamet-cxdwanfbevcgcwhb.northeurope-01.azurewebsites.net/


[![CI/CD Pipeline](https://github.com/eudk/ArenaMapApp-Backend/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/eudk/ArenaMapApp-Backend/actions/workflows/dotnet-desktop.yml)
[![GitHub Stars](https://img.shields.io/github/stars/eudk/ArenaMapApp-Backend?style=social)](https://github.com/eudk/ArenaMapApp-Backend)
[![GitHub Contributors](https://img.shields.io/github/contributors/eudk/ArenaMapApp-Backend)](https://github.com/eudk/ArenaMapApp-Backend)
[![Last Commit](https://img.shields.io/github/last-commit/eudk/ArenaMapApp-Backend)](https://github.com/eudk/ArenaMapApp-Backend)

---

## Related Repositories
- **Frontend**: [ArenaMapApp-Frontend](https://github.com/eudk/ArenaMapApp-Frontend)
Front end website: [here](https://arenahovedopg-a8dyeqb9bhh4d4ex.germanywestcentral-01.azurewebsites.net/).

---

## Endpoints Overview

### **/EVENT**
- `GET /api/event`: Get all events.
- `GET /api/event/{id}`: Get event by ID.

### **/STALL**
- `GET /api/stall`: Get all stalls.
- `POST /api/stall`: Add a new stall.
- `PUT /api/stall/{id}`: Update an existing stall.
- `DELETE /api/stall/{id}`: Delete a stall.

### **/MENU**
- `POST /api/menu/{menuItemId}`: Add a new menu item.
- `GET /api/menu/all`: Get all menu items.
- `GET /api/menu/type/{stallType}`: Get menu items by type.
- `DELETE /api/menu/{menuItemId}`: Delete a menu item.

### **/ORDER**
- `GET /api/order/active`: Get active orders.
- `PUT /api/order/{orderId}/complete`: Mark an order as completed.
- `GET /api/order/{orderId}`: Get an order by ID.

### **/ADMIN**
- `POST /api/admin/login`: Login as an administrator.

---
# Arena REST API - Postman Tests

## Postman Test Code Blocks (selected)

### Test: GET Menu Items
```json
{
  "method": "GET",
  "url": "{{baseUrl}}/api/menu/all",
  "description": "Fetch all menu items",
  "tests": [
    {
      "script": "pm.test('Status code is 200', function () { pm.response.to.have.status(200); });"
    },
    {
      "script": "pm.test('Response is an array', function () { pm.expect(pm.response.json()).to.be.an('array'); });"
    }
  ]
}

```
### Test: POST Create Order

```json
{
  "method": "GET",
  "url": "{{baseUrl}}/api/menu/all",
  "description": "Fetch all menu items",
  "tests": [
    {
      "script": "pm.test('Status code is 200', function () { pm.response.to.have.status(200); });"
    },
    {
      "script": "pm.test('Response is an array', function () { pm.expect(pm.response.json()).to.be.an('array'); });"
    }
  ]
}

```
### Test: DELETE Menu Item

```json

{
  "method": "DELETE",
  "url": "{{baseUrl}}/api/menu/1",
  "description": "Delete a menu item by ID",
  "tests": [
    {
      "script": "pm.test('Status code is 204', function () { pm.response.to.have.status(204); });"
    },
    {
      "script": "pm.test('Response body is empty', function () { pm.expect(pm.response.text()).to.be.empty; });"
    }
  ]
}
```

---

# System Information

## Backend:
- **Hosting Platform:** Azure App Service - **B1 Plan**.
  - **Specifications**:
    - 1.75 GB RAM.
    - 10 GB Disk Space.
    - Manual Scale.
    - Custom Domain Support.
    - Pricing: Estimated $20/month.

## Database:
- **SQL Server (Free Tier)**:
  - **Configuration:**
    - **Type:** General Purpose - Serverless.
    - **Instance:** Standard-series (Gen5).
    - **vCores:** 2.
    - **Storage:** 32 GB.
  - **Cost:** Free-tier with potential scaling.

---
### Database tabeller
```
-- Table: Admins
CREATE TABLE Admins (
    AdminID INT NOT NULL PRIMARY KEY,
    Username NVARCHAR(255) NOT NULL,
    PasswordHash VARBINARY(MAX) NOT NULL,
    PasswordSalt VARBINARY(MAX) NOT NULL,
    LastLogin DATETIME NULL
);

-- Table: Events
CREATE TABLE Events (
    EventId INT NOT NULL PRIMARY KEY,
    EventName NVARCHAR(100) NOT NULL,
    EventDate DATETIME NOT NULL
);

-- Table: MenuItems
CREATE TABLE MenuItems (
    ItemId INT NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    ImageBase64 NVARCHAR(MAX) NULL,
    Price DECIMAL NOT NULL,
    StallType NVARCHAR(50) NOT NULL
);

-- Table: OrderItems
CREATE TABLE OrderItems (
    OrderItemId INT NOT NULL PRIMARY KEY,
    OrderId INT NOT NULL,
    MenuItemId INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (MenuItemId) REFERENCES MenuItems(ItemId)
);

-- Table: Orders
CREATE TABLE Orders (
    OrderId INT NOT NULL PRIMARY KEY,
    Email NVARCHAR(255) NOT NULL,
    TotalAmount DECIMAL NOT NULL,
    IsCompleted BIT NOT NULL,
    QrCode NVARCHAR(MAX) NULL,
    CreatedAt DATETIME NOT NULL,
    StallId INT NOT NULL,
    FOREIGN KEY (StallId) REFERENCES Stalls(StallId)
);

-- Table: Stalls
CREATE TABLE Stalls (
    StallId INT NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Coordinates NVARCHAR(50) NULL,
    EventId INT NOT NULL,
    Floor VARCHAR(50) NULL,
    FOREIGN KEY (EventId) REFERENCES Events(EventId)
);
```

