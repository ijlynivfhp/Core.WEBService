#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ijlynivfhp.WEBService.SeckillAggregateServices/ijlynivfhp.WEBService.SeckillAggregateServices.csproj", "ijlynivfhp.WEBService.SeckillAggregateServices/"]
COPY ["ijlynivfhp.WEBService.Cores/ijlynivfhp.WEBService.Cores.csproj", "ijlynivfhp.WEBService.Cores/"]
COPY ["ijlynivfhp.WEBService.Commons/ijlynivfhp.WEBService.Commons.csproj", "ijlynivfhp.WEBService.Commons/"]
COPY ["ijlynivfhp.WEBService.SeckillAggregateServices/SeckillLua.lua", "/app/Luas/"]
COPY ["ijlynivfhp.WEBService.SeckillAggregateServices/SeckillLuaCallback.lua", "/app/Luas/"]
RUN dotnet restore "ijlynivfhp.WEBService.SeckillAggregateServices/ijlynivfhp.WEBService.SeckillAggregateServices.csproj"
COPY . .
WORKDIR "/src/ijlynivfhp.WEBService.SeckillAggregateServices"
RUN dotnet build "ijlynivfhp.WEBService.SeckillAggregateServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ijlynivfhp.WEBService.SeckillAggregateServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ijlynivfhp.WEBService.SeckillAggregateServices.dll"]