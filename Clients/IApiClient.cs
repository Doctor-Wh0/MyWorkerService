namespace MyWorkerService.Clients;

public interface IApiClient
{
    public Task<List<TradeRecord>> FetchDataAsync(string url);
    public Task<List<TradeRecord>> FetchSharesAsync(string ticker, string period);

    // another derivatives
}