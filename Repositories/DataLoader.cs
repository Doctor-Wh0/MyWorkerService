using System.Runtime.CompilerServices;

namespace MyWorkerService.Services
{
    public class DataLoader
    {
        private readonly List<IDataProvider> _dataProviders;
        private readonly PostgresDbContext _context;

        public DataLoader(PostgresDbContext context, List<IDataProvider> dataProviders)
        {
            _context = context;
            _dataProviders = dataProviders;
        }

        public async Task<IEnumerable<IFinancialInstrument>> LoadAllData(LoadOptions options)
        {
            List<IFinancialInstrument> list = new List<IFinancialInstrument>();
            foreach (var provider in _dataProviders)
            {
                var quotes = await provider.LoadData(options);
                //await _context.AddRangeAsync(quotes);
                list.AddRange(quotes);

            }

            return list;
        }
    }
}
