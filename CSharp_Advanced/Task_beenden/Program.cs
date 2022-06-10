using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            try
            {
                Task task = new Task(MeineMethodeMitAbbrechen, token);
                task.Start();

                Task.Delay(3000).Wait();

                //Nach 3 Sekunden wird der Task abgebrochen
                cts.Cancel();
            }
            finally
            {
                cts.Dispose();
            }

            Console.ReadLine();
        }


        private static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationToken cancellationToken = (CancellationToken)param;

            try
            {
                while(true)
                {
                    Console.WriteLine("zzzzzzZZZZZzzzzZZZZZz");
                    Task.Delay(50).Wait();

                    if(cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Aufräumarbeiten
            }

        }
    }
}
