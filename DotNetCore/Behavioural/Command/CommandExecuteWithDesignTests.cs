using System;
using System.Collections.Generic;
using Xunit;

namespace Command.Execute
{
    public class CommandExecuteWithDesignTests
    {
        [Fact]
        public void ApplyCommandPlu100Minus50MutiplyBy10DividedBy2_Equal250()
        {
            User user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            Assert.Equal(250, user.GetResult());
        }
    }

    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    abstract class Command

    {
        public abstract void Execute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    class CalculatorCommand : Command

    {
        private char _operator;
        private int _operand;
        private Calculator _calculator;

        public CalculatorCommand(Calculator calculator,
          char @operator, int operand)
        {
            this._calculator = calculator;
            this._operator = @operator;
            this._operand = operand;
        }

        // Execute new command
        public override void Execute()
        {
            _calculator.Operation(_operator, _operand);
        }
    }

    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    class Calculator
    {
        private int _curr = 0;
        public int DisplayResult()
        {
            return _curr;
        }
        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': _curr += operand; break;
                case '-': _curr -= operand; break;
                case '*': _curr *= operand; break;
                case '/': _curr /= operand; break;
            }
            Console.WriteLine(
              "Current value = {0,3} (following {1} {2})",
              _curr, @operator, operand);
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    class User
    {
        // Initializers
        private Calculator _calculator = new Calculator();
        public int GetResult()
        {
            return _calculator.DisplayResult();
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CalculatorCommand(
              _calculator, @operator, operand);

            command.Execute();
        }
    }
}

      