namespace FinancialTypes
{
    public class Quantity
    {
        public Quantity(decimal value)
        {
            Value = value;
        }
        public decimal Value { get; set; }

        #region Operator Overloads  
        public static Quantity operator +(Quantity q1, Quantity q2)
        {
            return new Quantity(q1.Value + q2.Value);
        }

        public static Quantity operator -(Quantity q1, Quantity q2)
        {
            return new Quantity(q1.Value - q2.Value);
        }

        public static bool operator ==(Quantity q1, Quantity q2)
        {
            return q1.Value == q2.Value;
        }

        public static bool operator !=(Quantity q1, Quantity q2)
        {
            return !(q1 == q2);
        }

        public static bool operator <(Quantity q1, Quantity q2)
        {
            return q1.Value < q2.Value;
        }

        public static bool operator >(Quantity q1, Quantity q2)
        {
            return q1.Value > q2.Value;
        }

        public static bool operator <=(Quantity q1, Quantity q2)
        {
            return (q1 == q2) || (q1 < q2);
        }

        public static bool operator >=(Quantity q1, Quantity q2)
        {
            return (q1 == q2) || (q1 > q2);
        }

        #endregion
    }
}