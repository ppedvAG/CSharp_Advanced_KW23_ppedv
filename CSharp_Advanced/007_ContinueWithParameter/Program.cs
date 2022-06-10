using System;
using System.Threading.Tasks;

namespace _007_ContinueWithParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Beispiel 1 

            //task erwartet -> evening/afternoon oder morgning
            Task<string> task = Task.Run(DayTime);

            //secondTask ist lokal und ruft ShowDayTime auf und Variable 'task' übergibt das Ergebnis
            task.ContinueWith(secondTask => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            

            //Beispiel 2 FolgeTask -> Ergebnis
            Task<string> folgeTask = task.ContinueWith<string>(mytask => GiveMessage(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            folgeTask.ContinueWith(showTask => ShowDayTime(folgeTask.Result));

            Task<string> weiterFolgeTask = folgeTask.ContinueWith<string>(mytask => GiveMessage2(folgeTask.Result));

            weiterFolgeTask.ContinueWith(resultTask => ShowDayTime(weiterFolgeTask.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            Console.ReadLine();
        }


        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now; //Aktuelle Uhrzeit ermitteln wird

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }

        public static string GiveMessage(string daytime)
        {
            if (daytime == "evening")
                return "Guten Abend";
            else if (daytime == "afternoon")
                return "Guten Nachmittag";
            else
                return "Guten Morgen";

        }

        public static string GiveMessage2(string daytime)
        {
            if (daytime == "Guten Abend")
                return "Good Eveeeeeening";
            else if (daytime == "Guten Nachmittag")
                return "Good Aaaaaafternoooooon";
            else
                return "Goood Mooooring";

        }

        public static void ShowDayTime(string result)
            => Console.WriteLine(result + " liebe Teilnehmer");
    }
}
