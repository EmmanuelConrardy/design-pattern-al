using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();

            var messages = client.Run();

            Console.Write(messages);
            Console.ReadLine();
        }
    }

    public class Client
    {
        public string Run()
        {
            MyRepoSingleton repoInstance = MyRepoSingleton.GetInstance();
            repoInstance.WriteMessage();

            MyRepoSingleton repoSameInstance = MyRepoSingleton.GetInstance();
            repoSameInstance.WriteMessage();

            var messages = repoSameInstance.GetMessages();

            return messages;
        }
    }

    public class ClientAfter
    {
        public string Run()
        {
            string messages = WriteAndGetMessages();

            return messages;
        }
        
        //This will not be tested
        protected virtual string WriteAndGetMessages()
        {
            MyRepoSingleton repoInstance = MyRepoSingleton.GetInstance();
            repoInstance.WriteMessage();

            MyRepoSingleton repoSameInstance = MyRepoSingleton.GetInstance();
            repoSameInstance.WriteMessage();

            var messages = repoSameInstance.GetMessages();
            return messages;
        }
    }
}
