https://youtu.be/zrqCvw0uSyU?si=4EkRLY0ojJyBR4gY&t=182

![image](https://github.com/user-attachments/assets/9eeaab5d-6061-4894-9d73-7f1e8f5f80c3)
![image](https://github.com/user-attachments/assets/8fccb3bd-5600-4400-915d-4a95541aff58)


Dobrý den Danile,

děkuji za zaslání domácí úlohy v rámci výběrového řízení na pozici .NET Developer.

Doručené materiály jsme již prostudovali a bohužel pro Vás nemám dobrou zprávu. Rozhodli jsme se dál ve výběrovém řízení nepokračovat a to zejm. na základě kvality vypracování. Úkol hodnotíme i v kontextu Vašeho CV a pozice, na kterou se nám hlásíte. Berte zpětnou vazbu tak, že co firma, to jiná očekávání v rámci podobné pozice.

Konkrétní body přímo od manažera:
Readme
------
+++ famozni readme, kde snad nechybi nic zasadniho, je cele v anglictine, pekne struktorovane (do budoucna bych doporucil zvazit pripadne uvedeni literatury, pouzite architektury, vzory)


Verzovani
---------
+++ opet velmi pekna prace s gitem, kdy za tri dny pribylo pres 50 commitu s anglickou messagi v ramci nekolika branchi s postupnym zamergovanim  


Spusteni
--------
'+'  hned po naklonovani builditelne bez erroru s minimem warningu (skoda, ze tech par malych se nepodarilo zbavit)

+- primo do Swaggeru, ovsem pro vsechny profily

Reseni
------

Po naklonovani a uzreni git repa (readme, historie) jsem nabyl velkeho ocekavani. Bohuzel toto bylo zahy zastineno nevyuzitym potencialem.

Verze dotnet:
       -  ocekavana verze byla explicitne uvedena LTS (cili v soucasne dobe 8) minimalne pro runtime projekt (knihovna by byla ok s netstandardem 2)

Dokumentace:
       +- nektere public veci dokumentaci maji, jine ne (aspon u tech interface bych cekal, ze budou vsude)
       --- absolutni absence swagger input a response (jak se klienti dozvi jak spravne konzumovat, s cim pocitat atd?)

Architektura a kvalita kodu:
       +  alespon jakesi rozdeleni do vrstev (prezencni a datove)
       +  dependency injection a repository (doporucuju se podivat na navrhovy vzor mediator a cqrs)

       -  ne vsechny datove typy vhodne zvoleny (string pro url namisto Uri)
       -  hodilo by se nemit vse v Program, rozdelit neco do Startupu a nektere service registrovat v projektu, ktery se jich tyka
       -  vsechny profily do dev env (jine prostredi vlastne ani neni)
       -  po pridani jineho env by byl povolen swagger i tam (neni ciste pro dev), takze by doslo k vystaveni i na produkci
       -  try/catch pattern
       -  logovani by slo udelat obecneji + doporucuju templaty
       --- prezentacni vrstva pristupuje naprimo do datove vrsty a vystavuje db model ven
       --- cele api je blokujici, neni asynchronni, od chybejicich async Tasku/cancellation tokenu endpointu az po EF, ktere to umoznuje

Prezentacni vrstva:
       +  obsahuje verze

       -  bylo by lepsi rozdelit si verze controlleru do separatnich souboru/trid
       -  pro castecny update je lepsi pouzit HTTP PATCH nez PUT
       -  v route pro PUT je pouzity description jako resource, coz uplne neodpovida RESTFul (a doporucuju se podivat napriklad na json patch)
       -  obsahuje servisni logiku
       
Servisni vrstva:
       --- chybi a nemela by

Datova vrstva:
       +  genericke repo

       +- genericke repo je fajn, ale samotny db context je abstrakci a navic nevydim uplne vyuziti, kdy se pak dbset stejne dodava rucne

       -  obsahuje servisni logiku
Testy:
       +- vypada jako AAA, ale chtelo by dotahnout
       +- pokus o integracni testy navic, ktere ale uplne nejsou integracni v pravem slova smyslu

       -  nejedna se vlastne o unit test, protoze testuje celou cestu vcetne controlleru (coz vychazi z toho, ze chybi servisni vrstva)


Bonusy, ktere nejsou, ale pripadne bych mimo zminene a jine priste zvazil: Docker, houldly, OneOf, misto == null vyuzivat is null kvuli overridovani operatoru a bezpecnosti.

Moc nás to mrzí, ale určitě si Vás rádi necháme ponecháme v databázi talentů a v případě, že se nám otevře obdobná pozice, rádi se Vám ozveme.

Přeji hezký víkend,



---
![image](https://github.com/user-attachments/assets/f8287d2f-952a-4f9f-a77a-9c1badce8156)
### **[AlzaProduct Web API Application](https://alzaproduct.hepatico.ru/swagger/index.html?urls.primaryName=Alza%20Product%20-%201.0)**

## **Overview**
This Web API application provides a RESTful service for managing products of an eshop, including endpoints to retrieve product listings, retrieve products by ID, and update product descriptions. The API supports multiple versions, pagination, and Swagger documentation for better visibility.

The application is hosted on **Kamatera**, with connection to Cloudflare ensuring robust protection against DDoS attacks and enhanced performance through their global content delivery network (CDN). Additionally, **GitHub Actions** and **Docker** were used to automate the deployment process, ensuring efficient and consistent delivery of the application to the web.

### **Key Features**
- **Product Listing**: Retrieve a list of all available products.
- **Pagination**: Version 2.0 of the product list supports pagination for efficient data retrieval.
- **Product Retrieval**: Retrieve a single product by its unique ID.
- **Update Product Description**: Allows updating the description of a specific product.
- **Error Handling**: All endpoints return meaningful error messages in case of failures.
- **DDoS Protection**: Cloudflare shields the application from distributed denial of service (DDoS) attacks.
- **Continuous Integration/Continuous Deployment**: GitHub Actions and Docker were used to streamline and automate the deployment process.

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
  }
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
[
  {
    "id": 54,
    "name": "Smartphone X",
    "imgUri": "img_smartphone_x.jpg",
    "price": 999.99,
    "description": "Latest smartphone with advanced features"
  },
  {
    "id": 55,
    "name": "Laptop Pro",
    "imgUri": "img_laptop_pro.jpg",
    "price": 1499.99,
    "description": "High-performance laptop for professionals"
  }
]
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
  - **Framework**: .NET Core 
  - **Language**: C#
  - **Logging**: Built-in ASP.NET Core logging infrastructure
  - **Database**: MS SQL
  - **ORM**: Entity Framework (EF)
  - **Cloudflare Protection**: DDoS attack mitigation and application security
  - **GitHub Actions**: Automated CI/CD pipelines
  - **Docker**: Containerized deployments for consistent environment replication

---

## **How to Run the Application**

1. Clone the repository from GitHub.
2. Create a database locally and update it for the latest changes -> 'Update-Database' in Package Manager Console 
3. Run the project in your preferred IDE (Visual Studio/VS Code).
4. Access the Swagger documentation at `http://localhost:{port}/swagger` to explore the API endpoints.

---

## **Unit Tests**

The repository includes unit tests to validate the functionality of each endpoint. Run the tests using Visual Studio Test Explorer or CLI (`dotnet test`).

---

## **Integration Tests**

To run integration tests locally, insert your test database connection string in `appsettings.json` or the test setup. Example:

```json
  "TEST_DATABASE_CONNECTION_STRING": "Server=your_test_db_server;Database=AlzaProductTestDb;User Id=your_user;Password=your_password;"
```
You can download the test database from the following link: [Test Database](https://drive.google.com/file/d/11OtqkUKqkGN-mXizdtXMrZLEAy4mHhMo/view?usp=sharing)

---

The application is live and accessible here:  
[**AlzaProduct API Swagger**](https://alzaproduct.hepatico.ru/swagger/index.html?urls.primaryName=Alza%20Product%20-%201.0)
