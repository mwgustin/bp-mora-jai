FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 5262

ENV ASPNETCORE_URLS=http://+:5262

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
ARG configuration=Release
WORKDIR /src
COPY ["MoraJai.Web/MoraJai.Web.csproj", "MoraJai.Web/"]
RUN dotnet restore "MoraJai.Web/MoraJai.Web.csproj"
COPY . .
WORKDIR "/src/MoraJai.Web"
RUN dotnet build "MoraJai.Web.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "MoraJai.Web.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoraJai.Web.dll"]
