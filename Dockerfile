#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductMS.API/ProductMS.API.csproj", "ProductMS.API/"]
RUN dotnet restore "ProductMS.API/ProductMS.API.csproj"
COPY . .
WORKDIR "/src/ProductMS.API"
RUN dotnet build "ProductMS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductMS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMS.API.dll"]