// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine(Summe(11,22,33));
Console.WriteLine(Summe(11,22)); //zahl3 = 0
Console.WriteLine(Summe(11)); //Zahl2 = 0 und Zahl 3 = 0


long Summe (int zahl1, int zahl2 = default, int zahl3 = default)
    => zahl1 + zahl2 + zahl3;

public struct PersonStruct
{
    public int Id { get; set; }
    public string Vorname { get; set; }
}
