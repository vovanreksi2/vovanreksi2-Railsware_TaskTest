namespace Mailtrap.SDK.Clients;

/// <summary>
/// Represents a client for interacting with the Mailtrap API.
/// </summary>
public interface IMailtrapClient
{
    /// <summary>
    /// Sends an email asynchronously using the Mailtrap API.
    /// </summary>
    /// <param name="request">The <see cref="SendEmailRequest"/> containing email details.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains a <see cref="BaseResponse"/> object.</returns>
    Task<BaseResponse> SendAsync(SendEmailRequest request);
}