// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



public class BadErbeere
{
    public string GetColor()
        => "red";
}


public class BadKirsche : BadErbeere
{
    public string GetColor()
        => base.GetColor();
}



//Open-Close 


//Open-Bereich
public abstract class Fruits
{
    public abstract string GetColor();
}


//Close-Bereich
public class Erdbeer : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }
}


public class Kirsche : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }
}