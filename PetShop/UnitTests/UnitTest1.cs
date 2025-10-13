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
        public void API_Call_Test()
        {
            string actual = WeatherVM.GetWeather().ToString();
            
            Assert.AreEqual(actual,"OK");

        }
    }
}