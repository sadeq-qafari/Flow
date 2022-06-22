cd ..\tenant-service
dotnet run
SET ASPNETCORE_ENVIRONMENT=Production&& SET CONNECTION_STRING=Server=127.0.0.1;Database=FlowDb;User Id=sa;Password=123&& SET APP_NAME=Tenant&& Saanaa.Tenant.dll
