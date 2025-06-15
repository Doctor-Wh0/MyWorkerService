using Microsoft.EntityFrameworkCore;

namespace MyWorkerService.Repositories;

public class PostgresDataRepository : IDataRepository
{
    private readonly PostgresDbContext _context;

    public PostgresDataRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task<TradeRecord> GetAsync(int id) => await _context.TradeRecords.FindAsync(id);

    public async Task<IEnumerable<TradeRecord>> GetAllAsync(string ticker) => await _context.TradeRecords
                                                                                    .Where(x=> x.SHORTNAME == ticker)
                                                                                    .ToListAsync();

    public async Task AddAsync(TradeRecord model)
    {
        await _context.TradeRecords.AddAsync(model);
        await SaveChangesAsync();
    }

    private async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task AddRangeAsync(List<TradeRecord> model)
    {
        await _context.TradeRecords.AddRangeAsync(model);
        await SaveChangesAsync();
    }

    public async Task<TradeRecord> GetLastRecordAsync(string ticker) => await _context.TradeRecords
                                                                    .Where(x => x.SHORTNAME == ticker)
                                                                    .OrderByDescending(x => x.TRADE_SESSION_DATE)
                                                                    .FirstOrDefaultAsync();
}
