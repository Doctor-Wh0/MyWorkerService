public interface IFinancialInstrument
{
    public string BOARDID { get; set; }
    public DateTime TRADEDATE { get; set; } // Можно использовать string, если вы не уверены в формате
    public string SHORTNAME { get; set; }
    public string SECID { get; set; }
    public int NUMTRADES { get; set; }
    public double VALUE { get; set; }
    public double OPEN { get; set; }
    public double LOW { get; set; }
    public double HIGH { get; set; }
    public double? LEGALCLOSEPRICE { get; set; } // Nullable, если может быть null
    public double WAPRICE { get; set; }
    public double CLOSE { get; set; }
    public int VOLUME { get; set; }
    public double? MARKETPRICE2 { get; set; } // Nullable
    public double? MARKETPRICE3 { get; set; } // Nullable
    public double? ADMITTEDQUOTE { get; set; } // Nullable
    public double? MP2VALTRD { get; set; } // Nullable
    public double? MARKETPRICE3TRADESVALUE { get; set; } // Nullable
    public double? ADMITTEDVALUE { get; set; } // Nullable
    public double? WAVAL { get; set; } // Nullable
    public int TRADINGSESSION { get; set; }
    public string CURRENCYID { get; set; }
    public double TRENDCLSPR { get; set; }
    public DateTime TRADE_SESSION_DATE { get; set; } // Можно использовать string, если вы не уверены в формате
}