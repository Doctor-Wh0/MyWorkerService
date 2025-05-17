using MyWorkerService.Strategies;

namespace MyWorkerService;

public class Handler
{
    SharesStrategy _strategy;

    public Handler() {
        _strategy = new SharesStrategy();
    }

    public async Task CollectData()
    {
        await _strategy.CollectData();
    }
}