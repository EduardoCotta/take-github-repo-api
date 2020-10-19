#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TakeGithubAPI.csproj", "src/"]
RUN dotnet restore "src/TakeGithubAPI.csproj"
COPY . .
WORKDIR "/src/src"
RUN dotnet build "TakeGithubAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TakeGithubAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TakeGithubAPI.dll"]
ENV ASPNETCORE_URLS=http://*:8080
ENV GITHUB-API-REPOS-BASE-URL=http://api.github.com/users/ORGANIZATION_NAME/repos?per_page=100
ENV GithubPersonalToken=423d9b446275c9d8787ac9a65ea7343a7582c3d7