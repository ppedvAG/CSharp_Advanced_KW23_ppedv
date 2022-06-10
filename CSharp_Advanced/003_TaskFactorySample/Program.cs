using System;
using System.Threading.Tasks;

namespace _003_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variante1
            //.NET 4.0 -> Task 
            Task task = new Task(MacheEtwasInEinemTask/*Funktionszeiger*/);
            task.Start(); //explizites Starten

            //Variante 2
            //Task wir ab StartNew gestartet
            Task task2 = Task.Factory.StartNew(MacheEtwasInEinemTask); //Task wird sofort gestartet 
            task2.Wait();

            //4.5 Task.Factory.StartNew(MacheEtwasInEinemTask);
            //Eine verkürtze Schreibweise zu 

            //Variante 3
            Task.Run(MacheEtwasInEinemTask);

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }


        private static void MacheEtwasInEinemTask()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine("*");
        }
    }
}
