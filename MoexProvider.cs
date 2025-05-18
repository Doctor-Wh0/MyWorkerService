using System.Runtime.CompilerServices;

namespace MyWorkerService;

public class MoexProvider
{
    private static string Uri => "http://iss.moex.com";

    // Замените на ваш URL http://iss.moex.com/iss/history/engines/stock/markets/shares/securities/SFIN.json?from=2024-01-01&till=2024-11-15&interval=31
    private static string url = "http://iss.moex.com/iss/history/engines/stock/markets/shares/securities/{shareTickerProperty}.{dataFormatProperty}?from={fromProperty}&till={tillProperty}&interval={intervalProperty}";

     static public async Task<string> GetStockDataAsync(string type, string ticker)
    {

        var lastRecordData = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
        using (var httpClient = new HttpClient())
        {
            // Указываем базовый адрес API MOEX
            httpClient.BaseAddress = new Uri(Uri);

            // Формируем URL для запроса
            string url = $"iss/history/engines/stock/markets/shares/securities/{ticker}.json?from={lastRecordData}&till={DateTime.Now.ToString("yyyy-MM-dd")}&interval={31}";

            // Выполняем GET-запрос
            var response = await httpClient.GetAsync(url);

            // Проверяем успешность ответа
            response.EnsureSuccessStatusCode();


            // Читаем и возвращаем содержимое ответа как строку
            var res = await response.Content.ReadAsStringAsync();
            TradeRecord.Deserialize(res);
            return "seccess";
        }
    }
}