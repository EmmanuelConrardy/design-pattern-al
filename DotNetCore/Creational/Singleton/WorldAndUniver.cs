using System;
using System.Collections.Generic;
using Xunit;

namespace Singleton
{
    public class WorldAndUniver
    {
        #region Without Design

        //Icreate a solo instance, but...
        private World World = new World();

        [Fact]
        public void Use_Pattern_Singleton()
        {
            AddEarth();
            //...lot of crappy code
            AddSky();
           
            //what if you uncomment this
            //World = new World();
            //we will just kill everything
            //So we need a design to enforce our world to be unique and not created anymore
        }

        private void AddSky()
        {
             World.AddSky();
        }

        private void AddEarth()
        {
            World.AddEarth();
        }

        #endregion

        #region With Design
        [Fact]
        public void Use_Pattern_Singleton_With_Design()
        {
            //Let talk about something bigger UNIVER !

            AddMilkyWay();
            AddAndromeda();

           var univer = Univer.Instance;
           Univer.ShowGalaxies();
        }

        private void AddAndromeda()
        {
            //Nice I can get my instance here...
           var univer = Univer.Instance;
            Univer.AddGalaxies("Andromeda");
        }

        private void AddMilkyWay()
        {
            //...And here !
            //It will be the same even if i'm not in the same project or solution...
            //Reminder do not mess the Univer in others projects, it could be painful to change...
            var univer = Univer.Instance;
            Univer.AddGalaxies("MilkyWay");
        }
        #endregion
    }

    public class Univer
    {
        //the instance static
        //Issue difficult when testing
        public static Univer Instance;

        //the private construtor
        private Univer(){

            //the check for unicity
            if(Instance == null){
                Instance = new Univer();
            }
        }

        //Issue : here the second responsability
        private static List<string> _galaxies = new List<string>();

        public static void AddGalaxies(string galaxy)
        {
            _galaxies.Add(galaxy);
        }

        public static void ShowGalaxies()
        {
            Console.WriteLine(_galaxies.ToString());
        }
    }

    public class World
    {
        public World()
        {
        }

        internal static void AddSky()
        {
           Console.WriteLine("Adding Sky.");
        }

        internal void AddEarth()
        {
           Console.WriteLine("Adding Earth.");
        }
    }
}
