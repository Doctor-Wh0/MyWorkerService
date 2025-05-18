c

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем все остальные файлы и собираем приложение
COPY . .

# Собираем приложение
RUN dotnet publish -c Release -o out

# Создаем новый образ на основе ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Открываем порт 80
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Указываем основную команду для запуска приложения
ENTRYPOINT ["dotnet", "MyWorkerService.dll"]