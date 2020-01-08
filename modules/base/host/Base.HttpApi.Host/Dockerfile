FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
WORKDIR /src/micro/modules/base/host/Base.HttpApi.Host
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Base.HttpApi.Host.dll"]
