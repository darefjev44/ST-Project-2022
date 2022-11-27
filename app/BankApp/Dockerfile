FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN 
COPY ["BankApp.csproj", "."]
RUN dotnet restore "./BankApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BankApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankApp.dll"]