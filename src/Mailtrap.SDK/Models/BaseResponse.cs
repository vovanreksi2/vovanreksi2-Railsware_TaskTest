/// <summary>
/// Represents a base response returned by the Mailtrap SDK.
/// </summary>
public class BaseResponse
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the message IDs associated with the response.
    /// <remarks>Available if the request is success</remarks>>
    /// </summary>
    public IEnumerable<string> MessageIds { get; set; }

    /// <summary>
    /// Gets or sets the errors associated with the response.
    /// <remarks>Available if the request fails</remarks>>
    /// </summary>
    public IEnumerable<string> Errors { get; set; }

    /// <summary>
    /// Returns a string representation of the response.
    /// </summary>
    /// <returns>A string containing the status and details of the response.</returns>
    public override string ToString()
    {
        return Success
            ? $"Status: {Success}. MessageIds:{string.Join(", ", MessageIds)}"
            : $"Status: {Success}. Errors:{string.Join(", ", Errors)}";
    }

    public static BaseResponse Failure(string error)
    {
        return new BaseResponse
        {
            Success = false,
            Errors = new List<string> { error }
        };
    }
}