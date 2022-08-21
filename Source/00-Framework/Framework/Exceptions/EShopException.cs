namespace Framework.Exceptions;

public sealed class EShopException : Exception
{
    public const string BASE_MESSAGE =
        "Something unexpectable happend.";

    public EShopException(
        string message,
        ExceptionStatus exceptionStatus,
        Exception innerException,
        string? logMessage = null
    )
        : base(GetMessage(message), innerException)
    {
        ExceptionStatus = exceptionStatus;
        AssignLogMessage(logMessage);
    }

    public EShopException(
        string message,
        Exception innerException,
        string? logMessage = null
    )
        : base(GetMessage(message), innerException)
    {
        AssignLogMessage(logMessage);
    }

    public EShopException(string message, ExceptionStatus exceptionStatus, string? logMessage = null)
        : base(GetMessage(message))
    {
        ExceptionStatus = exceptionStatus;
        AssignLogMessage(logMessage);
    }

    public EShopException(string message, string? logMessage = null)
        : base(GetMessage(message))
    {
        AssignLogMessage(logMessage);
    }

    public EShopException(ExceptionStatus exceptionStatus, string? logMessage = null)
        : base(BASE_MESSAGE)
    {
        ExceptionStatus = exceptionStatus;
        AssignLogMessage(logMessage);
    }

    public EShopException(string? logMessage = null)
        : base(BASE_MESSAGE)
    {
        AssignLogMessage(logMessage);
    }

    public ExceptionStatus ExceptionStatus { get; private set; } = ExceptionStatus.Internal;

    public string LogMessage { get; private set; } = BASE_MESSAGE;

    private static string GetMessage(string message)
    {
        return string.IsNullOrWhiteSpace(message) ? BASE_MESSAGE : message;
    }

    private void AssignLogMessage(string? message)
    {
        if (message is not null)
        {
            LogMessage = message;
        }
    }
}