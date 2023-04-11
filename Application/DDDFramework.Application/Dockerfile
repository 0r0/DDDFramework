FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DDDFramework/Application/DDDFramework.Application/DDDFramework.Application.csproj", "DDDFramework.Application/"]
RUN dotnet restore "Application/DDDFramework.Application/DDDFramework.Application.csproj"
COPY . .
WORKDIR "/src/DDDFramework.Application"
RUN dotnet build "DDDFramework.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DDDFramework.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDDFramework.Application.dll"]
