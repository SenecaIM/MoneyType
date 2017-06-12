using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
 public   class Instrument
    {
        private int v1;
        private string v2;

        public Instrument(decimal localValue, string localiso, decimal reportingValue, string reportingiso
            )
        {
            ReportingPrice = new FinancialTypes.Price(reportingValue, reportingiso);
            LocalPrice = new Price(localValue, localiso);
        }

        public Instrument(decimal value, string iso):this(value,iso, value,iso)
        {            }

        public Price ReportingPrice { get; private set; }
        public Price LocalPrice { get; private set; }
    }
}
