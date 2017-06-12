namespace FinancialTypes
{
    public class Price : ICurrencyInfoBased
    {
        public Price(decimal value, string iso)
        {
            Value = value;
            CurrencyInfo = CurrencyInfoCollection.GetCurrencyInfo(iso);
        }
        public decimal Value { get; set; }

        public CurrencyInfo CurrencyInfo { get; private set; }
    }
}