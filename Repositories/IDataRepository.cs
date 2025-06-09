namespace MyWorkerService.Repositories;

public interface IDataRepository
{
    Task<TradeRecord> GetAsync(int id);
    Task<IEnumerable<TradeRecord>> GetAllAsync();
    Task AddAsync(TradeRecord model);
    Task AddRangeAsync(List<TradeRecord> model);
    Task SaveChangesAsync();
    Task<TradeRecord> GetLastRecord();
}