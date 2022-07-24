FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmployeeTracking.WebAPI/EmployeeTracking.WebAPI.csproj", "EmployeeTracking.WebAPI/"]
COPY ["EmployeeTracking.Dto/EmployeeTracking.Dto.csproj", "EmployeeTracking.Dto/"]
COPY ["EmployeeTracking.Base/EmployeeTracking.Base.csproj", "EmployeeTracking.Base/"]
COPY ["EmployeeTracking.Service/EmployeeTracking.Service.csproj", "EmployeeTracking.Service/"]
COPY ["EmployeeTracking.Data/EmployeeTracking.Data.csproj", "EmployeeTracking.Data/"]
RUN dotnet restore "EmployeeTracking.WebAPI/EmployeeTracking.WebAPI.csproj"
COPY . .
WORKDIR "/src/EmployeeTracking.WebAPI"
RUN dotnet build "EmployeeTracking.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeTracking.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeTracking.WebAPI.dll"]