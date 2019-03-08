using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Singleton
{
    public class MyRepoSingletonNotThreadSafe
    {
        private static MyRepoSingletonNotThreadSafe uniqueInstance;
        private static List<string> _messages;

        // Remember : Make the constructor private so its only accessible to
        // members of the class.
        private MyRepoSingletonNotThreadSafe()
        {
            _messages = new List<string>();
        }

        public void WriteMessage()
        {
            _messages.Add($"Message{DateTime.Now.Millisecond}");
        }

        public string GetMessages()
        {
            var builder = new StringBuilder();

            _messages.ForEach(m => builder.AppendLine(m));

            return builder.ToString();
        }

        // Create a static method for object creation
        public static MyRepoSingletonNotThreadSafe GetInstance()
        {
            // Only instantiate the object when needed.
            if (uniqueInstance == null)
            {
                Thread.Sleep(5); //to simulate access by multithread

                Console.WriteLine("A singleton has been created");
                uniqueInstance = new MyRepoSingletonNotThreadSafe();
            }

            return uniqueInstance;
        }
    }

    public class MyRepoSingletonThreadSafe
    {
        private static MyRepoSingletonThreadSafe uniqueInstance;
        private static readonly object myLock = new object();

        private static List<string> _messages;
        // Remember : Make the constructor private so its only accessible to
        // members of the class.
        private MyRepoSingletonThreadSafe()
        {
            _messages = new List<string>();
        }

        public void WriteMessage()
        {
            _messages.Add($"Message{DateTime.Now.Millisecond}");
        }

        public string GetMessages()
        {
            var builder = new StringBuilder();

            _messages.ForEach(m => builder.AppendLine(m));

            return builder.ToString();
        }

        // Create a static method for object creation
        //With double-checking it ok but lock kills the performance
        public static MyRepoSingletonThreadSafe GetInstance()
        {
            // Only instantiate the object when needed.
            if (uniqueInstance == null)
            {
                Thread.Sleep(5); //to simulate access by multithread
                lock (myLock)
                {
                    if (uniqueInstance == null)
                    {
                        Console.WriteLine("A singleton has been created");
                        uniqueInstance = new MyRepoSingletonThreadSafe();
                    }
                }
            }

            return uniqueInstance;
        }
    }
}
