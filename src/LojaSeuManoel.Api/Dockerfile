FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/LojaSeuManoel.Api/LojaSeuManoel.Api.csproj", "LojaSeuManoel.Api/"]
COPY ["src/LojaSeuManoel.Application/LojaSeuManoel.Application.csproj", "LojaSeuManoel.Application/"]
COPY ["src/LojaSeuManoel.Domain/LojaSeuManoel.Domain.csproj", "LojaSeuManoel.Domain/"]

RUN dotnet restore "LojaSeuManoel.Api/LojaSeuManoel.Api.csproj"

COPY src/ ./ 

WORKDIR "/src/LojaSeuManoel.Api"
RUN dotnet build "LojaSeuManoel.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaSeuManoel.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "LojaSeuManoel.Api.dll"]
