public class MTArgumentException : ArgumentException
{
    public MTArgumentException()
    {
    }

    public MTArgumentException(string message) : base(message)
    {
    }

    public MTArgumentException(string message, string paramName) : base(message, paramName)
    {
    }

    public MTArgumentException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
    {
    }
}