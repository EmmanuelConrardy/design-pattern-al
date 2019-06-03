using Microsoft.VisualBasic.CompilerServices;
using System.Linq;
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
            user.Compute('*', 4);

            Assert.Equal(1000, user.GetResult());
        }

        [Fact]
        public void ApplyCommandTestUndo()
        {
            User user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);
            user.Compute('*', 4);
            user.Undo();
            user.Compute('*', 4);
            user.Undo();
            user.Undo();
            Assert.Equal(500, user.GetResult());
            user.Redo();
            Assert.Equal(250, user.GetResult());
            user.Redo();
            Assert.Equal(1000, user.GetResult());
        }
    }


    abstract class Command
    {
        public virtual void Execute(){}

        public virtual void UnExecute(){}
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    class CalculatorCommand : Command
    {
        private char _operator;
        private int _operand;
        private Calculator _calculator;

        public override void Execute()
        {
            _calculator.Operation(_operator, _operand);
        }

        public override void UnExecute()
        {
            _calculator.Operation(Invert(_operator), _operand);
        }
        public CalculatorCommand(Calculator calculator,
          char @operator, int operand)
        {
            this._calculator = calculator;
            this._operator = @operator;
            this._operand = operand;
        }
        private char Invert(char @operator)
        {
            switch (@operator)
            {
                
                case '+': return '-'; 
                case '-': return '+'; 
                case '*': return '/'; 
                case '/': return '*';
                default: return '-'; 
            }
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
        private List<Command> _cmdList = new List<Command>();
        private int _position = 0;
        public int GetResult()
        {
            return _calculator.DisplayResult();
        }

        public void Compute(char @operator, int operand)
        {
            var command = new CalculatorCommand(_calculator, @operator, operand);
            command.Execute();
            _cmdList.Insert(_position++, command);

        }

        public void Undo()
        {
            var command = _cmdList[_position - 1];
            if (command != null)
            {
                command.UnExecute();
                --_position;
            }
        }

        internal void Redo()
        {
            var command = _cmdList[_position];
            if (command != null)
            {
                command.Execute();
                ++_position;
            }
        }
    }
}

      