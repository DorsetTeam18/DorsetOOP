# Virtual College Context

VirtualCollegeContext is a school management system. This application can register and manage courses, students and faculty members across the branches. All the data are stored in a SQL Database.
## SQL Connection

To connect to the SQL Database, you must change the connection string from the ~/App.config file.

```bash
  <connectionStrings>
    <add name="VirtualCollege" providerName="System.data.SqlClient"
      connectionString="Data Source=84.102.235.128,1433;Network Library=DBMSSOCN;Initial Catalog=VirtualCollege;User ID=AppLogin;Password=Password123;"/>
  </connectionStrings>
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
