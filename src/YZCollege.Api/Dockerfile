#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/YZCollege.Api/YZCollege.Api.csproj", "src/YZCollege.Api/"]
COPY ["src/YZCollege.Infrastructure/YZCollege.Infrastructure.csproj", "src/YZCollege.Infrastructure/"]
COPY ["src/YZCollege.Domain/YZCollege.Domain.csproj", "src/YZCollege.Domain/"]
RUN dotnet restore "src/YZCollege.Api/YZCollege.Api.csproj"
COPY . .
WORKDIR "/src/src/YZCollege.Api"
RUN dotnet build "YZCollege.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YZCollege.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YZCollege.Api.dll"]