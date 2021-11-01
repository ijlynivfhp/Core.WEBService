#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ijlynivfhp.WEBService.OrderServices/ijlynivfhp.WEBService.OrderServices.csproj", "ijlynivfhp.WEBService.OrderServices/"]
COPY ["ijlynivfhp.WEBService.Cores/ijlynivfhp.WEBService.Cores.csproj", "ijlynivfhp.WEBService.Cores/"]
COPY ["ijlynivfhp.WEBService.Commons/ijlynivfhp.WEBService.Commons.csproj", "ijlynivfhp.WEBService.Commons/"]
RUN dotnet restore "ijlynivfhp.WEBService.OrderServices/ijlynivfhp.WEBService.OrderServices.csproj"
COPY . .
WORKDIR "/src/ijlynivfhp.WEBService.OrderServices"
RUN dotnet build "ijlynivfhp.WEBService.OrderServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ijlynivfhp.WEBService.OrderServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ijlynivfhp.WEBService.OrderServices.dll"]