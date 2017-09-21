using System;

namespace FinancialTypes
{
    public class CurrencyInfo :IComparable<CurrencyInfo>
    {
        public CurrencyInfo(string name, string iso, int decimalPlaces, string majorSymbol, string minorSymbol)
        {
            MajorSymbol = majorSymbol;
            MinorSymbol = minorSymbol;
            Name = name;
            DecimalPlaces = decimalPlaces;
            ISO = iso;
            FormatStringMoney = "#,##0";
            if (decimalPlaces > 0)
            {
                string dp = string.Empty.PadRight(decimalPlaces, '0');
                FormatStringMoney += "." + dp;
            }
            FormatStringPrice = FormatStringMoney + "0";
        }
        //internal CurrencyInfo() : this("Unknown", "UNK", 2, "?", "?")
        //{ }

        public string MajorSymbol { get; private set; }
        public string MinorSymbol { get; private set; }
        public string Name { get; private set; }
        public int DecimalPlaces { get; private set; }
        private string _iso;
        public string ISO { get { return _iso; } private set { _iso = value.ToUpper(); } }
        public string FormatStringMoney { get; private set; }
        public string FormatStringPrice { get; private set; }

        public int CompareTo(CurrencyInfo obj)
        {
            return Name.CompareTo(obj.Name);
        }
    }
}