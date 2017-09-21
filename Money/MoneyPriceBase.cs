using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class MoneyPriceBase : NotifyPropertyChanged
    {
        #region ctor
        private MoneyPriceBase() { }
        public MoneyPriceBase(decimal value, string iso)
        {
            Value = value;
            CurrencyInfo = CurrencyInfoCollection.GetCurrencyInfo(iso);
        }
        public MoneyPriceBase(decimal value, CurrencyInfo currencyInfo)
        {
            Value = value;
            CurrencyInfo = currencyInfo;
        }
        #endregion

        #region prop
        private decimal _value = 0;

        public virtual decimal Value { get => _value; set => new PriceMoneyBaseExceptionDirectUseNotAllowed(); }
        private CurrencyInfo _currencyinfo;
        public CurrencyInfo CurrencyInfo { get => _currencyinfo; private set => SetField(ref _currencyinfo, value); }
        #endregion





        private static void currencytest(CurrencyInfo c1, CurrencyInfo c2)
        {
            if (c1 != c2)
            {
                throw new CurrencyInfoException();
            }
        }

        private static void currencytest(MoneyPriceBase p1, MoneyPriceBase p2)
        {
            currencytest(p1.CurrencyInfo, p2.CurrencyInfo);
        }
        private static void issamecurrencyinfowithexception(MoneyPriceBase p1, FX fx)
        {
            currencytest(p1.CurrencyInfo, fx.LocalCurrency);
        }



        #region ToString

        public string ToStringMinor(bool showSeparators = true) { return formattostring(CurrenctFormatOptionsEnum.Minor, showSeparators); }
        public string ToStringMinorSymbol(bool showSeparators = true) { return formattostring(CurrenctFormatOptionsEnum.MinorSymbol, showSeparators); }
        public string ToStringMinorISO(bool showSeparators = true) { return formattostring(CurrenctFormatOptionsEnum.MinorISO, showSeparators); }

        public string ToStringMajor(bool showSeparators = true) { return formattostring(CurrenctFormatOptionsEnum.Major, showSeparators); }
        public string ToStringMajorSymbol(bool showSeparators = true) { return formattostring(CurrenctFormatOptionsEnum.MajorSymbol, showSeparators); }
        public string ToStringMajorISO(bool showSeparators = true) { return formattostring(CurrenctFormatOptionsEnum.MajorISO, showSeparators); }

        private string formattostring(CurrenctFormatOptionsEnum format, bool showSeparators)
        {
            string result = string.Empty;
            string numberformat = string.Empty;
            string numberformatprefix = string.Empty;
            string numberformatsuffix = string.Empty;

            int minimumdp = 0;

            decimal value = Value;


            switch (format)
            {
                case CurrenctFormatOptionsEnum.Major:
                case CurrenctFormatOptionsEnum.MajorISO:
                case CurrenctFormatOptionsEnum.MajorSymbol:

                    if (CurrencyInfo.DecimalPlaces != 0)
                    {
                        int div = (int)Math.Pow(10, CurrencyInfo.DecimalPlaces);
                        value = value / div;
                        minimumdp = CurrencyInfo.DecimalPlaces;
                    }

                    break;
            }

            int dp = new Regex("(?<=[\\.])[0-9]+").Match(value.ToString()).Length;
            int pad = Math.Min(8 + minimumdp, dp);

            numberformatsuffix += string.Empty.PadRight(pad, '0');

            if (showSeparators)
            {
                numberformatprefix = "#,##0";
            }
            else
            {
                numberformatprefix = "#";
            }
            numberformat = $"{numberformatprefix}.{numberformatsuffix}";

            switch (format)
            {
                case CurrenctFormatOptionsEnum.Minor:
                case CurrenctFormatOptionsEnum.Major:
                    result = value.ToString(numberformat);
                    break;
                case CurrenctFormatOptionsEnum.MinorSymbol:
                    result = value.ToString(numberformat) + CurrencyInfo.MinorSymbol;
                    break;
                case CurrenctFormatOptionsEnum.MajorSymbol:
                    result = CurrencyInfo.MajorSymbol + value.ToString(numberformat);
                    break;
                case CurrenctFormatOptionsEnum.MinorISO:
                    result = value.ToString(numberformat) + " [" + CurrencyInfo.ISO + "]";
                    break;
                case CurrenctFormatOptionsEnum.MajorISO:
                    result = value.ToString(numberformat) + " [" + CurrencyInfo.ISO + "]";
                    break;
            }

            return result;
        }
        #endregion
    }
}