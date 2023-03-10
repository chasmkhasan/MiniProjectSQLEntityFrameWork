# MiniProjectSQLEntityFrameWork

This project has been work with 3 layer with Refactoring. 

UI - User Interface:
In this method has been declear menu option and user user input and welcome information

BL - Business Logices:
In this method has been decleared connect with UI and DA.

DA - Data Access Logic:
Here we have been talked with Data base and business logics.

## Classes / objects
|Object     |Description    |Comment|
|-----|--------|-------|
|App.config |Handle database connectionstring   | Need to create Separate config.app
|Menu |   Display menu   | CreatePersonFile(), CreateProjectFile(), CreateHour(), EditPerson(), EditProject(), EditHour()
|UI-User Interface |All the methods for taking input from user     |
|PostgresDataAccess |Methods for accessing data from database    |
|ConsoleMethod | Class to assign project to different Method     |

## Key features
|Feature     |Status    |
|-----|:--------:|
|Creating Person, Project and CreateHour |:white_check_mark:     |
|Assign project to person and hours | :white_check_mark:    |
|Edit hour for person to assigned projects|:white_check_mark:     |

## Creator: Welcome to visit my link:

- [MK Hasan - Github](https://github.com/chasmkhasan)
- [MK Hasan - LinkedIN](linkedin.com/in/md-kamrul-hasan-b72b1931)
- [MK Hasan - WebPage](chasmkhasan.github.io/Dynamic-CV/)

## Technologies Used
C#
{ get; set; }, data-oriented, using Npgsql, using NpgsqlTypes, using Dapper,
Postgres - DataBase

## Geting started

> To run this project, you will need to have the following Software Installed on your machine:
-.NET Core SDK
-Visual Studio or another code editor which will support C#.
> Once you have installed these dependencies, you can follow these steps to run the project:
-Clone the repository to your local machine.
-Open the project in Visual Studio Code or another code editor.
-Build and run the project.

# This will work on Entity FrameWork and will work with SQL Server near future.
