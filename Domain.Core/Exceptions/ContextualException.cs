using System.Runtime.Serialization;

namespace Domain.Core.Exceptions;

[Serializable]
public class ContextualException: Exception
{
    public ContextualException()
    {
    }

    public ContextualException(string message)
        : base(message)
    {
    }

    public ContextualException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected ContextualException(SerializationInfo info, StreamingContext context)
    {
    }
}