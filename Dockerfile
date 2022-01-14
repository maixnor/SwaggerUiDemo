FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SwaggerUiDemo.Api/SwaggerUiDemo.Api.csproj", "SwaggerUiDemo.Api/"]
RUN dotnet restore "SwaggerUiDemo.Api/SwaggerUiDemo.Api.csproj"
COPY . .
WORKDIR "/src/SwaggerUiDemo.Api"
RUN dotnet build "SwaggerUiDemo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SwaggerUiDemo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SwaggerUiDemo.Api.dll"]
