// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Employee
{
    //EF versteht Id als Primary an -> Konvetion
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
}

public class BadReportGenerator
{
    public string ReportType { get; set; } = string.Empty;

    public void GenerateReport(Employee em)
    {

        if (ReportType == "CR") //Crystal Reports (Drittanbieter mit einer eigenen DLL-Library
        {
            // 200 Zeilen
        }
        else if (ReportType == "ListLabel") //List10 (Drittanbieter mit einer eigenen DLL-Library
        {
            // 350 Zeilen
        }
        else if (ReportType == "PDF")//PDF (Drittanbieter mit einer eigenen DLL-Library
        {
            // 150 Zeilen
        }
    }
}

//Open Part -> Umreißen das Problem (Abstraktion abstrakte Klasse oder interface) 

public abstract class GeneratorBase
{
    public abstract void Generate(Employee em);
}

public class CrystalReportGenerator : GeneratorBase
{

    public override void Generate(Employee em)
    {
        //Implementier für Crystal Report die Gene

        //bei einem Fehler sind wir im Workflows auf mit Exception spezialisiert 
        //CrystalReportGeneratorException 
    }
}
public class CrystalReportGeneratorException : Exception
{
    public CrystalReportGeneratorException(string message)
        : base(message) { }
}


public class ListLabelReportGenerator : GeneratorBase
{
    public override void Generate(Employee em)
    {
        throw new NotImplementedException();
    }
}