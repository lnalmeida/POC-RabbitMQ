FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["POC.RBTMQ.Producer/POC.RBTMQ.Producer.csproj", "POC.RBTMQ.Producer/"]
RUN dotnet restore "POC.RBTMQ.Producer/POC.RBTMQ.Producer.csproj"
COPY . .
WORKDIR "/src/POC.RBTMQ.Producer"
RUN dotnet build "POC.RBTMQ.Producer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POC.RBTMQ.Producer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.RBTMQ.Producer.dll"]
