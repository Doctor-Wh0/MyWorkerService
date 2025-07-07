public interface IDataProvider
{
    Task<IEnumerable<IFinancialInstrument>> LoadData(LoadOptions options);
}