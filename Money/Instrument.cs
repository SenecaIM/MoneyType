using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class Instrument
    {
        //private int v1;
        //private string v2;

        //public Instrument(decimal localValue, string localiso, decimal reportingValue, string reportingiso, FX pricefx            )
        //{
        //ReportingPrice = new FinancialTypes.Price(reportingValue, reportingiso);
        //LocalPrice = new Price(localValue, localiso);
        //}

        //public Instrument(decimal value, string iso) : this(value, iso, value, iso)
        //{ }

        public Instrument(int id, string name, DateTime valuationDate, DateTime valuationDateProxy,  FX priceFX, CurrencyInfo reportingCurrency, Price localPrice)
        {
            ID = id;
            Name = name;
            ValuationDate = valuationDate;
            ValuationDateProxy = valuationDateProxy;
            LocalPrice = localPrice;
            PriceFX = priceFX;
            ReportingCurrency = reportingCurrency;
        }

        public FX PriceFX { get; private set; }

        public CurrencyInfo LocalCurrency { get { return LocalPrice.CurrencyInfo; } }
        public CurrencyInfo ReportingCurrency { get; private set; }

        public Price LocalPrice { get; private set; }
        //public Price ReportingPrice => LocalPrice * PriceFX;
        public string Name { get; private set; }
        public DateTime ValuationDate { get; private set; }
        public DateTime ValuationDateProxy { get; private set; }
        public int ID { get; private set; }
    }
}