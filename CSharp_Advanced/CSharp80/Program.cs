// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("Hello, World!");


 GeberZahlenAus();

static async IAsyncEnumerable<int> GeneriereZahlen()
{
    for (int i = 0; i < 20; i++)
    {
        await Task.Delay(100);
        yield return i;
    }
} //hier geht er aus der Methode 

static async void GeberZahlenAus()
{
    await foreach (int zahl in GeneriereZahlen())
        Console.WriteLine(zahl);
}