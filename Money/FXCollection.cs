using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class FXCollection
    {
        public void Fill(DateTime valuationDate, CurrencyInfo reportingCurrencyInfo)
        {
            items = new List<FX>();

            items.Add(new FX(1, CurrencyInfoCollection.GetCurrencyInfo("BRL"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(2, CurrencyInfoCollection.GetCurrencyInfo("CAD"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 2.68m));
            items.Add(new FX(3, CurrencyInfoCollection.GetCurrencyInfo("CNY"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(4, CurrencyInfoCollection.GetCurrencyInfo("DKK"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(5, CurrencyInfoCollection.GetCurrencyInfo("GEL"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(6, CurrencyInfoCollection.GetCurrencyInfo("GEL"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(7, CurrencyInfoCollection.GetCurrencyInfo("HKD"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(8, CurrencyInfoCollection.GetCurrencyInfo("INR"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(9, CurrencyInfoCollection.GetCurrencyInfo("JPY"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 180m));
            items.Add(new FX(10, CurrencyInfoCollection.GetCurrencyInfo("KRW"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 10m));
            items.Add(new FX(11, CurrencyInfoCollection.GetCurrencyInfo("CHF"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 10m));
            items.Add(new FX(12, CurrencyInfoCollection.GetCurrencyInfo("MYR"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.8m));
            items.Add(new FX(13, CurrencyInfoCollection.GetCurrencyInfo("MXN"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.8m));
            items.Add(new FX(14, CurrencyInfoCollection.GetCurrencyInfo("EUR"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.95m));
            items.Add(new FX(15, CurrencyInfoCollection.GetCurrencyInfo("AUD"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 2.68m));
            items.Add(new FX(16, CurrencyInfoCollection.GetCurrencyInfo("SGD"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(17, CurrencyInfoCollection.GetCurrencyInfo("SEK"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(18, CurrencyInfoCollection.GetCurrencyInfo("TWD"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(19, CurrencyInfoCollection.GetCurrencyInfo("TRY"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(20, CurrencyInfoCollection.GetCurrencyInfo("USD"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 0.68m));
            items.Add(new FX(21, CurrencyInfoCollection.GetCurrencyInfo("GBP"), reportingCurrencyInfo, reportingCurrencyInfo.Name, valuationDate, valuationDate, 1m));
        }
        public List<FX> items;
        public List<FX> Items { get { return items; } private set { items = value; } }

        public FX GetFX(string reportingLocalISO)
        {
            string isorep = reportingLocalISO.Substring(0, 3);
            string isoloc = reportingLocalISO.Substring(3, 3);
            return GetFX(isorep, isoloc);
        }

        public FX GetFX(CurrencyInfo reporting, CurrencyInfo local)
        {
            return items.First(p => p.ReportingCurrency == reporting && p.LocalCurrency == local);
        }

        private FX GetFX(string isorep, string isoloc)
        {
            return items.First(p => p.ReportingCurrency.ISO == isorep && p.LocalCurrency.ISO == isoloc);
        }
    }
}
