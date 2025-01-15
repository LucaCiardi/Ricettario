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
text

## Project Structure
Ricettario/
├── Controllers/
│ ├── HomeController.cs
│ └── RicettaController.cs
├── Models/
│ └── Ricetta.cs
├── Data/
│ └── RicettarioContext.cs
├── Views/
│ ├── Home/
│ │ └── Index.cshtml
│ ├── Ricetta/
│ │ ├── Elenco.cshtml
│ │ ├── Aggiungi.cshtml
│ │ └── Dettagli.cshtml
│ └── Shared/
│ └── _Layout.cshtml
└── wwwroot/
├── css/
│ └── ricette/
│ └── style.css
└── js/
└── ricette/
├── validation.js
└── edit.js
text

## Setup
1. Clone the repository
2. Update connection string in appsettings.json
3. Run Entity Framework migrations
4. Build and run the application

## Requirements
- Visual Studio 2022
- .NET 7.0 or later
- SQL Server
