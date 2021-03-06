// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


#region Beispiel: Wertetyp und Referenztyp

//Wertetypen
bool falseOrTrue = true;
int age = 21;
//uint, long (64bit), short (16bit)
//decimal, double, float 
//struct

//Was machen Werttypen aus? 
Altern(age); //eine Kopie wird übergeben
Console.WriteLine(age); //21

//und Wertetypen mit ref (Allgemein und ohne Regeln)
AlternWithRef(ref age);
Console.WriteLine(age); //22
AlternWithOut(out age); //Muss eine Zuweisung erhalten
Console.WriteLine(age);
AlternWithIn(in age); //ist einfach nur readonly 


string eingabe = "12345f";
int number; 

//if (char.IsDigit(eingabe[0]))
if (int.TryParse(eingabe, out number))
{
    //Hier kommen wir nur rein, wenn die Konventierung von String->Zahl 
    Console.WriteLine(number);
}
else
    Console.WriteLine("Geht nicht");

//decimal money = 12345m;


//Referencetype

//string ist ein Referenztyp, verhält sich aber, wie ein Wertetype
//class -> Klassen sind Refernztypen

string abc = "abc";
Alphabet(abc);
Console.WriteLine(abc);


Person person1 = new Person();
person1.Age = 21;
person1.Vorname = "Otto";
person1.ZweiterVorname = "Der Ostfriese";
person1.Nachname = "Walkes";


Console.WriteLine($"Person - Alter: {person1.Age} und Name: {person1.Vorname}");
ManipulatePersonClass(person1); //Ich übergebe keine Kopie -> sondern meine eindeutige Speicheradresse
Console.WriteLine($"Person - Alter: {person1.Age} und Name: {person1.Vorname}");

string str = "abc";
String str1 = "abc";

int i = 123;
Int32 i2 = 123;

//VB.NET Integer i3 = 123 -> Int32 

//Beispiel WerteType
void Altern (int age)
{
    age++; //22
}

void Alphabet(string abc)
{
    abc += "def";
}

//Wertetype als Referenztyp wird übergeben
void AlternWithRef(ref int age)
{
    age++;
}

//Wertetype als  Referenztyp wird übergeben -> Es MUSS eine initialisierung bekommen
void AlternWithOut(out int age)
{
    age = 33;
}

void AlternWithIn(in int age)
{
    Console.WriteLine(age);
}

//Person p bekommt eine Referenz (Speicheradresse übegeben) 
void ManipulatePersonClass(Person p)
{
    p.Age++;
    p.Vorname = "Ottifant";
}
#endregion
#region Tuple
//Zur Laufzeit wird der Datentyp gesetzt 
var returnVariable = person1.VollenNamenAusgabe();

//allgemeinste Schreibvariante 
Console.WriteLine($"{returnVariable.firstname} {returnVariable.secondname} {returnVariable.Item3}");
#endregion

int[] zahlen = { 5, 7, 432, 567, -98, 3, 2 };

ref int position = ref Zahlensuche(3, zahlen);
position = 100_000_000;
Console.WriteLine(zahlen[5]);

ref int Zahlensuche(int gesuchteZahl, int[]zahlen)
{
    for(int i = 0; i < zahlen.Length; i++)
    {
        if (zahlen[i] == gesuchteZahl)
            return ref zahlen[i];
    }

    throw new IndexOutOfRangeException();
}
//Referencetyp Person
public class Person
{
    //Auto-Property (variabele dazu wird automatisch beim Compilieren erstellt) 
    public int Age { get; set; }

    public string Vorname { get; set; }
    public string ZweiterVorname { get; set; }
    public string Nachname { get; set; }

    public (string firstname, string secondname, string) VollenNamenAusgabe()
    {
        return (Vorname, !string.IsNullOrEmpty(ZweiterVorname) ? ZweiterVorname : string.Empty, Nachname);
    }
        
}






