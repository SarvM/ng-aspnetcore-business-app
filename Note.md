## Create a solution file

dotnet new sln -o ng-core-business-project  // -o Output file location

## Create a project and link with solution

### Create a web api project

dotnet new webapi -o ng-core-api

### Create a empty web project

dotnet new web -o ng-core-web

### Link the csproj to the solution

dotnet sln ng-core-business-project.sln add ng-core-api/ng-core-api.csproj

dotnet sln ng-core-business-project.sln add ng-core-web/ng-core-web.csproj


## Create a folder to hold the service api and SQL queries for development purpose

mkdir dev-helpers


## Add a package - Code Generation tool for ASP.NET Core

dotnet tool install --global dotnet-aspnet-codegenerator

dotnet build 
