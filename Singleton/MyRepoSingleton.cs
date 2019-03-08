using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class MyRepoSingleton
    {
        private static MyRepoSingleton uniqueInstance;

        private static List<string> _messages;
        // Remember : Make the constructor private so its only accessible to
        // members of the class.
        private MyRepoSingleton() => _messages = new List<string>();
      
        // Create a static method for object creation
        public static MyRepoSingleton GetInstance()
        {
            // Only instantiate the object when needed.
            if (uniqueInstance == null)
            {
                Console.WriteLine("A singleton has been created");
                uniqueInstance = new MyRepoSingleton();
            }

            return uniqueInstance;
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

    }
}
