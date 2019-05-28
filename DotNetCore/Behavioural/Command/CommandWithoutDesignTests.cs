using System;
using Xunit;

namespace Command
{
    public class CommandWithoutDesignTests
    {
        [Fact]
        public void Jump()
        {
            var game = new Game();
            var actor = game.actor;

            game.Press("X");

            Assert.Equal("Jump", actor.CurrentAction);
        }
    }

    public class Game
    {
        public Game()
        {
            actor = new Actor();
        }
        private string BUTTON_X = "X";
        public string BUTTON_Y = "Y";
        public string BUTTON_A = "A";
        public string BUTTON_B = "B";

        public Actor actor;

        public void Press(string button)
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
        public string CurrentAction { get; internal set; }

        internal void FirGun()
        {
            CurrentAction = "Fire";
        }

        internal void Jump()
        {
            CurrentAction = "Jump";
        }

        internal void SwapWeapon()
        {
            CurrentAction = "Swap";
        }
    }
}
