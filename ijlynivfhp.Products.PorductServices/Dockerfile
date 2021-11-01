#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ijlynivfhp.Products.PorductServices/ijlynivfhp.WEBService.ProductServices.csproj", "ijlynivfhp.Products.PorductServices/"]
COPY ["ijlynivfhp.WEBService.Cores/ijlynivfhp.WEBService.Cores.csproj", "ijlynivfhp.WEBService.Cores/"]
COPY ["ijlynivfhp.WEBService.Commons/ijlynivfhp.WEBService.Commons.csproj", "ijlynivfhp.WEBService.Commons/"]
RUN dotnet restore "ijlynivfhp.Products.PorductServices/ijlynivfhp.WEBService.ProductServices.csproj"
COPY . .
WORKDIR "/src/ijlynivfhp.Products.PorductServices"
RUN dotnet build "ijlynivfhp.WEBService.ProductServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ijlynivfhp.WEBService.ProductServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ijlynivfhp.WEBService.ProductServices.dll"]