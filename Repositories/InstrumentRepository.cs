using Microsoft.EntityFrameworkCore;

public class InstrumentRepository<T> : IInstrumentRepository<T> where T: class, IFinancialInstrument
{
    private readonly IFinancialDataContext _context;

    public InstrumentRepository(IFinancialDataContext context)
    {
        _context = context;
    }

    public Task AddAsync(T instrument)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string boardId, DateTime tradeDate, string secId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.GetAllAsync<T>();
    }

    public Task<T> GetByIdAsync(string boardId, DateTime tradeDate, string secId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T instrument)
    {
        throw new NotImplementedException();
    }
}
