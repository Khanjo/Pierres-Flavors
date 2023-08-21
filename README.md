# _Pierre's Bakery_

#### _C# / SQL Database Authentication with Identity code review for Epicodus, 08/11/2023_

#### By _**Joshua Khan**_

## Description

_Web application that allows user to add treats and flavors and link them through a join table that limits access to create, edit and delete functionality to logged in users while allowing anyone to read_

## Setup/Installation Requirements
  
  Software Requirements:
  1. Internet browser
  2. A code editor like VSCode or Atom to view or edit the codebase.
  3. MySQL

  Setup:
  1. Click on this [link to the project repository](https://github.com/Khanjo/Factory.git) on GitHub.   
  2. Click on the "Clone or download" button to copy the project.     
  3. If you know how to use the command line and Github, clone the project with `git clone`. Use "**Download ZIP**" if not.
  4. Extract the Zip to a folder of your choice and open with a code editor (i.e. vscode)
  5. Use a SQL Manager Database such as mySQL Workbench.
  6. Create an appsettings.json file in **Your Filepath/**`Pierre` and copy/paste this code:  
     {
         "ConnectionStrings": {
             "DefaultConnection": "Server=localhost;Port=3306;database=`Name Your Database`;uid=root;pwd=`Your Password`;"
         }
     }
  7. Navigate to the Pierre directory by entering `cd` **Your Filepath/**`Pierre`. Then enter `dotnet restore`, `dotnet build`, `dotnet ef database update` then `dotnet run` into the terminal.

## Known Bugs

_No known bugs_

## Support and contact details

_https://github.com/khanjo_

## Technologies Used

* C#
* .NET-Core 2.2
* ASP.NET Core MVC
* Entity Framework Core
* MySql
* Visual Studio Code
* GitHub

### License

[MIT License.](https://opensource.org/license/mit/)

Copyright (c) 2023 **_Joshua Khan_**