using System;

using System.Threading;

namespace _001_Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Methode MachEtwasInEinemThread soll in einem Thread laufen 
            Thread thread = new Thread(MachEtwasInEinemThread);

            thread.Start(); // Es führt MachEtwasInEinemThread aus und arbeitet die Main-Methode weiter 

            //Wir warten bis der Thread quasi fertig ist

            //MachEtwasInEinemThread muss zuerst fertig sein

            //weiterer Thread wird gestartet

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("*");
            }

            Console.ReadLine();
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("#");
            }
        }
    }
}
