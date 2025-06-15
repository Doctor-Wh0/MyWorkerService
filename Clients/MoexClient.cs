namespace MyWorkerService.Clients;

public class MoexClient : IApiClient
{
    private readonly HttpClient _httpClient;
    //private static string BaseUri => "http://iss.moex.com";

    public MoexClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        //_httpClient.BaseAddress = new Uri(BaseUri); // Установка базового адреса, так как это может быть нужно для всех запросов
    }

    public async Task<List<TradeRecord>> FetchDataAsync(string url)
    {
        // Выполняем GET-запрос
        var response = await _httpClient.GetAsync(url);

        // Проверяем успешность ответа
        response.EnsureSuccessStatusCode();

        // Читаем и возвращаем содержимое ответа как строку
        var res = await response.Content.ReadAsStringAsync();
        return TradeRecord.Deserialize(res);
    }

    public async Task<List<TradeRecord>> FetchSharesAsync(string ticker, string period)
    {
        var lastRecordData = period switch
        {
            "1y" => DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
            "1m" => DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd"),
            "3m" => DateTime.Today.AddDays(-90).ToString("yyyy-MM-dd"),
            "1w" => DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd"),
            "3d" => DateTime.Today.AddDays(-3).ToString("yyyy-MM-dd"),
            "1d" => DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
            _ => throw new ArgumentException("Invalid period")
        };

        string url = $"iss/history/engines/stock/markets/shares/securities/{ticker}.json?from={lastRecordData}&till={DateTime.Now:yyyy-MM-dd}&interval={31}";
        var task = await FetchDataAsync(url);

        return task;
    }
}
