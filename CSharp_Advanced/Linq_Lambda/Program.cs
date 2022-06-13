using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


IList<Person> persons = new List<Person>()
{
    new Person {Id=1, Age=37, Vorname="Kevin", Nachname="Winter"},
    new Person {Id=2, Age=29, Vorname="Hannes", Nachname="Preishuber"},
    new Person {Id=3, Age=19, Vorname="Scott", Nachname="Hunter"},

    new Person {Id=4, Age=21, Vorname="Scott", Nachname="Hanselmann"},
    new Person {Id=5, Age=45, Vorname="Daniel", Nachname="Roth"},
    new Person {Id=6, Age=50, Vorname="Bill", Nachname="Gates"},

    new Person {Id=7, Age=70, Vorname="Newton", Nachname="King"},
    new Person {Id=8, Age=40, Vorname="Andre", Nachname="R"},
    new Person {Id=9, Age=60, Vorname="Petra", Nachname="Musterfrau"},
};


//Linq Statement (Linq verwendet Keywords) 
//benötigt: using System.Linq;
IList<Person> personsBetween40and50 = (from p in persons
                                       where p.Age >= 40 && p.Age <= 50
                                       orderby p.Nachname
                                       select p).ToList();

//Linq-Functions und Lambda Expressions
//benötigt: using System.Linq;
IList<Person> perosnenBetween40and50 = persons.Where(e => e.Age >= 40 && e.Age <= 50)
                                              .OrderBy(e => e.Age)
                                              .ToList();


#region Calculations
double altersdurschnittAller = persons.Average(a => a.Age); //Altersdurschnitt aller

double altersdurschnittAllerMitarbeiterÜber40 = persons.Where(e => e.Age > 40).Average(a => a.Age);

int gesamtesAlterAllerMitarbeiter = persons.Sum(s => s.Age);
#endregion


#region Ermittlungen einzelner Datensätze
Person erstePersonInList = persons.First();

//Wäre denkbar, geht aber kompakter
Person erstePersonNachFilterungInList = persons.Where(e=>e.Age > 35).First();
//selbes ergebnis wie mit Where(...).First()
erstePersonNachFilterungInList = persons.First(e => e.Age > 35);
Person letztePersonAusListe = persons.Last(); 

Person resultOrDefault = persons.FirstOrDefault(a => a.Age > 200);

//Single wird für Ids verwendet. 
Person kannNurEinObject = persons.Single(e => e.Id == 2);
#endregion


#region Emitteln Datensatzanzahl Count / Count() / Any()

if (persons.Count >0)
{
    // Spreche die Property der Liste an.
}


int mitarbeiterAnzahlUnter50 = persons.Count(e => e.Age < 50);

if (persons.Any(e=>e.Age > 100))
{
    //Gibt es überhaupt Mitarbeiter die über 100 Jahre alt sind
}

#endregion

//Paging basiert auf Linq/Lambda

int pagingSize = 3;  //Anzahl der Elemente, die auf einer Seite angezeigt werden 
int pagingNumber = 1;  //Auf welcher Seite befinde ich mich -> [1] 2 3 

IList<Person> ersteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

pagingNumber = 2;
IList<Person> zweiteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

pagingNumber = 3;
IList<Person> dritteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

Console.ReadLine();
public class Person
{
    public int Id { get; set; }
    public int Age { get; set; }

    public string Vorname { get; set; }
    public string Nachname { get; set; }
}
