using System.Collections.Generic;
using System.Linq;

namespace FinancialTypes
{
    internal class Valuation
    {


        public Valuation(CurrencyInfo currencyInfo)
        {
            CurrencyInfo = currencyInfo;
        }

        public List<Holding> Items = new List<Holding>();
        public CurrencyInfo CurrencyInfo { get; private set; }
        public Money ExposureToLocal(CurrencyInfo currencyInfo)
        { return new Money(Items.Where(P => P.Instrument.LocalPrice.CurrencyInfo == currencyInfo).Sum(p => p.LocalValue.Value), currencyInfo.ISO); }
        public Money ExposureToReporting(CurrencyInfo currencyInfo)
        { return new Money(Items.Where(P => P.Instrument.LocalPrice.CurrencyInfo == currencyInfo).Sum(p => p.ReportingValue.Value), CurrencyInfo.ISO); }

        public Money BookValue()
        { return new Money(Items.Sum(p => p.ReportingValue.Value), CurrencyInfo.ISO); }
    }
}