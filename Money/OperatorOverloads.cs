//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FinancialTypes
//{
//    public class OperatorOverloads
//    {
//        #region operators
//        public static MoneyPriceBase operator -(MoneyPriceBase p1, MoneyPriceBase p2)
//        {
//            currencytest(p1, p2);
//            return new MoneyPriceBase(p1.Value - p2.Value, p1.CurrencyInfo.ISO);
//        }
//        public static MoneyPriceBase operator +(MoneyPriceBase p1, MoneyPriceBase p2)
//        {
//            currencytest(p1, p2);
//            return new MoneyPriceBase(p1.Value + p2.Value, p1.CurrencyInfo.ISO);
//        }
//        public static MoneyPriceBase operator *(MoneyPriceBase p1, MoneyPriceBase p2)
//        {
//            currencytest(p1, p2);
//            return new MoneyPriceBase(p1.Value * p2.Value, p1.CurrencyInfo.ISO);
//        }
//        public static MoneyPriceBase operator /(MoneyPriceBase p1, MoneyPriceBase p2)
//        {
//            currencytest(p1, p2);
//            return new MoneyPriceBase(p1.Value / p2.Value, p1.CurrencyInfo.ISO);
//        }
//        public static bool operator ==(MoneyPriceBase p1, MoneyPriceBase p2)
//        {
//            return p1.Value == p2.Value && p1.CurrencyInfo == p2.CurrencyInfo;
//        }
//        public static bool operator !=(MoneyPriceBase p1, MoneyPriceBase p2)
//        {
//            return p1.Value != p2.Value || p1.CurrencyInfo != p2.CurrencyInfo;
//        }
//        public static MoneyPriceBase operator *(MoneyPriceBase p1, FX fx1)
//        {
//            issamecurrencyinfowithexception(p1, fx1);
//            return new MoneyPriceBase(p1.Value * fx1.FXRateReciprocal, p1.CurrencyInfo.ISO);
//        }
//    }
//}
