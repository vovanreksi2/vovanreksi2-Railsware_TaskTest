using AutoMapper;
using Mailtrap.SDK.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailtrap.SDK.Tests
{
    [TestClass]
    public class AutomapperTest
    {
        [TestMethod]
        public void Automapper_ConfigurationIsValid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();

            // Assert
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

    }

}
