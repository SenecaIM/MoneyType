using System;
using System.Runtime.Serialization;

namespace FinancialTypes
{
    [Serializable]
    public class CurrencyInfoException : Exception
    {
        public CurrencyInfoException()
        { }

        public CurrencyInfoException(string message) : base(message)
        { }

        public CurrencyInfoException(string message, Exception innerException) : base(message, innerException)
        { }

        protected CurrencyInfoException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }


    }
}