using System;
using System.Collections.Generic;
using System.Threading;

namespace Heroes
{
    public interface IHeroes
    {
        List<Hero> GetHeroes();
        void AddHeroes(Hero hero);
    }

    public class HeroesDependency : IHeroes
    {
        private readonly Hero SuperMan = new Hero();
        private readonly Hero Hulk = new Hero();
        private readonly Hero IronMan = new Hero();

        private List<Hero> heroes;

        public HeroesDependency()
        {
            heroes = new List<Hero> { SuperMan, Hulk, IronMan };
        }

        public List<Hero> GetHeroes()
        {
            return heroes;
        }

        public void AddHeroes(Hero hero)
        {
            heroes.Add(hero);
        }
    }

    public class Hero
    {


    }

    
}
