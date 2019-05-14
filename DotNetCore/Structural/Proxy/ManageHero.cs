using Heroes;
using System;
using System.Collections.Generic;
using Xunit;

namespace Proxy
{
    public class HeroesProxy : IHeroes
    {
        private IHeroes heroesService;
        private Dictionary<string,List<Hero>> cacheHero;
        public HeroesProxy(IHeroes heroesService)
        {
            this.heroesService = heroesService;
            cacheHero = new Dictionary<string, List<Hero>>();
        }
        public void AddHeroes(Hero hero)
        {
            // C'est ici que l'on fait des actions avant l'appel du service
            heroesService.AddHeroes(hero);
        }

        public List<Hero> GetHeroes()
        {
            if(cacheHero.ContainsKey("heroesTeam")) {
                return cacheHero["heroesTeam"];
            }
            var heroes = heroesService.GetHeroes();
            cacheHero.Add("heroesTeam", heroes);
            return heroes;
        }
    }
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
            //contains
        }

        [Fact]
        public void Client_Heroes_WithDesign()
        {
            //Use a proxy to cache heroes list
            // Arrange
            var heroesService = new HeroesDependency();
            var heroesProxy = new HeroesProxy(heroesService);

            //Act
            var result = heroesProxy.GetHeroes();

            //Assert
            Assert.Equal(3, result.Count);
        }
    }
}
