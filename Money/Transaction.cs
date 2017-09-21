using System;

namespace FinancialTypes
{
    public class Transaction
    {
        public Transaction(Quantity quantity, DateTime transactionDate)
        {
            Quantity = quantity;
            TransactionDate = transactionDate;
        }

        public Quantity Quantity { get; private set; }
        public DateTime TransactionDate { get; private set; }
    }
}