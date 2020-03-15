# ProductManagementSystem


### Description:
----------------
This is a simple back-end for an online marketplace.

Here is a sample of some of the products available on the site:
| Product code  | Name  |  Price |
|---|---|---|
|  001 |  Lavender heart | £9.25  |
|  002 |  Personalised cufflinks | £45.00  |
|  003 |  Kids T-shirt | £19.95 |

A RESTful API to implement CRUD operations on this data. The five endpoints:
* GET /products - A list of products, names, and prices in JSON.
* POST /product - Create a new product using posted form data.
* GET /product/{product_id} - Return a single product in JSON format.
* PUT /product/{product_id} - Update a product's name or price by id.
* DELETE /product/{product_id} - Delete a product by id.

The service is implemented using .Net Core.
Swagger is used to define and allow interaction with the API.
There are sensible return values for both successful and unsuccessful requests (e.g. the server should report a code such as 404 for an unknown product ID and not error out).
The database is an Sql Server database. Entity Framework Core code first is used as an ORM.

The database creation and seed scripts can be found in the Database folder. The application can be run from Visual Studio with the swagger UI or deployed to IIS (swagger is only set for debug mode).
If tested using Postman, please make sure that the POST and PUT endpoints receive JSON data from the raw view of Postman as the application can't handle the multipart/related data sent using the form-data view of Postman.
Please also make sure to check and change the connection string in the application's configuration file so that the database connection could be made.


### Used languages:
------------------
- C# .Net core
- SQL
- JSON


### Features:
------------
- Swagger
- Entity Framework Core
- REST API
- Data-driven architecture


### Enviroment:
--------------
- IDE: Microsoft Visual Studio 2019 Community with .Net Core 3.1
- Database: Microsoft Sql Server 2016 Express
- OS: Microsoft Windows 10 Ultimate, 64 bit
- Test: Google Chrome (latest) & Postman (latest)