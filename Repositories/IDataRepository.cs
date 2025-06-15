namespace MyWorkerService.Repositories;

public interface IDataRepository
{
    Task<TradeRecord> GetAsync(int id);
    Task<IEnumerable<TradeRecord>> GetAllAsync(string ticker);
    Task AddAsync(TradeRecord model);
    Task AddRangeAsync(List<TradeRecord> model);
    Task<TradeRecord> GetLastRecordAsync(string ticker);
}