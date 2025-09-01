# 1) build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# copie la solution
COPY IAgent.sln ./

# copie tous les projets référencés par la solution
COPY IAgent.API/*.csproj IAgent.API/
COPY IAgent.Application/*.csproj IAgent.Application/
COPY IAgent.Domain/*.csproj IAgent.Domain/
COPY IAgent.Infra/*.csproj IAgent.Infra/
COPY IAgent.Tests/*.csproj IAgent.Tests/
COPY Billing.API/*.csproj Billing.API/
COPY Billing.Application/*.csproj Billing.Application/
COPY Billing.Domain/*.csproj Billing.Domain/
COPY Billing.Infra/*.csproj Billing.Infra/

# restore
RUN dotnet restore IAgent.sln

# copie le reste du code
COPY . .

# build + publish l’API Agent
WORKDIR /app/IAgent.API
RUN dotnet publish -c Release -o /out

# 2) runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "IAgent.API.dll"]
