FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["RestWithAspNetCoreCorrect/RestWithAspNetCoreCorrect.csproj", "RestWithAspNetCoreCorrect/"]
RUN dotnet restore "RestWithAspNetCoreCorrect/RestWithAspNetCoreCorrect.csproj"
COPY . .
WORKDIR "/src/RestWithAspNetCoreCorrect"
RUN dotnet build "RestWithAspNetCoreCorrect.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RestWithAspNetCoreCorrect.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RestWithAspNetCoreCorrect.dll"]