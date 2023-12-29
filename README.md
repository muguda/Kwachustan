# Kwachustan Tax Calculator

## Tech stack used
* .NET 8
* EntityFramework 
* AutoMapper (object mapping)
* MediatR (Command / Query handling)
* NUnit 

## Projects
* TaxCalculator - MVC, WebAPI project
* TaxCalculator.Tests - unit tests 

## SWagger Documentation
Swagger documentation is available at the following url: /swagger/index.html

## Database
The project uses EntityFramework to connect to a SQL database. The database uses a localDB and mdf file is included in the project under the `AppData` folder.

## Running locally
* Clone the repo down to your development machine
* Build and run the `TaxCalculator` project to ensure nuget packages are restored and the project builds and runs.
* The project should open in your default browser and should land on the home page of the application
* Postal codes should load on page initialization 
* Click on the `Calculate` button to view tax calculations for the selected postal code

## Running tests
* Open the `Test Explorer` window in Visual Studio
* Click on `Run All` to run all tests
* Or right click on the `TaxCalculator.Tests` project and click on `Run Tests`
* Tests can also be run from the command line using `dotnet test` from the `TaxCalculator.Tests` project folder


