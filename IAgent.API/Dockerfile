# 1) builder
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.sln ./
COPY IAgent.Domain/*.csproj IAgent.Domain/
COPY IAgent.Application/*.csproj IAgent.Application/
COPY IAgent.Infra/*.csproj IAgent.Infra/
COPY IAgent.API/*.csproj IAgent.API/
RUN dotnet restore
COPY . .
WORKDIR /src/IAgent.API
RUN dotnet publish -c Release -o /app/publish

# 2) runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IAgent.API.dll"]
