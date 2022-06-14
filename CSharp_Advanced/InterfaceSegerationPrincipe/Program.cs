// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");





#region BadCode
public interface IBadVehicle
{
    void CanFly();

    void CanDrive();

    void CanSwim();
}

public class MultiVehicle : IBadVehicle
{
    public void CanDrive()
    {
        Console.WriteLine("Vehicle kann fahren");
    }

    public void CanFly()
    {
        Console.WriteLine("Vehicle kann fliegen");
    }

    public void CanSwim()
    {
        Console.WriteLine("Vehicle kann schwimmen");
    }
}

public class Auto : IBadVehicle
{
    public void CanDrive()
    {
        Console.WriteLine("Auto kann fahren");
    }

    //Diese Methoden werden für ein Auto nie benötigt
    public void CanFly()
    {
        throw new NotImplementedException();
    }

    public void CanSwim()
    {
        throw new NotImplementedException();
    }
}
#endregion


#region Good Code
public interface IFly
{
    void CanFly();
}

public interface ISwim
{
    void CanSwim();
}

public interface IDrive
{
    void Drive();
}




public class MultiVehicle2 : IFly, IDrive, ISwim
{
    public void CanFly()
    {
        Console.WriteLine("kann fliegen");
    }

    public void CanSwim()
    {
        Console.WriteLine("kann schwimmen");
    }

    public void Drive()
    {
        Console.WriteLine("kann fahren");
    }
}


public class AmphibischeVehicle : ISwim, IDrive
{
    public void CanSwim()
    {
        Console.WriteLine("kann schwimmen");
    }

    public void Drive()
    {
        Console.WriteLine("kann fahren");
    }
}
#endregion