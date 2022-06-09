using System;
using System.Threading;

namespace _006_ThreadWithState
{

    public delegate void MyResultDelegate(MyReturnObject myReturnObject);

    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadWithState threadWithState = new ThreadWithState("Hallo liebe Teilnehmer", 123, new MyResultDelegate(ResultCallback));


            Thread thread = new Thread(threadWithState.ThreadProc);
            thread.Start();

            Console.WriteLine("Unabhängiger Thread ist jetzt mit seiner Arbeit fertig geworden");

            Console.ReadLine();
        }


        //Wier erhalten hier das Ergebnis von ThreadProc
        public static void ResultCallback(MyReturnObject myReturnObject)
        {
            Console.WriteLine($"Rückgabewerte-> {myReturnObject.Text} und {myReturnObject.Zahl}");
        }
    }


    public class ThreadWithState
    {
        private string myStringText;
        private int myNumberValue;
        private MyResultDelegate resultDelegate;


        public ThreadWithState(string text, int zahl,MyResultDelegate resultDelegate)
        {
            this.myStringText = text;
            this.myNumberValue = zahl;
            this.resultDelegate = resultDelegate;
        }

        //Diese Methode läuft in einem Thread
        public void ThreadProc()
        {
            //Mach etwas wichtiges


            //Pseudoverarbeitung ->
            MyReturnObject myReturnObject = new MyReturnObject();
            myReturnObject.Zahl = 1234567;
            myReturnObject.Text = "Machen jetzt eine Pause";

            //Achtung hier verwenden wir ein Delegate-Callback

            //Gibt ein Objekt zurück
            resultDelegate(myReturnObject); // public static void ResultCallback(MyReturnObject myReturnObject) wird via callback aufgerufen
        }
    }



    //Dieses Objekt benötigen wir um das Ergebnis aus ThreadProc zurück zugeben
    public class MyReturnObject
    {
        public MyReturnObject()
        {

        }

        public string Text { get; set; }
        public int Zahl { get; set; }
    }
}

