public class LoadOptions
{
    public Assets Assets { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class Assets
{
    public string[] Stocks { get; set; }
    public string[] Metals { get; set; }
    public string[] Crypto { get; set; }
}