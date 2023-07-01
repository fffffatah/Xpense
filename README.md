# Xpense
Xpense is a simple expense tracker web application for experimenting with .NET.

# Purpose
To learn and experiment with,
- testing (SpecFlow).
- Unit of Work pattern (To-Do).
- caching in .NET (To-Do).

# Getting Started
The project targets `.NET 6` and is `ASP.NET Core MVC` project. The application uses `MS SQL Server 2019` as database. Therefore, make sure you have the system ready before running the application. Also, separate SQL script isn't required as the database and required tables will be created on first run. Additionally, make sure you have the proper connection string set for database in `appsettings.json` or Environment Variable under `SQL_SERVER_CONNECTION`.

# How To Use
Upon running the application, you will be welcomed with the page below. Use above navigation bar to navigate to your desired option of the application.
![1](https://github.com/fffffatah/Xpense/blob/master/Docs/1.png)

Category: When you click on `Category`, you will see a table containing all the categories that you have created.
![2](https://github.com/fffffatah/Xpense/blob/master/Docs/2.png)

To create a category, click on `Add New` button and you will be taken to page where you can add a new category. You won't be able to create multiple categories.
![3](https://github.com/fffffatah/Xpense/blob/master/Docs/3.png)

To edit a category, click on `Edit` button alongside the category details. Later you will be taken to a page where you can edit the Category.
![4](https://github.com/fffffatah/Xpense/blob/master/Docs/4.png)

To delete a category, simply click on the `Delete` button.

Expense: When you click on `Expense`, you will see a table containing all the expenses that you have created.
![5](https://github.com/fffffatah/Xpense/blob/master/Docs/5.png)

To create an expense, click on `Add New` button and you will be taken to page where you can add a new expense.
![6](https://github.com/fffffatah/Xpense/blob/master/Docs/6.png)

To edit an expense, click on `Edit` button alongside the expense details. Later you will be taken to a page where you can edit the expense.
![7](https://github.com/fffffatah/Xpense/blob/master/Docs/7.png)

In expense date filter, you can filter expenses recorded between a given date.
![8](https://github.com/fffffatah/Xpense/blob/master/Docs/8.png)
