[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/qJo95Bxr)
# CSCI 1260 — Project

## Project Instructions
All project requirements, grading criteria, and submission details are provided on **D2L**.  
Refer to D2L as the *authoritative source* for this assignment.

This repository is intentionally minimal. You are responsible for:
- Creating the solution and projects
- Designing the class structure
- Implementing the required functionality

---

## Getting Started (CLI)

You may use **Visual Studio**, **VS Code**, or the **terminal**.

### Create a solution
```bash
dotnet new sln -n ProjectName
```

### Create a project (example: console app)
```bash
dotnet new console -n ProjectName.App
```

### Add the project to the solution
```bash
dotnet sln add ProjectName.App
```

### Build and run
```bash
dotnet build
dotnet run --project ProjectName.App
```

## Notes
- Commit early and commit often.
- Your repository history is part of your submission.
- Update this README with build/run instructions specific to your project.





ToDoList App
A simple web-based To Do List application built with Blazor Server and .NET 8.

Tech Stack

Framework: ASP.NET Core 8 with Blazor Server 
Language: C#
Data Storage: JSON file (tasks.json) written to the application's output directory
Testing: xUnit


How to Build and Run
Prerequisites

.NET 8 SDK
Visual Studio 2022 or later

Steps

Clone the repository
git clone 

Navigate to the app project
cd ToDoList.App.csproj

Run the application:
dotnet run

Open your browser and go to
http://localhost:5000

How to Run the Unit Tests

Navigate to the test project
cd ToDoList.Tests

Run all tests
dotnet test

Key Features

Add a task by typing in the input box and clicking Add Task
Delete any task by clicking the Delete button next to it
Tasks are automatically saved and reloaded when the app restarts


Data Storage
Tasks are stored in a file called tasks.json located in the application's output directory:

The file uses a Dictionary<Guid, TodoItem>. Each task has a unique Guid ID, a Description, and an IsComplete flag.

UML Diagram
The UML diagram file is included in the repository.
It covers:

The TodoItem model class and its properties
The TodoManager class and its methods (Add, Remove, Complete, GetAll, GetDictionary)
The FileService class and its methods (Save, Load)
The relationships between TodoManager, FileService, and TodoItem
The Index.razor page and its dependency on TodoManager and FileService through injection


Submission Note
This project was completed as Project 4 for CSCI-1260, submitted via GitHub Classroom.
(https://github.com/etsucs-scott/project-4-whitele3)

External Resources and Citations

Blazor Server documentation  Microsoft
xUnit documentation
System.Text.Json documentation  Microsoft
ASP.NET Core dependency injection  Microsoft