FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["src/OzonEdu.MerchandiseService/OzonEdu.MerchandiseService.csproj", "src/OzonEdu.MerchandiseService/"]
RUN dotnet restore src/OzonEdu.MerchandiseService/OzonEdu.MerchandiseService.csproj

COPY ["src/OzonEdu.MerchandiseService/", "src/OzonEdu.MerchandiseService/"]

FROM build AS publish

WORKDIR "/src/src/OzonEdu.MerchandiseService"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OzonEdu.MerchandiseService.dll"]