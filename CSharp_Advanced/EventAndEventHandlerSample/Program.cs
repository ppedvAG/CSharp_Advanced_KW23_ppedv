// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


MyApp myApp = new MyApp();
myApp.StarteComponentMitEventDelegate();

myApp.StarteComponentMitEventHandler();

public class MyApp
{
    private ProgressBarComponent component;


    private ProgressBarComponent2 component2;

    public MyApp()
    {
        component = new ProgressBarComponent();
        component.ShowPercentValueDelegate += Component_ShowPercentValueDelegate; //Funktionzeiger der Methode Component_ShowPercentValueDelegate wird übergeben
        component.MessageDelegate += Component_MessageDelegate;


        component2 = new ProgressBarComponent2();
        component2.PercentValueChanged += Component2_PercentValueChanged;
        component2.ProcressCompleted += Component2_ProcressCompleted;
    }

    private void Component2_ProcressCompleted(object? sender, EventArgs e)
    {
        MyFinishEventArg myFinishEventArg = (MyFinishEventArg)e;
        Console.WriteLine(myFinishEventArg.Message);
    }


    /// <summary>
    /// Event-Methode, wenn ProgressBarComponent2 ein anderen Prozentwert erhält
    /// </summary>
    /// <param name="sender">ProgressBarComponent2</param>
    /// <param name="e">Paramenter</param>
    /// <exception cref="NotImplementedException"></exception>
    private void Component2_PercentValueChanged(object? sender, EventArgs e)
    {
        MyPercentEventArg myPercentEventArg = (MyPercentEventArg)e;
        Console.WriteLine(myPercentEventArg.Percent);
    }

    public void StarteComponentMitEventDelegate()
    {
        component.StartProcess();
    }


    public void StarteComponentMitEventHandler()
    {
        component2.StartProcess();
    }

    private void Component_MessageDelegate(string msg)
    {
        Console.WriteLine(msg);
    }

    private void Component_ShowPercentValueDelegate(int percent)
    {
        Console.WriteLine(percent);
    }
}



#region event - delegate
public delegate void ShowPercentValueDelegate(int percent);
public delegate void MessageDelegate(string msg);


public class ProgressBarComponent
{
    public event ShowPercentValueDelegate ShowPercentValueDelegate;
    public event MessageDelegate MessageDelegate;


    public void StartProcess()
    {
        for (int i = 0; i < 100; i++)
        {
            //Wir rufen die Delegates auf, mit dem glauben, dass diese einen Funktionzeiger verwenden (eine Methode wurde drangehäng
            OnProcessPercentStatus(i);
        }

        OnFertig("fertig");
    }

    protected virtual void OnProcessPercentStatus (int percent)
    {
        if (ShowPercentValueDelegate != null)
            ShowPercentValueDelegate.Invoke(percent);
    }

    protected virtual void OnFertig(string msg)
    {
        //Kurzschreibvariante 
        //Was ist das Fragezeichen -> wird nur dann ausgeführt, wenn MessageDeletage ungleich NULL ist -> Wenn nicht NULL, Dann Invoke
        MessageDelegate?.Invoke(msg);
    }
}
#endregion



public class ProgressBarComponent2
{
    public event EventHandler PercentValueChanged;

    public event EventHandler ProcressCompleted;

    public event EventHandler StartSignalWithOutParameter;

    public void StartProcess()
    {



        for (int i = 0; i < 100; i++)
        {
            //Wir rufen die Delegates auf, mit dem glauben, dass diese einen Funktionzeiger verwenden (eine Methode wurde drangehäng
            OnPercentValueChanged(i);
        }

        OnFertig("fertig");
    }

    protected virtual void OnPercentValueChanged(int i)
    {
        MyPercentEventArg percentEventArg = new MyPercentEventArg() { Percent = i };

        PercentValueChanged?.Invoke(this, percentEventArg);
    }

    protected virtual void OnFertig(string finishMessage)
    {
        ProcressCompleted?.Invoke(this, new MyFinishEventArg() { Message = finishMessage });
    }


    protected virtual void OnStartSignal()
    {
        //Kein Parameter wird übergeben :-) 
        StartSignalWithOutParameter?.Invoke(this, EventArgs.Empty);
    }


}

public class MyPercentEventArg : EventArgs
{
    public int Percent { get; set; }
}


public class MyFinishEventArg : EventArgs
{
    public string Message { get; set; }
}



