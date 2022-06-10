using System;
using System.Threading;

namespace _011_Mutex_ProgramInstance
{
    internal class Program
    {
        static Mutex mutex;

        static void Main(string[] args)
        {
            if (IsSingleInstance())
            {
                Console.WriteLine("One Instance");
            }
            else
            {
                Console.WriteLine("More than one instance");
            }

            Console.ReadLine();

        }


        static bool IsSingleInstance()
        {
            if (Mutex.TryOpenExisting("ABC", out mutex))
            {
                return false; //Zweite Instanz erkannt, weil erster Aufruf ABC hinterlegt hat
            }
            else
            {
                mutex = new Mutex(false, "ABC");
                return true;
            }
        }
    }
}
