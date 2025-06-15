using Microsoft.EntityFrameworkCore;

public class PostgresDbContext : DbContext
{
    public DbSet<TradeRecord> TradeRecords { get; set; } = null!;

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
        modelBuilder.Entity<TradeRecord>()
            .HasKey(t => new { t.BOARDID, t.TRADEDATE, t.SECID });
    }
}

