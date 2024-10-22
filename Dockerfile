FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

ENV ASPNETCORE_URLS=http://+:80
COPY app ./app/
WORKDIR /app
EXPOSE 80
