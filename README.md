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
# Tools & Libraries Used

---

### **Leaflet.js**
- **Description:** Used for creating interactive maps to display stalls and event locations. Provides a responsive and visually appealing map interface.

<p align="center">
  <img src="https://leafletjs.com/docs/images/logo.png" alt="Leaflet Logo" width="100">
</p>

---

### **EmailJS**
- **Description:** Enables order confirmation emails with details and QR codes. Seamless integration with the frontend for email delivery.

<p align="center">
  <img src="https://media2.dev.to/dynamic/image/width=500,height=210,fit=cover,gravity=auto,format=auto/https%3A%2F%2Fdev-to-uploads.s3.amazonaws.com%2Fuploads%2Farticles%2F5d14su1hfqzbeqa2qhbr.png" alt="EmailJS Logo" width="150">
</p>

---

### **QRCode.js**
- **Description:** Generates dynamic QR codes tied to orders. Simple and lightweight, perfect for frontend use cases.

<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/QR_code_for_mobile_English_Wikipedia.svg/600px-QR_code_for_mobile_English_Wikipedia.svg.png" alt="QR Code Logo" width="100">
</p>

---

### **Vue.js**
- **Description:** Framework for building the frontend user interface.
- Features: Data bindings and reactive UI for smooth interactions.
- **[Link](https://vuejs.org/)**

---

### **Axios**
- **Description:** Handles API calls for fetching, posting, and deleting data.
- Simplifies integration with the backend REST API.
- **[Link](https://axios-http.com/)**

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
