namespace MyWorkerService.Clients;

public class MoexClient : IApiClient
{
    ///private readonly HttpClient _httpClient;

    ///public MoexClient(HttpClient httpClient)
    ///{
    ///    _httpClient = httpClient;
    ///}

    private static string Uri => "http://iss.moex.com";
    private static string url = "http://iss.moex.com/iss/history/engines/stock/markets/shares/securities/{shareTickerProperty}.{dataFormatProperty}?from={fromProperty}&till={tillProperty}&interval={intervalProperty}";


    public async Task<List<TradeRecord>> FetchDataAsync(string url)
    {
        using (var httpClient = new HttpClient())
        {
            // Указываем базовый адрес API MOEX
            httpClient.BaseAddress = new Uri(Uri);

            // Выполняем GET-запрос
            var response = await httpClient.GetAsync(url);

            // Проверяем успешность ответа
            response.EnsureSuccessStatusCode();


            // Читаем и возвращаем содержимое ответа как строку
            var res = await response.Content.ReadAsStringAsync();
            return TradeRecord.Deserialize(res);
        }
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
            _ => throw new ArgumentException()
        };

        string url = $"iss/history/engines/stock/markets/shares/securities/{ticker}.json?from={lastRecordData}&till={DateTime.Now.ToString("yyyy-MM-dd")}&interval={31}";
        var task = await FetchDataAsync(url);

        return task;
    }


}
