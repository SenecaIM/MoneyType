namespace FinancialTypes
{
    public class Transaction
    {
        public Transaction(Quantity quantity)
        { Quantity = quantity; }

        public Quantity Quantity { get; private set; }

        
    }
}