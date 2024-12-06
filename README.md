# ThreeLayerArchitectureAPI

Welcome, dear reader! Here, you'll discover a simple CRUD API project built using a robust three-layer architecture. This project leverages AutoMapper for seamless data transformation. It includes a well-structured Business Logic Layer (BLL) and Data Access Layer (DAL). For the presentation layer, you can use tools like Postman or integrate it with any front-end framework of your choice.

after clone this repository you must run following commands for DLL
add-migration initialMigration
update-database

For add product :
post => https://localhost:7022/product/addProduct
body =>  {
    "name": "test product",
    "description" : "test descruption"
}

For get all products :
get => https://localhost:7022/product/getProducts

For get product by id :
get => https://localhost:7022/product/getProduct/1

For update product by id :
put => https://localhost:7022/product/updateProduct/1
body => {
    "name": "updated name", 
}

Delete product by id :
delete => https://localhost:7022/product/deleteProduct/1
