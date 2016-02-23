using System;

namespace Shop_Inventory__Library_
{
    class NotAvailableInInventoryException : Exception
    {
        public NotAvailableInInventoryException() : base() { }
        public NotAvailableInInventoryException(string message) : base(message) { }
        public NotAvailableInInventoryException(string message, Exception inner) : base(message, inner) { }

        protected NotAvailableInInventoryException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
