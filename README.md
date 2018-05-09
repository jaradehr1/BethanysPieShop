# Bethany's pie shop
ASP.NET Core 2.0 MVC Application with Visual Studio 2017

# What does this application do?
This application was created for learning purposes. The application starts by showing a list of some pies that Bethany is offering on her site. You can click on one of the pies and then see the details of that particular pie. You can also click on the Feedback button here to send some feedback to Bethany. However, before sending feedback, you need to either register or log in. The application uses ASP.NET Helper Tags and ASP.NET Core Identity.

# To run the application, follow the steps

1. Rebuild your project 
2. Go to Tools -> NuGet Package Manager -> Package Manager Console
3. run the command **PM> update-database** 

# To make sure that the database was created

1. Go to View, click *SQL Server Object Explorer*
2. Under *SQL Server*, find your local database **BethanyDemo123**
3. Check if the tables are created