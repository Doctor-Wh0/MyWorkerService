using Microsoft.EntityFrameworkCore;

public class PostgresDbContext : DbContext, IFinancialDbContext
{

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Metal> Metals { get; set; }
    public DbSet<Crypto> Cryptos { get; set; }
    public DbSet<MarketIndex> Indices { get; set; }

    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>()
            .HasKey(t => new { t.BOARDID, t.TRADEDATE, t.SECID });
    }

    public async Task SaveAsync<T>(T entity) where T : class, IFinancialInstrument
    {
        await Set<T>().AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class, IFinancialInstrument
    {
        return await Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync<T>(string boardId, DateTime tradeDate, string secId) where T : class, IFinancialInstrument
    {
        return await Set<T>().FirstOrDefaultAsync(e => e.BOARDID == boardId && e.TRADEDATE == tradeDate && e.SECID == secId);
    }

    public async Task UpdateAsync<T>(T entity) where T : class, IFinancialInstrument
    {
        Set<T>().Update(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync<T>(string boardId, DateTime tradeDate, string secId) where T : class, IFinancialInstrument
    {
        var entity = await GetByIdAsync<T>(boardId, tradeDate, secId);
        if (entity != null)
        {
            Set<T>().Remove(entity);
            await SaveChangesAsync();
        }
    }
}