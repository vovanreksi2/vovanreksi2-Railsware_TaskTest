using System.Net.Http.Json;
using AutoMapper;
using Mailtrap.SDK.Constants;
using Mailtrap.SDK.MailtrapModels;
using Microsoft.Extensions.Logging;

namespace Mailtrap.SDK.Clients;

public class MailtrapClient : MailtrapClientBase, IMailtrapClient
{
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public MailtrapClient(IMapper mapper, HttpClient httpClient, ILogger<MailtrapClient> logger)
    {
        _mapper = mapper;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<BaseResponse> SendAsync(SendEmailRequest request)
    {
        try
        { 
            var mtRequest = _mapper.Map<MTSendEmailRequest>(request);

            var requestMessage = GetDefaultMailtrapMessage(HttpMethod.Post, MailtrapRouteConstants.SendRoute, SerializeMessageContent(mtRequest));

            using var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
            var response = await responseMessage.Content.ReadFromJsonAsync<MTResponse>().ConfigureAwait(false);
            return _mapper.Map<BaseResponse>(response);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while sending the request to {MailtrapRouteConstants.SendRoute}");
            return BaseResponse.Failure($"An unexpected error occurred while sending the request:{e.Message}. Please check details in logs");
        }
    }
}