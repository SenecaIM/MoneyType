using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class Money : MoneyPriceBase
    {
        public Money(decimal value, string iso) : base(value, iso) { }
        public Money(decimal value, CurrencyInfo currencyInfo) : base(value, currencyInfo) { }

        public Money(Price price, Quantity quantity)
            : this((price.Value * quantity.Value), price.CurrencyInfo)
        {

        }

        #region prop
        private decimal _value = 0;
        public override decimal Value
        {
            get { return _value; }
            set
            {
                _value = Math.Round(_value, MidpointRounding.AwayFromZero);
                SetField(ref _value, value);
            }
        }
        #endregion

        #region Operator Overloads

        public static Money operator +(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return new Money((m1.Value + m2.Value), m1.CurrencyInfo);
        }

        public static Money operator -(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return new Money((m1.Value - m2.Value), m1.CurrencyInfo);
        }

        public static bool operator ==(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return m1.Value == m2.Value;
        }

        public static bool operator !=(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return !(m1 == m2);
        }

        public static bool operator >(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return m1.Value > m2.Value;
        }

        public static bool operator <(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return m1.Value < m2.Value;
        }

        public static bool operator >=(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return (m1.Value == m2.Value) || (m1.Value > m2.Value);
        }

        public static bool operator <=(Money m1, Money m2)
        {
            issamecurrencyinfowithexception(m1, m2);
            return (m1.Value == m2.Value) || (m1.Value < m2.Value);
        }

        private static bool issamecurrencyinfowithexception(Money money1, Money money2)
        {
            if (money1.CurrencyInfo != money2.CurrencyInfo)
            {
                throw new CurrencyInfoException();
            }
            return true;
        }

        #endregion

        //#region tostring
        //public string ToNumber()
        //{
        //    return ToString(CurrenctFormatOptions.None);
        //}
        //public string ToCurrency()
        //{
        //    return ToString(CurrenctFormatOptions.Major);
        //}
        //public string ToDetailedCurrency()
        //{
        //    return ToString(CurrenctFormatOptions.Major | CurrenctFormatOptions.ISO);
        //}
        //private string ToString(CurrenctFormatOptions showSymbols)
        //{
        //    decimal value = Value;

        //    if (CurrencyInfo.DecimalPlaces != 0)
        //    {
        //        decimal div = (decimal)Math.Pow(10, CurrencyInfo.DecimalPlaces);
        //        value = value / div;
        //    }

        //    StringBuilder formattedvalue = new StringBuilder();

        //    if (showSymbols.HasFlag(CurrenctFormatOptions.Major)) { formattedvalue.Append(CurrencyInfo.MajorSymbol); }
        //    formattedvalue.Append(value.ToString(CurrencyInfo.FormatStringMoney));
        //    if (showSymbols.HasFlag(CurrenctFormatOptions.Minor)) { formattedvalue.Append(CurrencyInfo.MinorSymbol); }
        //    if (showSymbols.HasFlag(CurrenctFormatOptions.ISO)) { formattedvalue.Append($" [{CurrencyInfo.ISO}]"); }

        //    return formattedvalue.ToString();
        //}
        //#endregion

        //#region operators
        //public static Money operator -(Money m1, Money m2)
        //{
        //    issamecurrencyinfowithexception(m1, m2);
        //    return new Money(m1.Value - m2.Value, m1.CurrencyInfo.ISO);
        //}
        //public static Money operator +(Money m1, Money m2)
        //{
        //    issamecurrencyinfowithexception(m1, m2);
        //    return new Money(m1.Value + m2.Value, m1.CurrencyInfo.ISO);
        //}

        //private static bool issamecurrencyinfowithexception(Money m1, Money m2)
        //{
        //    if (m1.CurrencyInfo != m2.CurrencyInfo)
        //    {
        //        throw new CurrencyInfoException();
        //    }
        //    return true;
        //}
        //#endregion



    }
}