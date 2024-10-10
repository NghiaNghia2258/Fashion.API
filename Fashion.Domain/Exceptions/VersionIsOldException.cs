namespace Fashion.Domain.Exceptions
{
    public class VersionIsOldException: Exception
    {
        public VersionIsOldException() : base("Version has old !!!") { }
        public VersionIsOldException(string message) : base(message) { }
        public VersionIsOldException(string message, Exception inner) : base(message, inner) { }
        protected VersionIsOldException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
