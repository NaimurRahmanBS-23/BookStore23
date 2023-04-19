# BookStore23 
This repository contains the **BookStore23** source code. 
BookStore23 is a web application based on **Asp.Net-core**.
Where one can see all the books available in the store and see the details of the book and author.

# Introduction
**This is simple BookStore webapplication where one :**

+ Can see all the books available in the store
+ Add new book to the store 
+ Delete a book from store
+ Update a book information 
+ Update book cover picture
+ Delete an Author
+ Update an Author details
+ update author picture

# Documentation to run this project locally.

**This app is based on asp.net core (MVC)  ,and needs sql sever to run.**

+ Open the souce code with Visual Studio (Recommend to use 2022 or higher).
+ Create a database  named BookStore in sql server
+ Install these  NuGet Package
  + Microsoft.EntityFrameworkCore
  + Microsoft.EntityFrameworkCore.SqlServer
  + Microsoft.EntityFrameworkCore.Tools
  + Microsoft.VisualStudio.Web.CodeGeneration.Design

+ To Create data table :
  + Go to the Nuget Package console
  + Type add-migrate "migration Name without quota" and hit enter
  + type update-database and hit enter
 
 This will create all needed database table for this application

Now you can click the run button and application will run a port specified in the LauchSetting.json file.

# Issue
This repository is maintained actively,so if you face any issue please [raise an issue](https://github.com/NaimurRahmanBS-23/BookStore23/issues).

# **Liked the work ?**

Give the repository a star:-)
