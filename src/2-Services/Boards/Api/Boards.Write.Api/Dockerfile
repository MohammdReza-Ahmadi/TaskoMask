#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/2-Services/Boards/Write/Api/Boards.Write.Api/Boards.Write.Api.csproj", "src/2-Services/Boards/Write/Api/Boards.Write.Api/"]
COPY ["src/1-BuildingBlocks/Web.MVC/Web.MVC.csproj", "src/1-BuildingBlocks/Web.MVC/"]
COPY ["src/1-BuildingBlocks/Infrastructure/Infrastructure.csproj", "src/1-BuildingBlocks/Infrastructure/"]
COPY ["src/1-BuildingBlocks/Application/Application.csproj", "src/1-BuildingBlocks/Application/"]
COPY ["src/1-BuildingBlocks/Domain/Domain.csproj", "src/1-BuildingBlocks/Domain/"]
COPY ["src/1-BuildingBlocks/Contracts/Contracts.csproj", "src/1-BuildingBlocks/Contracts/"]
COPY ["src/1-BuildingBlocks/Web/Web.csproj", "src/1-BuildingBlocks/Web/"]
COPY ["src/2-Services/Boards/Write/Libraries/Infrastructure/Infrastructure.csproj", "src/2-Services/Boards/Write/Libraries/Infrastructure/"]
COPY ["src/2-Services/Boards/Write/Libraries/Application/Application.csproj", "src/2-Services/Boards/Write/Libraries/Application/"]
COPY ["src/2-Services/Boards/Write/Libraries/Domain/Domain.csproj", "src/2-Services/Boards/Write/Libraries/Domain/"]
RUN dotnet restore "src/2-Services/Boards/Write/Api/Boards.Write.Api/Boards.Write.Api.csproj"
COPY . .
WORKDIR "/src/src/2-Services/Boards/Write/Api/Boards.Write.Api"
RUN dotnet build "Boards.Write.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Boards.Write.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskoMask.Services.Boards.Write.Api.dll"]