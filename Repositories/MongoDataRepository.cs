//namespace MyWorkerService.Repositories;

//public class MongoDataRepository : IDataRepository
//{
//    private readonly IMongoCollection<TradeRecord> _collection;
//
//    public MongoDataRepository(IMongoDatabase database)
//    {
//        _collection = database.GetCollection<TradeRecord>("TradeRecords");
//    }
//
//    public async Task<TradeRecord> GetAsync(int id) => await _collection.Find(m => m.Id == id).FirstOrDefaultAsync();
//
//    public async Task<IEnumerable<TradeRecord>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
//
//    public async Task AddAsync(TradeRecord model) => await _collection.InsertOneAsync(model);
//
//    public async Task SaveChangesAsync() { /* MongoDB сохраняет автоматически, здесь можно оставить пустым */ }
//}
