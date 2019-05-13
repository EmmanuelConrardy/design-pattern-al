using Heroes;
using System;
using Xunit;

namespace Proxy
{
    public class ManageHero
    {
        [Fact]
        public void Client_Heroes_WithoutDesign()
        {
            //Arrange
            var heroesService = new HeroesDependency();

            //Act
            //We use directly the tiers service, we are exposed to latency.
            var result = heroesService.GetHeroes();

            //Assert
            Assert.Equal(3, result.Count);

        }

        [Fact]
        public void Client_Heroes_WithDesign()
        {
            //Use a proxy to cache heroes list
        }
    }
}
