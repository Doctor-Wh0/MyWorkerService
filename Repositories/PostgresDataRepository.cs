namespace MyWorkerService.Repositories;

public class PostgresDataRepository : IDataRepository
{
    private readonly DbContext _context;

    public PostgresDataRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<TradeRecord> GetAsync(int id) => await _context.Set<TradeRecord>().FindAsync(id);

    public async Task<IEnumerable<TradeRecord>> GetAllAsync() => await _context.Set<TradeRecord>().ToListAsync();

    public async Task AddAsync(TradeRecord model) => await _context.Set<TradeRecord>().AddAsync(model);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public Task AddRangeAsync(List<TradeRecord> model)
    {
        throw new NotImplementedException();
    }
}
