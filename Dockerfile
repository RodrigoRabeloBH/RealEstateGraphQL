FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80

COPY *.sln .
COPY "/RealStateManage.API/RealStateManage.API.csproj" "/RealStateManage.API/"
COPY "/RealStateManager.Domain/RealStateManager.Domain.csproj" "/RealStateManager.Domain/"
COPY "/RealStateManager.Infrastructure/RealStateManager.Infrastructure.csproj" "/RealStateManager.Infrastructure/"
COPY "/RealStateManager.Application/RealStateManager.Application.csproj" "/RealStateManager.Application/"

RUN dotnet restore "/RealStateManage.API/RealStateManage.API.csproj"


COPY . ./
WORKDIR /app/RealStateManage.API
RUN dotnet publish -c Release -o publish 


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/RealStateManage.API/publish ./
ENTRYPOINT ["dotnet", "RealStateManage.API.dll"]