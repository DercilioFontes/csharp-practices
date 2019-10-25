FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Ch17Ex01-core/Ch17Ex01-core.csproj", "Ch17Ex01-core/"]
RUN dotnet restore "Ch17Ex01-core/Ch17Ex01-core.csproj"
COPY . .
WORKDIR "/src/Ch17Ex01-core"
RUN dotnet build "Ch17Ex01-core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ch17Ex01-core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ch17Ex01-core.dll"]