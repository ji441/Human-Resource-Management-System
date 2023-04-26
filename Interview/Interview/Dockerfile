#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV "InterviewDb" = "Data Source=192.168.0.172,1433;Initial Catalog=InterviewDb;Encrypt=False;User ID=sa;Password=Ji19465852"
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Interview/Interview.csproj", "Interview/"]
COPY ["Interview.AppCore/Interview.AppCore.csproj", "Interview.AppCore/"]
COPY ["Interview.Infrastructure/Interview.Infrastructure.csproj", "Interview.Infrastructure/"]
RUN dotnet restore "Interview/Interview.csproj"
COPY . .
WORKDIR "/src/Interview"
RUN dotnet build "Interview.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.dll"]