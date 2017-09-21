using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class InstrumentCollection
    {


        public void Fill(DateTime valuationDate, CurrencyInfo reportingCurrencyInfo)
        {
            FXCollection fxs = new FXCollection();
            fxs.Fill(DateTime.Now.Date, reportingCurrencyInfo);

            items = new List<Instrument>();

            items.Add(createinstrument(1, "IBM", 53.685m, "USD", reportingCurrencyInfo, fxs));
            items.Add(createinstrument(2, "Vodafone", 1.58m, "GBP", reportingCurrencyInfo, fxs));
        }

        private static Instrument createinstrument(int id, string name, decimal px, string localiso, CurrencyInfo reportingCurrencyInfo, FXCollection fxs)
        {
            CurrencyInfo localcurrencyinfo = CurrencyInfoCollection.GetCurrencyInfo(localiso);
            FX fx = fxs.GetFX(reportingCurrencyInfo, localcurrencyinfo);
            Price price = new Price(px, localcurrencyinfo);
            Instrument instrument = new Instrument(id, name, DateTime.Now.Date, DateTime.Now.Date, fx, reportingCurrencyInfo, price);
            return instrument;
        }

        private List<Instrument> items;
        public List<Instrument> Items { get { return items; } set { items = value; } }

        internal Instrument GetInstrument(int id)
        {
            return Items.Single(p => p.ID == id);
        }
    }
}