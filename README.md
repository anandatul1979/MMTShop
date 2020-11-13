# MMTShop
MMTShop - Technical Test

# How to run the solution
Setup Database: Run the sql script called “MMTShop Sql Queries” in the database called “MMTShop”. This should create relevant tables, data and stored procedures.

Open Solution in Visual Studio 2019 and find “ConnectionString” in launchSettings.json file under Api and Console projects and Replace the DataSource “A01929” to your local Sql Server instance. Swagger has also been implemented to test API via browser. 

Update startup project settings to run Api and Console projects

Run the solution and follow the instructions within the console window


# Recommendations

Given more time I would consider implementation fo the following changes.

- Update ASP.Net logging mechanism to log to database, message queue or other storage
- Update data access project to use metadata rather than static strings
- Move error message strings to a resource file
- Return user friendly errors when api calls fail
- Update demo console application to return data in tabular form rather than json
- Create unit tests for demo console application
- consider adding a Mmt.Shop.Business solution if any business logic is introduced to the solution

#Note
I am using .Net standard class library as .Net Core 3.0 supports .Net standard 2.0. By continuing to target .NET Standard 2.0, I will be able to consume it in .NET Core 3.0 applications, but I'll also continue to be able to consume it in .NET Core 2.x applications, .NET Framework 4.6.1+ applications, and Xamarin apps, among others.