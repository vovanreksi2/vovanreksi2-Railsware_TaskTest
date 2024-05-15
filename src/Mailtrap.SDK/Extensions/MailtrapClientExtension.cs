using Mailtrap.SDK.Clients;
using Mailtrap.SDK.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Mailtrap.SDK.Extensions;

/// <summary>
/// Extension methods for configuring Mailtrap client services.
/// </summary>
public static class MailtrapClientExtension
{
    /// <summary>
    /// Add Mailtrap client services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="ISesrviceCollection"/> to add services to.</param>
    /// <param name="options">The <see cref="MailtrapClientOptions"/> to configure the client.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    /// <exception cref="MTArgumentNullException">Thrown when options parameter is null.</exception>
    /// <exception cref="MTArgumentException">Thrown when ApiToken or BaseUrl properties in options are null or empty.</exception>
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services, MailtrapClientOptions options)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped(_ => options);
        services.AddScoped<IMailtrapClient, MailtrapClient>();

        if (options == null)
            throw new MTArgumentNullException(nameof(options), "The 'options' parameter cannot be null.");

        if (string.IsNullOrEmpty(options.ApiToken))
            throw new MTArgumentException( "The 'ApiToken' property for MailtrapClientOptions cannot be null or empty", nameof(options.ApiToken));
        
        if (string.IsNullOrEmpty(options.BaseUrl))
            throw new MTArgumentException("The 'BaseUrl' property for MailtrapClientOptions cannot be null or empty.", nameof(options.BaseUrl));

        services.AddHttpClient<IMailtrapClient, MailtrapClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(options.BaseUrl);
                httpClient.DefaultRequestHeaders.Add("Api-token", options.ApiToken);
            })
            .AddStandardResilienceHandler();

        return services;
    }
}