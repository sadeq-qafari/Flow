export ASPNETCORE_ENVIRONMENT=Production
export CONNECTION_STRING="Server=127.0.0.1;Database=FlowDb;User Id=sa;Password=FlowDb123;MultipleActiveResultSets=True"
export APP_NAME=Cdn
dotnet run Cdn.dll
