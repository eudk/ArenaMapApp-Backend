# Arena REST API

### **Base URL**
[API Base URL](https://hovedopgteamet-cxdwanfbevcgcwhb.northeurope-01.azurewebsites.net/)

---

## **Endpoints Overview**

### **/EVENT**
- **`GET /api/event`**: Get all events.
- **`GET /api/event/{id}`**: Get event by ID.

### **/STALL**
- **`GET /api/stall`**: Get all stalls.
- **`POST /api/stall`**: Add a new stall.
- **`PUT /api/stall/{id}`**: Update an existing stall.
- **`DELETE /api/stall/{id}`**: Delete a stall.

### **/QR**
- **`POST /api/qr`**: Generate QR code for an order.
- **`GET /api/qr/{orderId}`**: Get QR code by order ID.

### **/MENU**
- **`GET /api/menu/{eventId}`**: Get menu items for an event.
- **`POST /api/menu/{eventId}`**: Add a new menu item.
- **`DELETE /api/menu/{menuItemId}`**: Delete a menu item.

### **/ORDER**
- **`GET /api/order/active`**: Get active orders.
- **`PUT /api/order/{orderId}/complete`**: Mark an order as completed.

### **/ADMIN**
- **`POST /api/admin/login`**: Login as an administrator.

---
