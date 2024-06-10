# BBS Development Wiki

## Description

Practical Assignment for BBS Solutions.

The application for development wiki was created. Application implements article creation, deletion, view and search with filters functionality.

Developed application covers the following features: 

* Web API with functionality that allows to retrieve articles (either all of them or by id) from SQL database, as well as functionality for creating new articles and deleting existing articles.
* GUI that has search functionality (by keywords for Title/Description, article type and date) and utilizes functionality developed in Web API.
* Unit tests for Web API.

Used tecnhologies: 
* .NET Framework 4.8.1
* Entity Framework 6
* Microsoft SQL Server
* Unity (for dependency injection)
* Swagger
* Svelte 3.55
* xUnit
* Moq
* Entity Framework Effort

## Software component deployment guide

### Requirements:
* .NET Framework 4.8.1
* Node.js
* Microsoft Sql Server or SQL Server Database Primary Data file or equivalent

### To delpoy the developed application:
* Download project from the repository
#### Web API and Tests:
* Allow Visual Studio to download requierd packages to run the Web API projects
* Provide Connecton String for the Database in `Web.config` file.
* Apply database migrations in Package Manager Console using command:
```
Update-Database
```
#### GUI:
* Install the dependencies for GUI by moving to the 'BBS_DevWiki.GUI' folder and running
```
npm install
```
* Start by running:
```bash
npm run dev
```
* In [BBS_DevWiki.GUI/src/stores/articles.js](https://github.com/EduardNovickij/BBS_DevWiki/blob/master/BBS_DevWiki.GUI/src/stores/articles.js) file edit a variable `API_URL` value to the Web API Url + '/api/'.
 Navigate to [localhost:8080](http://localhost:8080) to view running application. 
