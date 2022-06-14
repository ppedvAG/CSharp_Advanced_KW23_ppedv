// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ICar mockCar = new MockCar();
ICar carObj = new Car();

ICarService carService = new CarService();
carService.Repair(mockCar); //Programmierer B kann Tag 4 und 5 seine Methode(n) testen -> Mock-Objekts
carService.Repair(carObj);


#region Bad Code

//Feste Kopplungen haben Wechselwirkungen 
//Programmierer A -> 5 Tage Entwicklung (von Tag 1-5)
public class BadCar
{
    public string Marke { get; set; }
    public string Modell { get; set; }

    public int Baujahr { get; set; }
}

//Programmierer B -> 3 Tage (5/6 bis Tag 8/9)
public class BadCarService
{
    public void Repair(BadCar car) //Feste Koppkung -> BadCarService kennt BadCar
    {
        //repriere Auto 

        Console.WriteLine($"Info {car.Marke} {car.Modell} {car.Baujahr} ");
    }
}

#endregion

#region GoodCode
//Programmierer A -> 5 Tage Entwicklung (von Tag 1-5)
public interface ICar
{
    public string Marke { get; set; }
    public string Modell { get; set; }

    public int Baujahr { get; set; }
}

public class Car : ICar
{
    public string Marke { get; set; }
    public string Modell { get; set; }

    public int Baujahr { get; set; }
}

//Programmierer B -> 3 Tage (1 bis Tag 3)
public interface ICarService
{
    void Repair(ICar car);
}

public class CarService : ICarService
{
    public void Repair(ICar car)
    {
        //repariere Auto
    }
}

public class MockCar : ICar
{
    public string Marke { get; set; } = "VW";
    public string Modell { get; set; } = "Polo";

    public int Baujahr { get; set; } = 2020;
}


#endregion 