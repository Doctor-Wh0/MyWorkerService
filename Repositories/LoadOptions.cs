public class LoadOptions
{
    public IEnumerable<string> SelectedAssets { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

//public class LoadDataCommand
//{
//    private readonly IDataProvider _dataProvider;
//
//    public LoadDataCommand(IDataProvider dataProvider)
//    {
//        _dataProvider = dataProvider;
//    }
//
//    public void Execute(LoadOptions options)
//    {
//        var quotes = _dataProvider.LoadQuotes(options);
//        // Сохранение загруженных данных
//    }
//}