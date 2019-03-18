using System;

namespace Observer
{
    public abstract class Student
    {
        private string name;
        public bool IsListening { get; set; }

        public Student(string name)
        {
            this.name = name;
        }

        public virtual void Listen()
        {
            throw new NotImplementedException();
        }
    }

    public class StudentSleeping : Student
    {
        public StudentSleeping(string name) : base(name)
        {
        }

        public override void Listen()
        {
            IsListening = false;
            Console.WriteLine("ZzzzZZZzzz");
        }
    }

    public class StudentAwake : Student
    {
        public StudentAwake(string name) : base(name)
        {
        }

        public override void Listen()
        {
            IsListening = true;
            Console.WriteLine("I'm listening");
        }
    }


}