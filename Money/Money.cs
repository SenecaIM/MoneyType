using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class Money :ICurrencyInfoBased
    {
        public Money(int value, string iso)
        {
            Value = value;
            CurrencyInfo = CurrencyInfoCollection.GetCurrencyInfo(iso);
        }
        public Money(Price price, Quantity quantity)
        {
            Value= Convert.ToInt32( price.Value*  quantity.Value);
            CurrencyInfo = price.CurrencyInfo;
        }

        public int Value { get; set; }

        public CurrencyInfo CurrencyInfo { get; private set; }

        public  string ToNumber()
        {
            return ToString( CurrenctFormatOptions.None);
        }
        public string ToCurrency()
        {
            return ToString(CurrenctFormatOptions.Major);
        }
        public string ToDetailedCurrency()
        {
            return ToString(CurrenctFormatOptions.Major | CurrenctFormatOptions.ISO);
        }
        private string ToString(CurrenctFormatOptions showSymbols)
        {
            decimal value = Value;

            if (CurrencyInfo.DecimalPlaces != 0)
            {
                decimal div = (decimal)Math.Pow(10, CurrencyInfo.DecimalPlaces);
                value = value / div;
            }

            StringBuilder formattedvalue = new StringBuilder();

            if (showSymbols.HasFlag(CurrenctFormatOptions.Major)) { formattedvalue.Append(CurrencyInfo.MajorSymbol); }
            formattedvalue.Append(value.ToString(CurrencyInfo.FormatStringMoney));
            if (showSymbols.HasFlag( CurrenctFormatOptions.Minor)) { formattedvalue.Append(CurrencyInfo.MinorSymbol); }
            if (showSymbols.HasFlag( CurrenctFormatOptions.ISO)) { formattedvalue.Append($" [{CurrencyInfo.ISO}]"); }

            return formattedvalue.ToString();
        }
        
        public static Money operator -(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return new Money(m1.Value - m2.Value, m1.CurrencyInfo.ISO);
        }
        public static Money operator +(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return new Money(m1.Value + m2.Value, m1.CurrencyInfo.ISO);
        }

        private static bool issamecurrencyinfowithexception(Money m1, Money m2)
        {
            if (m1.CurrencyInfo != m2.CurrencyInfo)
            {
                throw new ExceptionCurrencyInfoMisMatch();
            }
            return true;
        }
    }
}