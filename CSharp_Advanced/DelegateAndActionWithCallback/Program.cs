// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


MyApp myApp = new MyApp();

//Delegate-Callback Sample
myApp.ButtonClick_DelegateSample(); //klick wird simuliert. 


//Action-Delegate-Callback Sample
myApp.ButtonClick_ActionSample();


public delegate void MessageDelegate(string msg);
public delegate void ShowPercentOfProcessDelegate(int percentValue);
public delegate void AnzeigeDerLottozahlenDelegate(MyLottozahlenItem lottozahlenItem);

public class MyApp
{
    private LottozahlenZiehungComponent component;

    public MyApp()
    {
        component = new LottozahlenZiehungComponent();
    }

    public void ButtonClick_DelegateSample ()
    {
        MessageDelegate messageDelegate = new MessageDelegate(ShowMessage);
        ShowPercentOfProcessDelegate percentDelegate = new ShowPercentOfProcessDelegate(ShowCurrentPercentStatusOfProcess);
        AnzeigeDerLottozahlenDelegate anzeigeDerLottozahlenDelegate = new AnzeigeDerLottozahlenDelegate(AnzeigeDerLottoziehung);
        component.Process(messageDelegate, percentDelegate, anzeigeDerLottozahlenDelegate);
    }


    public void ButtonClick_ActionSample()
    {

        Action<string> messageActionDelegate = new Action<string>(ShowMessage);

        Action<int> pecentActionDelegate = new Action<int>(ShowCurrentPercentStatusOfProcess);

        Action<MyLottozahlenItem> anzeigeDerLottoZiehungActionDelegate = new Action<MyLottozahlenItem>(AnzeigeDerLottoziehung);


        component.Process(messageActionDelegate, pecentActionDelegate, anzeigeDerLottoZiehungActionDelegate);
    }

    public void ShowMessage(string msg)
        => Console.WriteLine(msg);

    public void ShowCurrentPercentStatusOfProcess(int value)
        => Console.WriteLine(value);

    public void AnzeigeDerLottoziehung(MyLottozahlenItem lottozahlenItem)
    {
        foreach(int currentLottozahl in lottozahlenItem.Lottozahlen)
            Console.WriteLine(currentLottozahl);
    }
}


public class MyLottozahlenItem
{
    public int[] Lottozahlen = new int[7];
}
public class LottozahlenZiehungComponent
{
    public void Process (MessageDelegate messageDelegate, ShowPercentOfProcessDelegate processDelegate, AnzeigeDerLottozahlenDelegate anzeigeDerLottozahlenDelegate )
    {
        //Beispiel 1: 
        for (int i = 0; i < 100; i++)
        {
            processDelegate(i);
        }

        //Ich bin fertig und möchte das der ShowMessage Methode mitteilen 
        messageDelegate("ich bin fertig");


        //Beispiel 2 für Objektweiterverarbeitung
        MyLottozahlenItem lottozahlenItem = new MyLottozahlenItem();
        lottozahlenItem.Lottozahlen[0] = 3;
        lottozahlenItem.Lottozahlen[1] = 5;
        lottozahlenItem.Lottozahlen[2] = 11;
        lottozahlenItem.Lottozahlen[3] = 13;
        lottozahlenItem.Lottozahlen[4] = 17;
        lottozahlenItem.Lottozahlen[5] = 19;
        lottozahlenItem.Lottozahlen[6] = 23;

        anzeigeDerLottozahlenDelegate(lottozahlenItem);
    }

    public void Process (Action<string> messageActionDelegate, Action<int> percentActionDelegate, Action<MyLottozahlenItem> showLottozahlenActionDelegate)
    {
        //Beispiel 1: 
        for (int i = 0; i < 100; i++)
        {
            percentActionDelegate(i);
        }

        //Ich bin fertig und möchte das der ShowMessage Methode mitteilen 
        messageActionDelegate("ich bin fertig");


        //Beispiel 2 für Objektweiterverarbeitung
        MyLottozahlenItem lottozahlenItem = new MyLottozahlenItem();
        lottozahlenItem.Lottozahlen[0] = 3;
        lottozahlenItem.Lottozahlen[1] = 5;
        lottozahlenItem.Lottozahlen[2] = 11;
        lottozahlenItem.Lottozahlen[3] = 13;
        lottozahlenItem.Lottozahlen[4] = 17;
        lottozahlenItem.Lottozahlen[5] = 19;
        lottozahlenItem.Lottozahlen[6] = 23;

        showLottozahlenActionDelegate(lottozahlenItem);
    }
}


