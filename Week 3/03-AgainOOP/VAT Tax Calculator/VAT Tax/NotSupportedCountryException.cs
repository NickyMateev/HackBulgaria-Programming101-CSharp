using System;

namespace VAT_Tax
{
    public class NotSupportedCountryException : Exception
    {
        public NotSupportedCountryException() : base() { }
        public NotSupportedCountryException(string message) : base(message) { }
        public NotSupportedCountryException(string message, Exception inner) : base(message, inner) { }

        protected NotSupportedCountryException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}