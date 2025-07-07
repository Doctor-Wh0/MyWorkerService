public interface IInstrumentRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string boardId, DateTime tradeDate, string secId);
    Task AddAsync(T instrument);
    Task UpdateAsync(T instrument);
    Task DeleteAsync(string boardId, DateTime tradeDate, string secId);
}