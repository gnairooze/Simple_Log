Entity Framework Tips
=====================
These tips are for Entity Framework Code First (6.0 onwards).

General Steps
-------------
1. create the model (info class)
2. create your own DbContext class that inherit from DbContext
3. create DbSet<> property in your DbContext class. This will return the whole table
4. from Package Manager Console (Visual Studio-> View -> Other Windows -> Package Manager Console): 
5. select the project where the DbContext exist in
6. type the command: enable-migrations
7. a folder will be created called migration, and inside this folder a class created named Configuration.
8. in the Configuration class constructor, AutomaticMigrationsEnabled = true. This will create the DB if it is not exist on SQL server (if you did not change the default connection string, it will be created on localdb that accompanies visual studio). You can view it from Server Explorer or SQL Server Object Explorer in visual studio.
9. from Package Manager Console: update-database. This will modify or create the database and run the Configuration.Seed method.

Change Database from localdb to SqlServer
-----------------------------------------
1. in web.config (the configuration file related to the application), entityFramework/defaultConnectionFactory/ 
2. change the type property to be “System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework”
3. in entityFramework/defaultConnectionFactory/parameters/parameter/ 
4. change the value property to contain the connection string, for example  (Data Source=.; Initial Catalog=MyDB Integrated Security=True; MultipleActiveResultSets=True)
