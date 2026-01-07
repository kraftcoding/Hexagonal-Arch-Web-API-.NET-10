# Migrations

To crete migrations for the Persistence project, use the following command:
```
Add-Migration -Name InitialCreate -Project NetCoreHexagonal.Persistence -StartupProject NetCoreHexagonal.Persistence
```

To apply the migrations to the database, use the following command:
```
update-database -StartupProject NetCoreHexagonal.Persistence
```
