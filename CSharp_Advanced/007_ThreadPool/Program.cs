using System;
using System.Threading;

namespace _007_ThreadPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Methode1);
            ThreadPool.QueueUserWorkItem(Methode2);
            ThreadPool.QueueUserWorkItem(Methode3);

            Console.ReadLine();
        }


        static void Methode1(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("#");
            }
        }

        static void Methode2(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("+");
            }
        }

        static void Methode3(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("%");
            }
        }
    }
}
