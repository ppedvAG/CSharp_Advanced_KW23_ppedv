// See https://aka.ms/new-console-template for more information
//Alternative zu abolute Namespaces (mit Aliase) -> wird bei langen Namespaces verwendet
using advanced1 = CSharpAdvanced;
using advanced2 = CSharpAdvanced2;

Console.WriteLine("Hello, World!");

//global using with usings.cs 
CSharpAdvanced2.HalloLiebeTeilnehmer halloLiebeTeilnehmer2 = new CSharpAdvanced2.HalloLiebeTeilnehmer();
halloLiebeTeilnehmer2.HelloFromCSharpAdvanced2();

CSharpAdvanced.HalloLiebeTeilnehmer halloLiebeTeilnehmer = new CSharpAdvanced.HalloLiebeTeilnehmer();
halloLiebeTeilnehmer.HelloFromCSharpAdvanced();





namespace CSharpAdvanced
{
    public class HalloLiebeTeilnehmer
    {
        public void HelloFromCSharpAdvanced()
        {

        }
    }


}

namespace CSharpAdvanced2
{
    public class HalloLiebeTeilnehmer
    {
        public void HelloFromCSharpAdvanced2()
        {

        }
    }

    public class HalloLieberTrainer
    {
        
    }
}

namespace CSharpAdvanced3
{
    public class HalloLiebeTeilnehmer
    {
        public void HelloFromCSharpAdvanced2()
        {

        }
    }

    public class HalloLieberTrainer
    {

    }
}

