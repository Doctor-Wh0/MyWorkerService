using System;
using System.Text.Json;

public class Stock : IFinancialInstrument
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


    public static List<TradeRecord> Deserialize(string json)
    {
        using (JsonDocument doc = JsonDocument.Parse(json))
        {
            // Извлечение массива данных
            JsonElement dataArray = doc.RootElement.GetProperty("history").GetProperty("data");

            List<TradeRecord> tradeRecords = new List<TradeRecord>();

            foreach (var item in dataArray.EnumerateArray())
            {
                var tradeRecord = new TradeRecord
                {
                    BOARDID = item[0].GetString(),
                    TRADEDATE = DateTime.Parse(item[1].GetString()),
                    SHORTNAME = item[2].GetString(),
                    SECID = item[3].GetString(),
                    NUMTRADES = item[4].GetInt32(),
                    VALUE = item[5].GetDouble(),
                    OPEN = item[6].GetDouble(),
                    LOW = item[7].GetDouble(),
                    HIGH = item[8].GetDouble(),
                    LEGALCLOSEPRICE = item[9].ValueKind == JsonValueKind.Null ? (double?)null : item[9].GetDouble(),
                    WAPRICE = item[10].GetDouble(),
                    CLOSE = item[11].GetDouble(),
                    VOLUME = item[12].GetInt32(),
                    MARKETPRICE2 = item[13].ValueKind == JsonValueKind.Null ? (double?)null : item[13].GetDouble(),
                    MARKETPRICE3 = item[14].ValueKind == JsonValueKind.Null ? (double?)null : item[14].GetDouble(),
                    ADMITTEDQUOTE = item[15].ValueKind == JsonValueKind.Null ? (double?)null : item[15].GetDouble(),
                    MP2VALTRD = item[16].ValueKind == JsonValueKind.Null ? (double?)null : item[16].GetDouble(),
                    MARKETPRICE3TRADESVALUE = item[17].ValueKind == JsonValueKind.Null ? (double?)null : item[17].GetDouble(),
                    ADMITTEDVALUE = item[18].ValueKind == JsonValueKind.Null ? (double?)null : item[18].GetDouble(),
                    WAVAL = item[19].ValueKind == JsonValueKind.Null ? (double?)null : item[19].GetDouble(),
                    TRADINGSESSION = item[20].GetInt32(),
                    CURRENCYID = item[21].GetString(),
                    TRENDCLSPR = item[22].GetDouble(),
                    TRADE_SESSION_DATE = DateTime.Parse(item[23].GetString())
                };

                tradeRecords.Add(tradeRecord);
            }

            return tradeRecords;
        }
    }
}
