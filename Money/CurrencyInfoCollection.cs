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

        public static CurrencyInfo GetCurrencyInfo(string iso)
        {
            return Items.SingleOrDefault(p => p.ISO == iso);
        }

        private static void createitems()
        {
            mitems = new List<CurrencyInfo>();

            mitems.Add(new CurrencyInfo("Brazilian Real", "BRL", 2, "BRL", "brl"));
            mitems.Add(new CurrencyInfo("Canadian Dollar", "CAD", 2, "$", "c"));
            mitems.Add(new CurrencyInfo("Yuan Renminbi", "CNY", 2, "¥", "cny"));
            mitems.Add(new CurrencyInfo("Danish Krone", "DKK", 2, "DKK", "dkk"));
            mitems.Add(new CurrencyInfo("Lari", "GEL", 2, "kr", "nok"));
            mitems.Add(new CurrencyInfo("Hong Kong Dollar", "HKD", 2, "$", "c"));
            mitems.Add(new CurrencyInfo("Indian Rupee", "INR", 2, "INR", "inr"));
            mitems.Add(new CurrencyInfo("Yen", "JPY", 0, "¥", " "));
            mitems.Add(new CurrencyInfo("Won", "KRW", 0, "KRW", "krw"));
            mitems.Add(new CurrencyInfo("Swiss Franc", "CHF", 2, "F", "c"));
            mitems.Add(new CurrencyInfo("Malaysian Ringgit", "MYR", 2, "M$", "c"));
            mitems.Add(new CurrencyInfo("Mexican Peso", "MXN", 2, "MXN", "mxn"));
            mitems.Add(new CurrencyInfo("Euro", "EUR", 2, "€", "c"));
            mitems.Add(new CurrencyInfo("Australian Dollar", "AUD", 2, "$", "c"));
            mitems.Add(new CurrencyInfo("Singapore Dollar", "SGD", 2, "$", "c"));
            mitems.Add(new CurrencyInfo("Swedish Krona", "SEK", 2, "SEK", "sek"));
            mitems.Add(new CurrencyInfo("New Taiwan Dollar", "TWD", 2, "TWD", "twd"));
            mitems.Add(new CurrencyInfo("Turkish Lira", "TRY", 2, "TRY", "try"));
            mitems.Add(new CurrencyInfo("US Dollar", "USD", 2, "$", "c"));
            mitems.Add(new CurrencyInfo("Pound Sterling", "GBP", 2, "£", "p"));
        }
    }
}
