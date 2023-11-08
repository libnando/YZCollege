#Migrations

- dotnet tool install --global dotnet-ef

- dotnet ef migrations add NOME_SEU_MIGRATION -s .\src\YZCollege.Api\YZCollege.Api.csproj --project .\src\YZCollege.Infrastructure\YZCollege.Infrastructure.csproj

- dotnet ef database update -s .\src\YZCollege.Api\YZCollege.Api.csproj --project .\src\YZCollege.Infrastructure\YZCollege.Infrastructure.csproj
