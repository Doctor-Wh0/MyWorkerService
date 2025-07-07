// using MyWorkerService.Clients;

// namespace MyWorkerService.Services;

// public class DataLoaderService
// {
//     private readonly IInstrumentRepository<Stock> _dataRepository;
//     private readonly IApiClient _apiClient;

//     public DataLoaderService(IInstrumentRepository<Stock> dataRepository, IApiClient apiClient)
//     {
//         _dataRepository = dataRepository;
//         _apiClient = apiClient;
//     }

//     public async Task LoadDataAsync(CancellationToken cancellationToken) //per day month year 
//     {
//         var existingRecords = await _apiClient.FetchSharesAsync("SBER", "1y");



//         var newRecords = (await _dataRepository.GetAllAsync("SBER"))
//                    .Where(tr => !existingRecords.Any(er =>
//                        er.BOARDID == tr.BOARDID &&
//                        er.TRADEDATE == tr.TRADEDATE &&
//                        er.SECID == tr.SECID))
//                    .ToList();

//         if (newRecords.Any())
//         {
//             // Использование транзакции для вставки новых записей
//             //using var transaction = await _dbContext.Database.BeginTransactionAsync();
//             try
//             {
//                 await _dataRepository.AddRangeAsync(newRecords);
//                 //await _dbContext.SaveChangesAsync();
//                 //await transaction.CommitAsync();
//                 Console.WriteLine($"Inserted {newRecords.Count} new records.");
//             }
//             catch (Exception ex)
//             {
//                 //await transaction.RollbackAsync();
//                 Console.WriteLine($"Error inserting records: {ex.Message}");
//                 throw;
//             }
//         }
//         else
//         {
//             Console.WriteLine("No new records to insert.");
//         }
//     }
//     //await _dataRepository.AddAsync(data);
//     //await _dataRepository.SaveChangesAsync();
// }
