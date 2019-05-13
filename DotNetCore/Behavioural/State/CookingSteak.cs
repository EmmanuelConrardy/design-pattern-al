using System;
using Xunit;

namespace State
{
    public class CookingSteak
    {
        [Fact]
        public void CookSteak_With_Design()
        {
             //Let's cook a steak!    
             Steak account = new Steak("T-Bone");    
             // Apply temperature changes    
             account.AddTemp(120);    
             account.AddTemp(15);    
             account.AddTemp(15);    
             account.RemoveTemp(10); //Yes I know cooking doesn't work this way    
             account.RemoveTemp(15);    
             account.AddTemp(20);    
             account.AddTemp(20);    
             account.AddTemp(20);    

            Assert.True(account.State.CanEat);             

        }
    }

    /// <summary>
    /// The State abstract class
    /// </summary>
    abstract class Doneness
    {
        protected Steak steak;
        protected double currentTemp;
        protected double lowerTemp;
        protected double upperTemp;
        protected bool canEat;

        public bool CanEat{
            get{
                return canEat;
            }
        }

        public Steak Steak
        {
            get { return steak; }
            set { steak = value; }
        }

        public double CurrentTemp
        {
            get { return currentTemp; }
            set { currentTemp = value; }
        }

        public abstract void AddTemp(double temp);
        public abstract void RemoveTemp(double temp);
        public abstract void DonenessCheck();
    }

    class Uncooked : Doneness
    {
        public Uncooked(Doneness state)
        {
            currentTemp = state.CurrentTemp;
            steak = state.Steak;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 0;
            upperTemp = 130;
            canEat = false;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp > upperTemp)
            {
                steak.State = new Rare(this);
            }
        }
    }

    class Rare : Doneness
    {
        public Rare(Doneness state) : this(state.CurrentTemp, state.Steak)
        {
        }

        public Rare(double currentTemp, Steak steak)
        {
            this.currentTemp = currentTemp;
            this.steak = steak;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 130;
            upperTemp = 139.999999999999;
            canEat = true;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp < lowerTemp)
            {
                steak.State = new Uncooked(this);
            }
            else if (currentTemp > upperTemp)
            {
                steak.State = new MediumRare(this);
            }
        }
    }

    class MediumRare : Doneness
    {
        public MediumRare(Doneness state) : this(state.CurrentTemp, state.Steak)
        {
        }

        public MediumRare(double currentTemp, Steak steak)
        {
            this.currentTemp = currentTemp;
            this.steak = steak;
            canEat = true;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 140;
            upperTemp = 154.9999999999;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp < 0.0)
            {
                steak.State = new Uncooked(this);
            }
            else if (currentTemp < lowerTemp)
            {
                steak.State = new Rare(this);
            }
            else if (currentTemp > upperTemp)
            {
                steak.State = new Medium(this);
            }
        }
    }

    class Medium : Doneness
    {
        public Medium(Doneness state) : this(state.CurrentTemp, state.Steak)
        {
        }

        public Medium(double currentTemp, Steak steak)
        {
            this.currentTemp = currentTemp;
            this.steak = steak;
            canEat = true;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 155;
            upperTemp = 169.9999999999;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp < 130)
            {
                steak.State = new Uncooked(this);
            }
            else if (currentTemp < lowerTemp)
            {
                steak.State = new MediumRare(this);
            }
            else if (currentTemp > upperTemp)
            {
                steak.State = new Ruined(this);
            }
        }
    }

    class Ruined : Doneness
    {
        public Ruined(Doneness state) : this(state.CurrentTemp, state.Steak)
        {
        }

        public Ruined(double currentTemp, Steak steak)
        {
            this.currentTemp = currentTemp;
            this.steak = steak;
            canEat = true;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 170;
            upperTemp = 230;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp < 0)
            {
                steak.State = new Uncooked(this);
            }
            else if (currentTemp < lowerTemp)
            {
                steak.State = new Medium(this);
            }
        }
    }

    class Steak
    {
        private Doneness _state;
        private string _beefCut;

        public Steak(string beefCut)
        {
            _beefCut = beefCut;
            _state = new Rare(0.0, this);
        }

        public double CurrentTemp
        {
            get { return _state.CurrentTemp; }
        }

        public Doneness State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void AddTemp(double amount)
        {
            _state.AddTemp(amount);
        }

        public void RemoveTemp(double amount)
        {
            _state.RemoveTemp(amount);
        }
    }
}

