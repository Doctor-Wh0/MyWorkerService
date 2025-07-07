public interface IFinancialDataContext
{
    Task SaveAsync<T>(T entity) where T : class, IFinancialInstrument;
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class, IFinancialInstrument;
    Task<T> GetByIdAsync<T>(string boardId, DateTime tradeDate, string secId) where T : class, IFinancialInstrument;
    Task UpdateAsync<T>(T entity) where T : class, IFinancialInstrument;
    Task DeleteAsync<T>(string boardId, DateTime tradeDate, string secId) where T : class, IFinancialInstrument;
}