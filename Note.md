## Create a solution file

> dotnet new sln -o ng-core-business-project  // -o Output file location

## Create a project and link with solution

### Create a web api project

> dotnet new webapi -o ng-core-api

### Create a empty web project

> dotnet new web -o ng-core-web

### Link the csproj to the solution

> dotnet sln ng-core-business-project.sln add ng-core-api/ng-core-api.csproj

> dotnet sln ng-core-business-project.sln add ng-core-web/ng-core-web.csproj


## Create a folder to hold the service api and SQL queries for development purpose

> mkdir dev-helpers


### Add a package - Code Generation tool for ASP.NET Core

> dotnet tool install --global dotnet-aspnet-codegenerator

> dotnet build 

> dotnet aspnet-codegenerator -h // To verify whether the code generator is installed properly

### Syntax to add controller to the controller folder using aspnet code generator

> dotnet aspnet-codegenerator controller -name BandsController -actions -api -outDir Controllers

* Note: 
1. Keep the repository file in Services folder
2. Keep the Identifier with Entity Name, it will avoid confusion like 'BandID' instead of 'Id'
3. await connection.OpenAsync(); // Do this because of good pratice.
4. ControllerBase // for controller class means, it won't classes supporting views.
5. private readonly // readonly -- the value is assigned during Initialization [ possible to assign to different value ] but for constant value assigned during compile time.

### Add dapper package to the solution

> dotnet add package Dapper

> dotnet list package  // To list packages installed

### Add Automapper to assign entity with dtos.

> dotnet add package AutoMapper

> dotnet list package  // To list packages installed

### Add debugger to debug the application 

Add the launch.json and tasks.json file in the .vscode folder of Visual studio code for debugging.


## Angular Project

Note: 

1. Create a folder 'ClientApp' to reside the source of angular project. Use angular CLI to create that folder with default files.
2. Install automapper-ts using npm.
3. Install bootstrap for styling purpose.
4. Include the bootstrap in style.css -- global file location.  
5. Install @angular/http
6. npm install --save rxjs-compat
7. Add CORS exception in Startup file.

