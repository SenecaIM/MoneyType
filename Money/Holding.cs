using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class Holding
    {
        public Holding(Instrument instrument, List<Transaction> transactions)
        {
            Instrument = instrument;
            Transactions = transactions;
        }

        public Instrument Instrument { get; private set; }
        public List<Transaction> Transactions { get; private set; }
        public Quantity Quantity { get { return new Quantity(Transactions.Sum(p => p.Quantity.Value)); } }

        public Money ReportingValue { get { return new Money(Instrument.ReportingPrice, Quantity); } }
        public Money LocalValue { get { return new Money(Instrument.LocalPrice, Quantity); } }
    }
}
