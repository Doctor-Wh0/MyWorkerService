using MyWorkerService.Clients;
using MyWorkerService.Repositories;

namespace MyWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        //var repository = scope.ServiceProvider.GetRequiredService<IDataRepository>();
                        //var apiClient = scope.ServiceProvider.GetRequiredService<IApiClient>();
                        var dataLoader = scope.ServiceProvider.GetRequiredService<Services.DataLoaderService>();

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
