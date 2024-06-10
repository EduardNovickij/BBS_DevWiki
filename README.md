# BBS Development Wiki

## Description

This repository contains the practical assignment for BBS Solutions, featuring a development wiki application. The application includes functionality for creating, deleting, viewing, and searching articles with various filters.

### Key Features: 

* Web API: Allows retrieval of articles (all or by ID) from a SQL database, creation of new articles, and deletion of existing ones.
* GUI: Features search functionality by keywords (Title/Description), article type, and date, and utilizes all functionality from Web API.
* Unit Tests: Comprehensive tests for the Web API.

### Technologies Used:
* .NET Framework 4.8.1
* Entity Framework 6
* Microsoft SQL Server
* Unity (for dependency injection)
* Swagger
* Svelte 3.55
* xUnit
* Moq
* Entity Framework Effort

## Deployment Guide

### Requirements:
* .NET Framework 4.8.1
* Node.js
* Microsoft SQL Server or equivalent SQL Server Database Primary Data file

### To delpoy the developed application:
* Download the project from the repository.
#### Web API and Tests:
1. Open the project in Visual Studio and allow it to download the required packages.
2. Provide the connection string for the database in the [Web.config](https://github.com/EduardNovickij/BBS_DevWiki/blob/master/BBS_DevWiki/Web.config) file.
3. Apply database migrations using the Package Manager Console with the following command:
```
Update-Database
```
4. Run the project.
#### GUI:
1. Navigate to the [BBS_DevWiki.GUI](https://github.com/EduardNovickij/BBS_DevWiki/tree/master/BBS_DevWiki.GUI) folder and install dependencies:
```
npm install
```
2. Start the development server:
```
npm run dev
```
3. In the file [articles.js](https://github.com/EduardNovickij/BBS_DevWiki/blob/master/BBS_DevWiki.GUI/src/stores/articles.js) update the API_URL variable to the Web API URL + /api/.
4. Open [localhost:8080](http://localhost:8080) to view the running application. 
