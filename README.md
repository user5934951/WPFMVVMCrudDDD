# WPF MVVM Crud With Domain Driven Design (DDD)

This is crud example in WPF with MVVM and Domain Driven Design (DDD) using Entity Framework Code First. Dependency injection is achieved with Ninject.

## Getting Started

1. Build the project to restore nuget packages.
2. In WPFMVVMCrudDDD.Repository project change hard coded connection string in ApplicationDbContext.cs file. (this connection string is used for command Update-Database).
3. Open package manager console. In Default project drop down select WPFMVVMCrudDDD.Repository. Run Update-Database command in package manager console to create database.
4. In main project (WPFMVVMCrudDDD) change DefaultConnection string in App.config file. (this connection string is used by application).
5. Run the project.

![screenshot](https://github.com/zsharadze/WPFMVVMCrudDDD/blob/master/Capture1.PNG?raw=true)

![screenshot](https://github.com/zsharadze/WPFMVVMCrudDDD/blob/master/Capture2.PNG?raw=true)

###### About me
My name is Zviad Sharadze. I'm .Net Developer from Tbilisi, Georgia. I'm Microsoft Certified Professional.
