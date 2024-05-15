using System.Net;
using AutoMapper;
using Mailtrap.SDK.Clients;
using Mailtrap.SDK.Mapping;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace Mailtrap.SDK.Tests;

[TestClass]
public class MailtrapClientTests
{
    [TestMethod]
    public async Task ExecuteSendAsync_ReturnSuccess()
    {
        // Arrange

        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        var mapper = config.CreateMapper();

        var sendEmailRequest = new SendEmailRequest();
        var resultMessageId = "9db705e0-1217-11ef-0040-f189db6f9d44";
        
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent($"{{\"success\":true,\"message_ids\":[\"{resultMessageId}\"]}}")
            })
            .Verifiable();

        var logger = new Mock<ILogger<MailtrapClient>>();

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://send.api.mailtrap.io")
        };

        var mailtrapClient = new MailtrapClient(mapper, httpClient, logger.Object);
        // Act
        var result = await mailtrapClient.SendAsync(sendEmailRequest);
        
        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Success);

        Assert.IsNotNull(result.MessageIds);
        Assert.AreEqual(result.MessageIds.FirstOrDefault(), resultMessageId);
    }

    [TestMethod]
    public async Task ExecuteSendAsync_ReturnFailed()
    {
        // Arrange

        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        var mapper = config.CreateMapper();

        var sendEmailRequest = new SendEmailRequest();

        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("{\"success\":false,\"errors\":[\"from is required\"]}")
            })
            .Verifiable();

        var logger = new Mock<ILogger<MailtrapClient>>();

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://send.api.mailtrap.io")
        };

        var mailtrapClient = new MailtrapClient(mapper, httpClient, logger.Object);
        // Act
        var result = await mailtrapClient.SendAsync(sendEmailRequest);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsFalse(result.Success);

        Assert.IsNotNull(result.Errors);
        Assert.AreEqual(result.Errors.FirstOrDefault(), "from is required");
    }
}