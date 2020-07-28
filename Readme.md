Download the project to your machine.
Create an empty MSSQL Database called (books)
Go to the MockData file and execute the three script in the dataBase( to populate the database with mock data)
You also can generate the Migration script with this command in your Package Management Console  (Update-Database -Script -SourceMigration:0)
Go to you Webconfig file in the project and configure the database connection.
If you want to deploy the application. You have to configure your window IIS Server
Publish your proyect( right click in your project and Publish)
After that copy the folder under the IIS file C:\inetpub\wwwroot\DeploymvcBookStore) and run your webpage
Go to your router and open a port 80 and direct the uncomming request to your local ip( you have to set your IP static so the PC always is going to have the same IP address)
Configure your firewall to allow uncomming request to por 80.
Your website should be working now in the internet.
