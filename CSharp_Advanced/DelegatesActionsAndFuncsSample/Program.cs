

//Sample 1: Was ist ein Delegate
//Delegate instanziierung benötigt einen Namen einer Methode

ChangeNumber changeNumber = new ChangeNumber(OffSet5); //Konstruktor = Funktionszeiger einer Methode wird übegeben.
changeNumber += OffSet7;

int newNumber = changeNumber(11);
Console.WriteLine(newNumber); //16 

LogDelegate logDelegate = new LogDelegate(LogToDb); //LogToDb Methode wurde hinzugefügt (Funktionsparameter übergeben)
logDelegate += LogToEvetLog; // LogToEvetLog wird via += Operator zusätzlich angehängt
logDelegate("Starte Programm"); //LogToDb wird aufgerufen + LogToEvetLog 

//logDelegate -= LogToDb; -> würde ein Fehler geben 



//Was ist ein Action -> ist ein generisches Delegate
//Action kann nur mit Methoden zusammenarbeiten, die ein void zurückgeben 

Action<string> logAction = new Action<string>(LogToDb);



int OffSet5(int zahl)
{
    return zahl + 5;
}

int OffSet7(int zahl)
{
    return zahl + 7;
}

void LogToDb(string nachricht)
{
    Console.WriteLine($"Logge nach DB: {nachricht}");
}

void LogToEvetLog(string nachricht)
{
    Console.WriteLine($"Logge nach EventListener: {nachricht}");
}


//Delegate ist ein Datentyp -> Dieses Delegate kann nur mit Methoden zusammenarbeiten, dass ein int als Rückgabe und ein int als Parameter vorweist 
delegate int ChangeNumber(int number);

delegate void LogDelegate(string msg);




