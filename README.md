# Product Management

> This project is a simple product management system built with ASP.NET CORE MVC as a front end. It allows users to create, read, update, and delete products in a database.

## Database Design

> The database design for this project is really simple and it only consists of one table "Tbl_products",
the columns of the "Tbl_Products" are 
- "ProductId" (int)(PK)
- "Name" (string)
- "Description" (string)
- "Price": (decimal)
- "CreatedAt" (Datetime)
- "UpdatedAt" (Datetime)

## Project Structure

> the project structure consists of two layers which are MVC as a presentation layer, Business Logic layer + Data access Layer(services).

Instead of using the normal MVC, I used an API to fetch the data from the front end. By doing so, the front end can be 
used different technologies such as blazor or react. Whatever the front end technology is, it can consume the API.

## Technologies Used

- ASP.NET Core MVC
- Dapper
- MSSQL server
- Notiflix
- Bootstrap
- ASP.NET Core Web API


