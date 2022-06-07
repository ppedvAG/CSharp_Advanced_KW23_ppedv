// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");

PersonClass myPerson1Class = new PersonClass(1, "Helge Schneider");
PersonClass myPerson2Class = new PersonClass(1, "Helge Schneider");

#region Class vs Record  -> ==  Operator
if (myPerson1Class == myPerson2Class)
{
    Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
}
else
{
    Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
}


if (personRecord1 == personRecord2)
{
    Console.WriteLine("personRecord1 == personRecord2 -> gleich");
}
else
{
    Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
}
#endregion

#region Equals - Methode
if (myPerson1Class.Equals(myPerson2Class))
{
    Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
}
else
{
    Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
}

if (personRecord1.Equals(personRecord1))
{
    Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
}
else
{
    Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
}
#endregion

//id=1 und Name = "Mario Bart"
(int id, string name) = personRecord1; //Deconstruct - Methode
Console.WriteLine(id);
Console.WriteLine(name);

Animal animal = new Animal(123, "Katze");
//(int id, string name) test = animal; //warum? 
(int id2, string name2) = animal;
Console.WriteLine(id2);
Console.WriteLine(name2);



Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[2] { "1234", "5678" } };

//Kontruktionszeitpunkt für person2 -> Hier können wir werte updaten bzw manipulieren 
Person person2 = person1 with { FirstName = "John" }; //Kopieren von person1 auf person2 und manipulieren dabei eine Property (init) 

Console.WriteLine(person2.ToString());


public record Animal
{
    public int Id { get; init; }
    public string Name { get; init; }

    public Animal()
    {
        Id = default;
        Name = string.Empty;
    }

    public Animal(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    public void Deconstruct(out int Id, out string Name)
    {
        Id = this.Id;
        Name = this.Name;
    }
}

public record PersonRecord(int Id, string Name); //default sind ALLE Properties get; init; 

public record EmployeeRecord : PersonRecord
{
    public decimal Gehalt { get; set; } //wir können auch Set

    public EmployeeRecord(int Id, string Name)
        :base(Id, Name)
    {

    }

    public EmployeeRecord(int Id, string Name, decimal Gehalt)
        : this(Id, Name)
    {
        this.Gehalt = Gehalt; 
    }
}

public class PersonClass
{
    public PersonClass(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    public int Id { get; set; }
    public string Name { get; set; }

   
}



public record Person(string FirstName, string LastName)
{
    //Nicht vergessen FirstName und LastName {get;init}
    public string[] PhoneNumbers { get; init; }

    public string Haribo { get; set; }
}