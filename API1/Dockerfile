FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ["TechnicalChallenge.Framework/TechnicalChallenge.Framework.csproj", "TechnicalChallenge.Framework/"]
COPY ["API1/TechnicalChallenge.API1.Core/TechnicalChallenge.API1.Core.csproj", "API1/TechnicalChallenge.API1.Core/"]
COPY ["API1/TechnicalChallenge.API1.Service/TechnicalChallenge.API1.Service.csproj", "API1/TechnicalChallenge.API1.Service/"]
COPY ["API1/TechnicalChallenge.API1/TechnicalChallenge.API1.csproj", "API1/TechnicalChallenge.API1/"]
RUN dotnet restore "API1/TechnicalChallenge.API1/TechnicalChallenge.API1.csproj"
COPY . .
WORKDIR "/src/API1/TechnicalChallenge.API1"
RUN dotnet build "TechnicalChallenge.API1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechnicalChallenge.API1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechnicalChallenge.API1.dll"]