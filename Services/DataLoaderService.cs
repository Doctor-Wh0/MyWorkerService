using MyWorkerService.Clients;
using MyWorkerService.Repositories;

namespace MyWorkerService.Services;

public class DataLoadService
{
    private readonly IDataRepository _dataRepository;
    private readonly IApiClient _apiClient;

    public DataLoadService(IDataRepository dataRepository, IApiClient apiClient)
    {
        _dataRepository = dataRepository;
        _apiClient = apiClient;
    }

    public async Task LoadDataAsync() //per day month year 
    {
        var data = await _apiClient.FetchSharesAsync("SBER", "1y");
        //await _dataRepository.AddAsync(data);
        //await _dataRepository.SaveChangesAsync();
    }
}