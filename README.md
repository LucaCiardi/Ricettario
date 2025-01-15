# Recipe Manager

A simple ASP.NET MVC CRUD application developed during the Generation Italy Junior .NET Developer bootcamp. The project demonstrates basic database operations through a recipe management system.

## Description

This web application allows users to manage cooking recipes through a simple interface. It showcases the implementation of CRUD (Create, Read, Update, Delete) operations using a single SQL Server table.

## Features

- View all recipes
- Add new recipes
- View recipe details
- Edit recipe information inline
- Delete recipes
- Form validation
- Responsive design

## Technologies Used

- ASP.NET MVC
- SQL Server
- HTML5
- CSS3
- JavaScript
- Font Awesome

## Database Setup

```sql
CREATE TABLE Ricette (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(200) NOT NULL,
    categoria VARCHAR(50) NOT NULL,
    tipoCucina VARCHAR(100),
    tempoPreparazione INT,
    ingredienti VARCHAR(MAX) NOT NULL,
    istruzioni VARCHAR(MAX) NOT NULL,
    difficolta VARCHAR(20)
);
```

## Prerequisites

- Visual Studio 2022
- SQL Server
- .NET 6.0 or later

## Installation

1. Clone the repository
```bash
git clone [repository-url]
```

2. Create a database named 'Generation' in SQL Server

3. Execute the SQL script provided above

4. Update the connection string in `DAORicette.cs` if necessary

5. Build and run the application in Visual Studio

## Project Structure

```
RecipeManager/
├── Controllers/
│   ├── HomeController.cs
│   └── RicettaController.cs
├── Models/
│   ├── Entities/
│   │   └── Ricetta.cs
│   └── DAOs/
│       └── DAORicette.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   └── Ricetta/
│       ├── Elenco.cshtml
│       ├── Aggiungi.cshtml
│       └── Dettagli.cshtml
└── wwwroot/
    ├── css/
    │   └── ricette/
    │       └── style.css
    └── js/
        └── ricette/
            ├── validation.js
            └── edit.js
```

## Educational Context

This project was developed as part of the Generation Italy Junior .NET Developer bootcamp, focusing on:
- CRUD operations implementation
- Database management
- ASP.NET MVC architecture
- Web development best practices

## License

This project is licensed under the MIT License - see the LICENSE file for details.

---

*Developed as part of Generation Italy's Junior .NET Developer bootcamp*
