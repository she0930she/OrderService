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

How to update database connection:
1. update in Appsetting.json in connectionStrings
2. remember update password in connectionStrings

Docker command to first upload to Container Registry: 
- **TURN OFF** dev mode
- $ docker build -t feb2024acr.azurecr.io/productapi:latest -f ./Product.API/Dockerfile . --platform linux/amd64 
- $ az login
- $ az acr login --name [myregistry.azurecr.io]
- $ turn on Azure container registry admin access
- $ docker login [myregistry.azurecr.io]
- $ docker push [myregistry].azurecr.io/[imagename]:latest