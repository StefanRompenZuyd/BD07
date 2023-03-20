#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BD07/BD07.csproj", "BD07/"]
RUN dotnet restore "BD07/BD07.csproj"
COPY . .
WORKDIR "/src/BD07"
RUN dotnet build "BD07.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BD07.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BD07.dll"]