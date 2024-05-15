public class MTArgumentNullException : ArgumentNullException
{
    public MTArgumentNullException()
    {
    }

    public MTArgumentNullException(string paramName) : base(paramName)
    {
    }

    public MTArgumentNullException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public MTArgumentNullException(string paramName, string message) : base(paramName, message)
    {
    }
}