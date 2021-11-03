### You should run commands from root TTNs directory.

Add migration command:

`dotnet ef migrations add MigrationName --project DataAccess.EFCore --startup-project API`

Update database command:

`dotnet ef database update --project DataAccess.EFCore --startup-project API`

Project has written without Fluent Validation and client-side DTO's.

In launch settings we should have `ConnectionsStrings:DBConnection` property, but it is loaded from user secrets.

By default, you have: `http://localhost:5000` address for host, but you can rewrite it using in `launchSettings.json`.