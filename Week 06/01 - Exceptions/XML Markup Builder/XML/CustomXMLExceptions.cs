using System;
using System.Runtime.Serialization;

namespace XML
{
    public class XMLFileAlreadyFinalizedException : ApplicationException
    {
        public XMLFileAlreadyFinalizedException() : this("The XML file is already finalized. Cannot make any changes to it!") { }

        public XMLFileAlreadyFinalizedException(string message) : base(message) { }

        public XMLFileAlreadyFinalizedException(string message, Exception innerException) : base(message, innerException) { }

        protected XMLFileAlreadyFinalizedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class XMLNoRootException : ApplicationException
    {
        public XMLNoRootException() : this("You need to have a root XML object, XML is not a list!") { }

        public XMLNoRootException(string message) : base(message) { }

        public XMLNoRootException(string message, Exception innerException) : base(message, innerException) { }

        protected XMLNoRootException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class XMLNoTagOpenedException : ApplicationException
    {
        public XMLNoTagOpenedException() : this("There is no opened tag to close!") { }

        public XMLNoTagOpenedException(string message) : base(message) { }

        public XMLNoTagOpenedException(string message, Exception innerException) : base(message, innerException) { }

        protected XMLNoTagOpenedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class XMLAddTextException : ApplicationException
    {
        public XMLAddTextException() : this("Cannot add text to an empty XML file!") { }

        public XMLAddTextException(string message) : base(message) { }

        public XMLAddTextException(string message, Exception innerException) : base(message, innerException) { }

        protected XMLAddTextException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class XMLAddAttributeException : ApplicationException
    {
        public XMLAddAttributeException() : this("Cannot add attributes to an empty XML file!") { }

        public XMLAddAttributeException(string message) : base(message) { }

        public XMLAddAttributeException(string message, Exception innerException) : base(message, innerException) { }

        protected XMLAddAttributeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}