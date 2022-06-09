using System;
using System.Threading;


namespace _002_ThreadMitParameterStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Wrapper-Klasse
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwasInEinemThread);

            Thread thread = new Thread(parameterizedThreadStart);
            thread.Start(600);
            thread.Join();
            //Weiterer Thread soll gestartet werden, und wir müssen auf die  "Ergebnis"-Rückgabe aus MachEtwasInEinemThread warten

            for (int i = 0; i <= 100; i++)
                Console.WriteLine("*");


            Console.ReadLine();
        }


        private static void MachEtwasInEinemThread(object obj) //Wert 600 wird als Parameter übergeben 
        {
            if(obj is int until) //Wenn die Variable obj ein integer ist, wird diese in die Variable until gecastet
            {
                for (int i = 0; i <= until; i++)
                {
                    Console.WriteLine(i.ToString() + " #");
                }
            }
        }
    }
}
