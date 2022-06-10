using System;
using System.Threading.Tasks;

namespace _008_AsyncAwaitSample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //TASK-Beispiel
            Task<string> taskWithResult = Task.Run(DayTime);
            taskWithResult.Wait(); //Wait -> Callback -> WarteBisMethodeFertig
            string result1 = taskWithResult.Result; //Ergebnis auslesen


            string result2 = await Task.Run(DayTime);

            //EF Core -> ToListAsync() 
        }

        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now;

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }
    }
}
