# Ricettario Web

A modern ASP.NET Core MVC recipe management application developed during the Generation Italy Junior .NET Developer bootcamp. The project implements a complete CRUD system with real-time editing and category filtering.

## Features
- View and filter recipes by category
- Add new recipes with form validation
- View detailed recipe information
- Real-time inline editing of recipe details
- Delete recipes with confirmation
- Responsive design with modern UI

## Technologies
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- JavaScript (ES6+)
- CSS3 with modern features
- Font Awesome icons

## Database Structure
```sql
CREATE TABLE Ricette (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(200) NOT NULL,
    Categoria VARCHAR(50) NOT NULL,
    TipoCucina VARCHAR(100),
    TempoPreparazione INT,
    Ingredienti VARCHAR(MAX) NOT NULL,
    Istruzioni VARCHAR(MAX) NOT NULL,
    Difficolta VARCHAR(20)
);
```

## Project Structure
```
Ricettario/
├── Controllers/
│   ├── HomeController.cs
│   └── RicettaController.cs
├── Models/
│   └── Ricetta.cs
├── Data/
│   └── RicettarioContext.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Ricetta/
│   │   ├── Elenco.cshtml
│   │   ├── Aggiungi.cshtml
│   │   └── Dettagli.cshtml
│   └── Shared/
│       └── _Layout.cshtml
└── wwwroot/
    ├── css/
    │   └── ricette/
    │       └── style.css
    └── js/
        └── ricette/
            ├── validation.js
            └── edit.js
```

## Features Implementation
- **Category Filtering**: Real-time filtering of recipes by category
- **Inline Editing**: Direct modification of recipe details without page reload
- **Form Validation**: Client and server-side validation for data integrity
- **Responsive Design**: Mobile-friendly interface with modern styling
- **CRUD Operations**: Complete Create, Read, Update, Delete functionality

## Setup Requirements
- Visual Studio 2022
- .NET 7.0 or later
- SQL Server
- Entity Framework Core tools

## Installation Steps
1. Clone the repository
2. Update the connection string in appsettings.json
3. Run Entity Framework migrations:
   ```
   Add-Migration InitialCreate
   Update-Database
   ```
4. Build and run the application

## Educational Context
This project was developed as part of the Generation Italy Junior .NET Developer bootcamp, focusing on:
- ASP.NET Core MVC architecture
- Entity Framework Core implementation
- Modern JavaScript practices
- Responsive web design
- Best practices in web development

## License
This project is licensed under the MIT License - see the LICENSE file for details.

Developed as part of Generation Italy's Junior .NET Developer bootcamp.

Citations:
[1] https://pplx-res.cloudinary.com/image/upload/v1736959606/user_uploads/KrRScobpkkxcnEY/image.jpg
[2] https://pplx-res.cloudinary.com/image/upload/v1736960620/user_uploads/QeMabBjGVAxamoE/image.jpg
