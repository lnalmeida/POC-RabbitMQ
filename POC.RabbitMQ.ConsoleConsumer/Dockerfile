FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StockConsumer/StockConsumer.csproj", "StockConsumer/"]
RUN dotnet restore "StockConsumer/StockConsumer.csproj"
COPY . .
WORKDIR "/src/StockConsumer"
RUN dotnet build "StockConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockConsumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockConsumer.dll"]
