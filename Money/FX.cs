using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class FX
    {
        public FX(int id, CurrencyInfo localCurrency, CurrencyInfo reportingCurrency, string name, DateTime valuationDate, DateTime valuationDateProxy, decimal rate)
        {
            ID = id;
            LocalCurrency = localCurrency;
            ReportingCurrency = reportingCurrency;
            Name = name;
            ValuationDate = valuationDate;
            ValuationDateProxy = valuationDateProxy;
            FXRate = rate;
        }

        public int ID { get; private set; }
        public CurrencyInfo LocalCurrency { get; private set; }
        public CurrencyInfo ReportingCurrency { get; private set; }
        public string Name { get; private set; }
        public DateTime ValuationDate { get; private set; }
        public DateTime ValuationDateProxy { get; private set; }
        public decimal FXRate { get; private set; }
        public decimal FXRateReciprocal { get { return 1 / FXRate; } }


        #region Operator Overloads

        public static FX operator *(FX f1, FX f2)
        {
            return new FX(f1.ID, f1.LocalCurrency, f1.ReportingCurrency, f1.Name, f1.ValuationDate, f1.ValuationDateProxy, f1.FXRate * f2.FXRate);
        }

        public static FX operator /(FX f1, FX f2)
        {
            return new FX(f1.ID, f1.LocalCurrency, f1.ReportingCurrency, f1.Name, f1.ValuationDate, f1.ValuationDateProxy, f1.FXRate / f2.FXRate);
        }

        public static bool operator ==(FX f1, FX f2)
        {
            return (f1.LocalCurrency == f2.LocalCurrency) && (f1.FXRate == f2.FXRate);
        }

        public static bool operator !=(FX f1, FX f2)
        {
            return (f1.LocalCurrency != f2.LocalCurrency) && (f1.FXRate != f2.FXRate);
        }
        #endregion
    }
}
