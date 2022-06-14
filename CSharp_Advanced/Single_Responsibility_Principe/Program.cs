

//Was passiert mit BadEmployee, wenn wir diese so verwenenden? 

// Codeexplosion -> sehr viele Codezeilen in einer Klasse, zu unterschiedlichen Themen 

public class BadEmployee
{
    //Auto-Properties -> Komplierer legt dir automatisch die Variablen an
    public int Id { get; set; } 
    public string Name { get; set; }

    public void InsertEmployeeToTable(BadEmployee employee)
    {
        //any Code
    }

    public void GenerateReport()
    {
        //any Code
    }
}




//Entity Framework oder EF Core -> POCO - Klasse oder Entity
//Pocos haben folgende Regel 
//- Keine Methode oder Logik
//- Einzigste an Regeln sind DataAnnotations


//DTO - Objekte (Data Transfer Objekt´s)
//ViewModels 
public class Employee
{
    //EF versteht Id als Primary an -> Konvetion
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
}



// Wird im Data-Access-Layer verwendet 
// Repositoryklasse arbeitet mit einer Tabelle zusammen und repräsentiert das CRUD (Create, Read, Update, Delete) oder mehr :-)
public class EmployeeRepository
{
    public void Insert(Employee em)
    {
        //speichere in DB
    }
}

public class GenerateReport
{
    void Generate (Employee em)
    {

    }
}
