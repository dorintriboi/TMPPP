using System.Runtime.Serialization;

namespace Domain.Core.Exceptions;

[Serializable]
public class ValidationException: Exception
{
public ValidationException()
{
}

public ValidationException(string message)
    : base(message)
{
}

public ValidationException(string message, Exception innerException)
    : base(message, innerException)
{
}

protected ValidationException(SerializationInfo info, StreamingContext context)
{
}
}