using System;
using System.Threading;

namespace Singleton
{

    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(MyThread));
            Thread t2 = new Thread(new ThreadStart(MyOtherThread));
            t.Start();
            t2.Start();

            //Should wait for messages
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(15);
            }

            var messages = MyRepo().GetMessages();

            Console.Write(messages);

            Console.ReadLine();
        }

        //MyRepoSingletonNotThreadSafe -> run it 5 or 6 time to see random behaviour (write one or two messages)
        //MyRepoSingletonThreadSafe -> Always two messages
        private static MyRepoSingletonThreadSafe MyRepo()
        {
            return MyRepoSingletonThreadSafe.GetInstance();
        }

        private static void MyOtherThread()
        {
            MyRepo().WriteMessage();
        }

        private static void MyThread()
        {
            MyRepo().WriteMessage();
        }
    }
}
