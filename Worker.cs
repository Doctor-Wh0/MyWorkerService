using Microsoft.Extensions.Options;
using MyWorkerService.Services;

namespace MyWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;
        private readonly IDataProvider _provider;
        private readonly LoadOptions _options;

        public Worker(
            IServiceProvider serviceProvider,
            ILogger<Worker> logger,
            IDataProvider moex,
            IOptions<LoadOptions> options)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _provider = moex;
            _options = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dataLoader = scope.ServiceProvider.GetRequiredService<Services.DataLoader>();
                        var context = scope.ServiceProvider.GetRequiredService<PostgresDbContext>();

                        var dataProviders = new List<IDataProvider>{
                            _provider,
                        };

                        var loader = new DataLoader(context, dataProviders);

                        // Параметры загрузки (можно извлечь из JSON)
                        loader.LoadAllData(_options);

                        // Логика выполнения задачи
                        _logger.LogInformation("Выполнение задачи в {Time}", DateTime.UtcNow);
                        // Пример: var data = await apiClient.GetDataAsync();
                        // await repository.SaveDataAsync(data);





                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка при выполнении задачи");
                }

                await Task.Delay(43200, stoppingToken); // Задержка между итерациями
            }
        }
    }
}
