#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ijlynivfhp.Core.WEBService.OrderServices/ijlynivfhp.Core.WEBService.OrderServices.csproj", "ijlynivfhp.Core.WEBService.OrderServices/"]
COPY ["ijlynivfhp.Core.WEBService.Cores/ijlynivfhp.Core.WEBService.Cores.csproj", "ijlynivfhp.Core.WEBService.Cores/"]
COPY ["ijlynivfhp.Core.WEBService.Commons/ijlynivfhp.Core.WEBService.Commons.csproj", "ijlynivfhp.Core.WEBService.Commons/"]
RUN dotnet restore "ijlynivfhp.Core.WEBService.OrderServices/ijlynivfhp.Core.WEBService.OrderServices.csproj"
COPY . .
WORKDIR "/src/ijlynivfhp.Core.WEBService.OrderServices"
RUN dotnet build "ijlynivfhp.Core.WEBService.OrderServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ijlynivfhp.Core.WEBService.OrderServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ijlynivfhp.Core.WEBService.OrderServices.dll"]