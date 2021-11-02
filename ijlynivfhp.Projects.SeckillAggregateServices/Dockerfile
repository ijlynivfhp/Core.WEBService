#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ijlynivfhp.Projects.SeckillAggregateServices/ijlynivfhp.Projects.SeckillAggregateServices.csproj", "ijlynivfhp.Projects.SeckillAggregateServices/"]
COPY ["ijlynivfhp.Projects.Cores/ijlynivfhp.Projects.Cores.csproj", "ijlynivfhp.Projects.Cores/"]
COPY ["ijlynivfhp.Projects.Commons/ijlynivfhp.Projects.Commons.csproj", "ijlynivfhp.Projects.Commons/"]
COPY ["ijlynivfhp.Projects.SeckillAggregateServices/SeckillLua.lua", "/app/Luas/"]
COPY ["ijlynivfhp.Projects.SeckillAggregateServices/SeckillLuaCallback.lua", "/app/Luas/"]
RUN dotnet restore "ijlynivfhp.Projects.SeckillAggregateServices/ijlynivfhp.Projects.SeckillAggregateServices.csproj"
COPY . .
WORKDIR "/src/ijlynivfhp.Projects.SeckillAggregateServices"
RUN dotnet build "ijlynivfhp.Projects.SeckillAggregateServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ijlynivfhp.Projects.SeckillAggregateServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ijlynivfhp.Projects.SeckillAggregateServices.dll"]