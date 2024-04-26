This is the design for **Microservices Pattern**
  - Backend:
    - OrderService: c# .Net Core
    - CustomerEShop: c# .Net Core
  - Frontend:
    - eShopFrontEndSPA: Angular 16 


**OrderServie** provides: 
 1. products display API call
 1. shoppingCart order placement API call

**Technology** I used:
 - connect with Azure SQL database (MS SQL Server)
 - use Azure Container Registry for docker container management
 - deployed on Azure Container App from the repository in Container Registry
