FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .

WORKDIR /src/micro/modules/base/host/Base.IdentityServer
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build --no-restore -c Release

WORKDIR /src/micro/modules/base/host/Base.HttpApi.Host
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build --no-restore -c Release

FROM build AS final
WORKDIR /src
COPY --from=build /src/micro/modules/base/host/Base.IdentityServer ./IdentityServer
COPY --from=build /src/micro/modules/base/host/Base.HttpApi.Host ./HttpApi
COPY --from=build /src/micro/databases/entrypoint.sh .
RUN /bin/bash -c "sed -i $'s/\r$//' entrypoint.sh"
RUN chmod +x ./entrypoint.sh

ENTRYPOINT ["./entrypoint.sh"]
