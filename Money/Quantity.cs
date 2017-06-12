namespace FinancialTypes
{
    public class Quantity
    {
        public Quantity(decimal value)
        {
            Value = value;
        }
        public decimal Value { get; set; }

        public static Quantity operator +(Quantity q1, Quantity q2)
        {
            return new Quantity(q1.Value + q2.Value);
        }
    }
}