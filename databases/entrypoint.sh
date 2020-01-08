#!/bin/bash

cd /src/IdentityServer

until dotnet ef database update --no-build; do
>&2 echo "SQL Server is starting up"
sleep 1
done

cd /src/HttpApi && dotnet ef database update --no-build
