using System;
using System.Threading;

namespace _005_ThreadMitParamsAndReturnValues
{
    internal class Program
    {
        private static string retString = string.Empty;
        private static string meinText = "Hello World";

        static void Main(string[] args)
        {

            meinText = "Heute ist Donnerstag";

            //Alte Variante
            Thread thread1 = new Thread(Startmethode);
            thread1.Start();
            thread1.Join(); //Warten bis Thread fertig ist
            Console.WriteLine(retString);

            
            meinText = "Morgen ein neuer Tag";
            ///Variante Anonyme Methode
            Thread thread2 = new Thread(() =>
            {
                
                //Achtung eine Anonyme Methode in einem Thread
                retString = StringToUpper(meinText);
                
            });


            Console.WriteLine(retString);
        }

        //Methode mit der komplexen Logik
        private static string StringToUpper(string param)
           => param.ToUpper();

        //VARIANTE 2 -> ohne Anonyme Methode
        public static void Startmethode()
        {
            retString = StringToUpper(meinText);
        }

    }
}
