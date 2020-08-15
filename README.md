# CifSQL 
Reads an ATCO standard cif file specifying Public Transport schedules, parses the data, and outputs it to an SQL Server database.

*by Ciaran Finnegan* 

## How to use
Before running the program you must enter your database connection string, as well as the filepath to your cif file, in the **App.config** file.

The connection string must go into the **connectionString** field of the "sql-server" connection string field.
The filepath must go into the **value** field of the "filePath" appSetting.

Example:
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="filePath" value="FILEPATH/GOES/HERE"/>
  </appSettings>
  <connectionStrings>
    <add name="sql-server" connectionString="DATABASE_CONNECTIONSTRING_GOES HERE"/>
  </connectionStrings>
</configuration>
```
*Note: Your connection string should specifiy a database that does not already exist, this program is used to create a new database on the SQL Server and populate it*

Once your App.config has been filled in, navigate to project directory in the CLI and simply enter the following command:
```
dotnet run
```

