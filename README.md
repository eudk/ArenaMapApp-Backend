# Arena REST API

### **Base URL**
[API Base URL](https://hovedopgteamet-cxdwanfbevcgcwhb.northeurope-01.azurewebsites.net/)

---
[![CI/CD Pipeline](https://github.com/eudk/ArenaMapApp-Backend/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/eudk/ArenaMapApp-Backend/actions/workflows/dotnet-desktop.yml)
## **Endpoints Overview**

### **/EVENT**
- **`GET /api/event`**: Get all events.
- **`GET /api/event/{id}`**: Get event by ID.

### **/STALL**
- **`GET /api/stall`**: Get all stalls.
- **`POST /api/stall`**: Add a new stall.
- **`PUT /api/stall/{id}`**: Update an existing stall.
- **`DELETE /api/stall/{id}`**: Delete a stall.

### **/MENU**
- **`POST /api/menu/{menuItemId}`**: Add a new menu item.
- **`GET /api/menu/all`**: All
- **`GET /api/menu/type/{stallType}`**: All
- **`DELETE /api/menu/{menuItemId}`**: Delete a menu item.

### **/ORDER**
- **`GET /api/order/active`**: Get active orders.
- **`PUT /api/order/{orderId}/complete`**: Mark an order as completed.
- **`GET /api/order/{orderId}`**: Get all stalls.

### **/ADMIN**
- **`POST /api/admin/login`**: Login as an administrator.

---
