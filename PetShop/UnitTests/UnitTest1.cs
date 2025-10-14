using PetShop.ViewModels;
using System.Diagnostics;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task API_Call_Test()
        {
            Task<List<string>> weatherTask = WeatherVM.GetWeather();
            List<string> actual = await weatherTask;
            Assert.That(actual[0] == "OK");
        }
    }
}