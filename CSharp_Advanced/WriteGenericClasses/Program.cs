// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Sample1
Report<Freelance, string> freelance = new Report<Freelance, string>();
freelance.Generate(new Freelance());
freelance.OtherMethode("Hallo");


//Sample2 
DataStore<string> dataStore = new DataStore<string>();
dataStore.AddTryUpdate(0, "Hallo");
dataStore.AddTryUpdate(1, "Teilnehmer");

dataStore.DisplayDefault<DateTime>();
dataStore.DisplayDefault<int>();
dataStore.DisplayDefault<string>();
dataStore.DisplayDefault<Freelance>();




#region Generic Sample1
#region Vorab-Struktur
public class EmployeeBase
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Freelance : EmployeeBase
{
    public decimal SalaryPerHour { get; set; }
}

public class Employee : EmployeeBase
{
    public int HolidayLimitPerAnno { get; set; }

    public decimal SalaryPerMonth { get; set; }
}
#endregion




public class Report<T, abc> 
{
    public void Generate(T entity)
    {

    }

    public void OtherMethode(abc obj)
    {

    }
}


#endregion


#region Sample2

public class DataStore<T>
{
    private T[] _data = new T[10];

    public string DataStoreLabel { get; set; } = string.Empty;
    public string DataStoreLabel2 { get; set; }

    public int IntegerProperty { get; set; }

    public T[]Data
    {
        get => _data;
        set => _data = value;
    }

    public void AddTryUpdate(int index, T item)
    {
        if (index >= 0 && index <10)
            _data[index] = item;
    }

    public void DisplayDefault<MyType>()
    {
        MyType item = default!;

        MyType item1 = default(MyType);


        Console.WriteLine($"Default value of {typeof(MyType)} is {(item == null ? "null" : item.ToString())}.");
    }
}

#endregion