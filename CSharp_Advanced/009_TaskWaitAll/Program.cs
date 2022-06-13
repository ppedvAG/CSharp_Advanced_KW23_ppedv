using System;
using System.Threading;
using System.Threading.Tasks;

namespace _009_TaskWaitAll
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            #region Alle Task (void) als Rückgabewert müssen fertig sein 
            Task task1 = new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Task 1 - iteration {0}", i);

                    //sleeping for 1 second  
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Task 1 complete");
            });

            Task task2 = new Task(() =>
            {
                Console.WriteLine("Task 2 complete");
            });

            // starting the tasks  
            task1.Start();
            task2.Start();

            //waiting for both tasks to complete  
            Console.WriteLine("Waiting for tasks to complete.");
            Task.WaitAll(task1, task2);
            Console.WriteLine("Tasks Completed.");

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
            #endregion


            #region Task Any 
            //creating the tasks  
            Task task3 = new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Task 1 - iteration {0}", i);
                    //sleeping for 1 second  
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Task 1 complete");
            });

            Task task4 = new Task(() =>
            {
                Console.WriteLine("Task 2 complete");
            });

            //starting the tasks  
            task3.Start();
            task4.Start();

            //waiting for the first task to complete  
            Console.WriteLine("Waiting for tasks to complete.");
            int taskIndex = Task.WaitAny(task3, task4);
            Console.WriteLine("Task Completed - array index: {0}", taskIndex);

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();

            #endregion
        }
    }
}
