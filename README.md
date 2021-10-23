# BrainWare Order List

This is a very small sample web application written in a very simplistic manner.

Grab the code and refactor it so that it meets your standard for production ready code.

There is no need to add additional functionality and you do not need to keep the existing code or project structure.

The only requirement is that it returns the list of orders and that it meets your standards!

Fork this project to your personal repo and commit all your changes to that branch. 

## Changes for Running Locally

Update the connection string in the class BrainWare\CoreWebAppMVC\appsettings.json.
Change the AttachDbFile name to the full path of the BrainWare.mdf file).


## Original Output Example
![page image](output.GIF?raw=true)


## Setup

### Database Setup
- Start SQL Server Management Studio as Administrator
- Once connected to your local SQL Server instance
- Right click on the Database node and select Attach
- Select the file BrainWare\CoreWebAppMVC\ProjectDB\MDF\BrainWare.mdf

- You can also deploy the project ProjectDB to your local SQL Server instance
- Then execute in SQL Server Management Studio the file BrainWare\CoreWebAppMVCProjectDB\PopulateDB.sql

### Visual Studio
- Open solution BrainWare\CoreWebAppMVC.sln
- Update the database connection string in file BrainWare\CoreWebAppMVC\appsettings.json
- Press F5
- Expected a browser is open with the result of the first order
