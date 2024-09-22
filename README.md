---

# **AlzaProduct Web API Application Documentation**

## **Overview**
This Web API application provides a RESTful service for managing products of an eshop, including endpoints to retrieve product listings, retrieve products by ID, and update product descriptions. The API supports multiple versions, pagination, and Swagger documentation for better visibility.

### **Key Features**
- **Product Listing**: Retrieve a list of all available products.
- **Pagination**: Version 2.0 of the product list supports pagination for efficient data retrieval.
- **Product Retrieval**: Retrieve a single product by its unique ID.
- **Update Product Description**: Allows updating the description of a specific product.
- **Error Handling**: All endpoints return meaningful error messages in case of failures.

---

## **API Endpoints**

### **Base URL**  
```
/api/v{version}/products
```

### **1. Get All Products (Version 1.0)**  
**GET** `/api/v1/products`

Retrieves the complete list of available products.

- **Response**:  
  - **200 OK**: Returns a list of products in JSON format.
  - **500 Internal Server Error**: Returns if there's an error while retrieving the list of products.

Example Response:
```json
[
  {
    "id": 1,
    "name": "Product Name",
    "imgUri": "https://example.com/image.png",
    "price": 10.00,
    "description": "Product description."
  },
  ...
]
```

### **2. Get All Products with Pagination (Version 2.0)**  
**GET** `/api/v2/products`

Supports pagination, allowing users to request a subset of the product list.

- **Query Parameters**:
  - `pageNumber`: The page number to retrieve (default: 1).
  - `pageSize`: Number of items per page (default: 10).
  
- **Response**:  
  - **200 OK**: Returns a paginated list of products.
  - **400 Bad Request**: If `pageNumber` or `pageSize` is invalid (less than or equal to 0).
  - **500 Internal Server Error**: Returns if there's an error while retrieving the list of products.

Example Response:
```json
{
  "pageNumber": 1,
  "pageSize": 10,
  "products": [
    {
      "id": 1,
      "name": "Product Name",
      "imgUri": "https://example.com/image.png",
      "price": 10.00,
      "description": "Product description."
    },
    ...
  ]
}
```

### **3. Get Product by ID (Version 1.0)**  
**GET** `/api/v1/products/{id}`

Retrieves a single product by its unique ID.

- **Path Parameters**:
  - `id`: The unique identifier of the product.

- **Response**:  
  - **200 OK**: Returns the product data in JSON format.
  - **500 Internal Server Error**: Returns if there's an error while retrieving the product.

Example Response:
```json
{
  "id": 1,
  "name": "Product Name",
  "imgUri": "https://example.com/image.png",
  "price": 10.00,
  "description": "Product description."
}
```

### **4. Update Product Description (Version 1.0)**  
**PUT** `/api/v1/products/{id}/description`

Updates the description of a specific product.

- **Path Parameters**:
  - `id`: The unique identifier of the product.

- **Body**:
  - **string**: The new description for the product.

- **Response**:  
  - **200 OK**: If the description was successfully updated.
  - **500 Internal Server Error**: Returns if there's an error while updating the product description.

Example Request Body:
```json
{
  "description": "New product description."
}
```

Example Response:
```json
{
  "message": "The product description was successfully updated."
}
```

---

## **Data Model**

### **Product Model**  
The API deals with products having the following attributes:

- **Id** (required): Unique identifier for the product.
- **Name** (required): The name of the product.
- **ImgUri** (required): The URI for the product image.
- **Price** (required, decimal): The price of the product.
- **Description** (optional): A textual description of the product.

---

## **Error Handling**
Each endpoint returns descriptive error messages. Common errors include:

- **400 Bad Request**: Invalid input parameters, such as page size or number.
- **500 Internal Server Error**: Unexpected errors during the processing of requests.

---

## **Development Specifications**

- **Technology Stack**:
  - **Framework**: .NET Core (latest LTS version)
  - **Language**: C#
  - **Logging**: Built-in ASP.NET Core logging infrastructure

---

## **How to Run the Application**

1. Clone the repository from GitHub.
2. Restore NuGet packages using Visual Studio or CLI (`dotnet restore`).
3. Run the project in your preferred IDE (Visual Studio/VS Code).
4. Access the Swagger documentation at `http://localhost:{port}/swagger` to explore the API endpoints.

---

## **Unit Tests**

The repository includes unit tests to validate the functionality of each endpoint. Run the tests using Visual Studio Test Explorer or CLI (`dotnet test`).

---

This concludes the basic documentation for the AlzaProduct API. If you need more details, consult the Swagger documentation generated during runtime.