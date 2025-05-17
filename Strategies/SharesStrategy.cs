namespace MyWorkerService.Strategies;

public class SharesStrategy
{

    public async Task CollectData(string ticker = "SBER")
    {
        var res = await MoexProvider.GetStockDataAsync("shares", ticker);
        System.Console.WriteLine(res);
    }
}