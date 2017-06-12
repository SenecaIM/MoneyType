using System;
using System.Runtime.Serialization;

namespace FinancialTypes
{
    public class CurrencyInfo :IComparable<CurrencyInfo>
    {
        internal CurrencyInfo(string name, string iso, int decimalPlaces, string majorSymbol, string minorSymbol)
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
        public string MajorSymbol { get; private set; }
        public string MinorSymbol { get; private set; }
        public string Name { get; private set; }
        public int DecimalPlaces { get; private set; }
        public string ISO { get; private set; }
        public string FormatStringMoney { get; private set; }
        public string FormatStringPrice { get; private set; }

        public int CompareTo(CurrencyInfo obj)
        {
            return Name.CompareTo(obj.Name);
        }
    }

    [Serializable]
    public class ExceptionCurrencyInfoMisMatch : Exception
    {
        public ExceptionCurrencyInfoMisMatch()
        { }

        public ExceptionCurrencyInfoMisMatch(string message) : base(message)
        { }

        public ExceptionCurrencyInfoMisMatch(string message, Exception innerException) : base(message, innerException)
        { }

        protected ExceptionCurrencyInfoMisMatch(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}