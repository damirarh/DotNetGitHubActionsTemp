using FluentAssertions;
using Moq.AutoMock;
using NUnit.Framework;
using WebApi.Controllers;

namespace WebApi.Tests;
public class WeatherForecastControllerTests
{
    [Test]
    public void GetReturnsForecastForFiveDays()
    {
        var mocker = new AutoMocker();
        var controller = mocker.CreateInstance<WeatherForecastController>();

        var forecasts = controller.Get();

        forecasts.Should().HaveCount(5);
    }
}