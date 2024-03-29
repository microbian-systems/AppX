
# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ./*.csproj ./app/
RUN dotnet restore -r linux-musl-x64

# copy everything else and build app
COPY app/. ./app/
WORKDIR /source/appx
RUN dotnet publish -c release -o /app -r linux-musl-x64 --self-contained true --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine-amd64
WORKDIR /appx
COPY --from=build /app ./

# See: https://github.com/dotnet/announcements/issues/20
# Uncomment to enable globalization APIs (or delete)
#ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false
#RUN apk add --no-cache icu-libs
#ENV LC_ALL en_US.UTF-8
#ENV LANG en_US.UTF-8
#ENV ASPNET_ENVIRONMENT Development

ENTRYPOINT ["./appx"]