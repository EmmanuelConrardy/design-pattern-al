using System;
using Xunit;

namespace Command
{
    public class CommandWithoutDesign
    {
        [Fact]
        public void Test1()
        {
           
        }

    }

    public class Game
    {
        private string BUTTON_X = "X";
        public string BUTTON_Y = "Y";
        public string BUTTON_A = "A";
        public string BUTTON_B = "B";

        public Actor actor;

        public void InputHandler(string button)
        {
            if (button == BUTTON_X) Jump();
            else if (button == BUTTON_Y) FireGun();
            else if (button == BUTTON_A) SwapWeapon();
            else if (button == BUTTON_B) LurchIneffectively();
        }

        private void LurchIneffectively()
        {
            throw new NotImplementedException();
        }

        private void SwapWeapon()
        {
            actor.SwapWeapon();
        }

        private void FireGun()
        {
            actor.FirGun();
        }

        private void Jump()
        {
            actor.Jump();
        }
    }

    public class Actor
    {
        internal void FirGun()
        {
            throw new NotImplementedException();
        }

        internal void Jump()
        {
            throw new NotImplementedException();
        }

        internal void SwapWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
