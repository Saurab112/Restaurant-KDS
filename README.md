# Kitchen Display System (KDS) API

## About

The Kitchen Display System (KDS) API digitizes the order-to-kitchen workflow for restaurants, replacing manual paper tickets with a real-time digital system.

When a table order is placed, the system generates a Kitchen Order Ticket (KOT) containing the ordered items and sends it straight to the kitchen. Each order and ticket moves through a clear set of statuses — Pending, Preparing, Ready, Completed, or Cancelled — so both the order-taking staff and the kitchen always know where things stand.

The API is built with ASP.NET Core, Entity Framework Core, and MySQL, and uses SignalR to push live updates to the kitchen display the moment an order is created or a ticket's status changes — no refreshing or polling needed.

### Key Features
- Create table orders with multiple items
- Automatic generation of Kitchen Order Tickets (KOTs) per order
- Track order and ticket status: Pending → Preparing → Ready → Completed/Cancelled
- Real-time kitchen display updates via SignalR
- REST API documented with Swagger/OpenAPI

### Tech Stack
- **Backend:** ASP.NET Core (C#)
- **Database:** MySQL with Entity Framework Core
- **Real-time:** SignalR
- **API Docs:** Swagger/OpenAPI
