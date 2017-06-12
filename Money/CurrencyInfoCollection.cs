using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public static class CurrencyInfoCollection
    {
        public static List<CurrencyInfo> mitems;
        public static List<CurrencyInfo> Items { get { if (mitems== null) { createitems(); } return mitems; }  }

        internal static CurrencyInfo GetCurrencyInfo(string iso)
        {
            return Items.SingleOrDefault(p => p.ISO == iso);
        }

        private static void createitems()
        {
            mitems = new List<CurrencyInfo>();
            mitems.Add(new CurrencyInfo("Sterling", "GBP", 2, "£", "p"));
            mitems.Add(new CurrencyInfo("Yen", "JPY", 0, "Y", ""));
            mitems.Add(new CurrencyInfo("US Dollar", "USD", 2, "$", "c"));
        }
    }
}
