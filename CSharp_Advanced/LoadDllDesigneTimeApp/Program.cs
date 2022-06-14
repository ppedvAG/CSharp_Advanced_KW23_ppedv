// See https://aka.ms/new-console-template for more information
using Taschenrechner;

Console.WriteLine("Hello, World!");

//Zur Designzeit habe ich bei einem Zugriff auf eine DLL die Möglichkeit mit Codevorschlägen zu arbeiten
MyCalc calc = new MyCalc();
int result = calc.Add(11, 11);

Console.WriteLine(result);