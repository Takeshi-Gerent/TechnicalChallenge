FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY ["TechnicalChallenge.Framework/TechnicalChallenge.Framework.csproj", "TechnicalChallenge.Framework/"]
COPY ["API2/TechnicalChallenge.API2.Core/TechnicalChallenge.API2.Core.csproj", "API2/TechnicalChallenge.API2.Core/"]
COPY ["API2/TechnicalChallenge.API2.Service/TechnicalChallenge.API2.Service.csproj", "API2/TechnicalChallenge.API2.Service/"]
COPY ["API2/TechnicalChallenge.API2/TechnicalChallenge.API2.csproj", "API2/TechnicalChallenge.API2/"]
RUN dotnet restore "API2/TechnicalChallenge.API2/TechnicalChallenge.API2.csproj"
COPY . .
WORKDIR "/src/API2/TechnicalChallenge.API2"
RUN dotnet build "TechnicalChallenge.API2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechnicalChallenge.API2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechnicalChallenge.API2.dll"]