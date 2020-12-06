# Virtual College Context

VirtualCollegeContext is a school management system. This application can register and manage courses, students and faculty members across the branches. All the data is stored in a SQL Database (Cf. SQL Connection below)

## UML Diagram
Here you can find the UML Diagram to this application :
![](DorsetOOP/UML%20Diagram%20VirtualCollegeContext.jpeg)

## SQL Connection

Normally, everything should run perfectly as soon as you build the project. The SQL Server is hosted on a dedicated server, at Rémi Lombard's home.

/!\ If there happens to be a connection issue either side (wether it be your connection or ours) or if you want to speed things up, please follow the instructions bellow: /!\

- Open SSMS on your computer. On one of your local servers, create a new database and name it "VirtualCollege" (case sensitive).
- Open up "DBSchemaAndData.sql", which can be found in the folder containing the DorsetOOP.csproj file. 
- Execute the script (make sure you're running it from the database you just created). You've juste made an exact copy of our database (schema and data).
- Now, you need to edit the connection string in the ~/App.config file. You can follow the instructions there. 
- You'll need to replace the connection string. Typically, it will become the following (may vary depending on your SQL Server name).

```bash
  <connectionStrings>
    <add name="VirtualCollege" providerName="System.data.SqlClient"
      connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=VirtualCollege;Integrated Security=True;"/>
  </connectionStrings>
```
Rerun the code and everything should be fine!

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
