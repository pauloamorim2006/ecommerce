#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["./ECommerce.Api/ECommerce.Api.csproj", "src/ECommerce.Api/"]
COPY ["./ECommerce.Infra/ECommerce.Infra.csproj", "src/ECommerce.Infra/"]
COPY ["./ECommerce.Domain/ECommerce.Domain.csproj", "src/ECommerce.Domain/"]
COPY ["./ECommerce.Core/ECommerce.Core.csproj", "src/ECommerce.Core/"]
COPY ["./ECommerce.Application/ECommerce.Application.csproj", "src/ECommerce.Application/"]
RUN dotnet restore "src/ECommerce.Api/ECommerce.Api.csproj"
COPY . .
WORKDIR "/src/ECommerce.Api"
RUN dotnet build "ECommerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.dll"]