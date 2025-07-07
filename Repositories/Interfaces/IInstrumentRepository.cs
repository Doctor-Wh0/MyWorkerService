namespace MyWorkerService.Repositories;

public interface IInstrumentRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(string secId);
    Task<T> GetByIdAsync(string boardId, DateTime tradeDate, string secId);
    Task AddAsync(T instrument);
    Task AddRangeAsync(IEnumerable<T> instrument);
    Task UpdateAsync(T instrument);
    Task DeleteAsync(string boardId, DateTime tradeDate, string secId);
}