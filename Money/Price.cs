using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FinancialTypes
{
    public class Price : MoneyPriceBase
    {
        public Price(decimal value, string iso) : base(value, iso) { }
        public Price(decimal value, CurrencyInfo currencyInfo) : base(value, currencyInfo) { }

       

        #region prop
        private decimal _value = 0;
        private MoneyPriceBase moneyPriceBase;

        public override decimal Value
        {
            get => _value;
            set => SetField(ref _value, value);
        }
        #endregion

        #region tostring
        //public override string ToString()
        //{
        //    return ToString(CurrenctFormatOptions.None);
        //}
        ////public string ToNumber()
        ////{
        ////    return ToString(CurrenctFormatOptions.None);
        ////}
        //public string ToCurrency()
        //{
        //    return ToString(CurrenctFormatOptions.Major);
        //}
        //public string ToCurrencyWithISO()
        //{
        //    return ToString(CurrenctFormatOptions.Major | CurrenctFormatOptions.ISO);
        //}
        //private string ToString(CurrenctFormatOptions showSymbols)
        //{
        //    decimal value = Value;

        //    StringBuilder formattedvalue = new StringBuilder();

        //    if (showSymbols.HasFlag(CurrenctFormatOptions.Major))
        //    {
        //        formattedvalue.Append(CurrencyInfo.MajorSymbol);

        //        if (CurrencyInfo.DecimalPlaces != 0)
        //        {
        //            decimal div = (decimal)Math.Pow(10, CurrencyInfo.DecimalPlaces);
        //            value = value / div;
        //        }
        //    }
        //    formattedvalue.Append(value.ToString());

        //    if (showSymbols.HasFlag(CurrenctFormatOptions.Minor)) { formattedvalue.Append(CurrencyInfo.MinorSymbol); }
        //    if (showSymbols.HasFlag(CurrenctFormatOptions.ISO)) { formattedvalue.Append($" [{CurrencyInfo.ISO}]"); }

        //    return formattedvalue.ToString();
        //}
        #endregion


        #region Operator Overloads  

        public static Price operator +(Price p1, Price p2)
        {
            issamecurrencyinfowithexception(p1, p2);
            return new Price((p1.Value + p2.Value), p1.CurrencyInfo);
        }

        public static Price operator -(Price p1, Price p2)
        {
            issamecurrencyinfowithexception(p1, p2);
            return new Price((p1.Value - p2.Value), p1.CurrencyInfo);
        }

        public static bool operator ==(Price p1, Price p2)
        {
            issamecurrencyinfowithexception(p1, p2);
            return p1.Value == p2.Value;
        }

        public static bool operator !=(Price p1, Price p2)
        {
            issamecurrencyinfowithexception(p1, p2);
            return !(p1 == p2);
        }

        public static bool operator >(Price p1, Price p2)
        {
            issamecurrencyinfowithexception(p1, p2);
            return p1.Value > p2.Value;
        }

        public static bool operator <(Price p1, Price p2)
        {
            issamecurrencyinfowithexception(p1, p2);
            return p1.Value < p2.Value;
        }

        public static bool operator >=(Price p1, Price p2)
        {
            issamecurrencyinfowithexception(p1, p2);
            return (p1.Value == p2.Value) || (p1.Value > p2.Value);
        }

        public static bool operator <=(Price p1, Price p2)
        {
            issamecurrencyinfowithexception(p1, p2);
            return (p1.Value == p2.Value) || (p1.Value < p2.Value);
        }


        private static bool issamecurrencyinfowithexception(Price p1, Price p2)
        {
            if (p1.CurrencyInfo != p2.CurrencyInfo)
            {
                throw new CurrencyInfoException();
            }
            return true;
        }

        #endregion

    }
}