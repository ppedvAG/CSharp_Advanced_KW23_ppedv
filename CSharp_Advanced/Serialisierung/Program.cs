
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Serialisierung;

Person person = new Person()
{
    Vornamen = "Max",
    Nachname = "Moritz",
    Alter = 19,
    Kontostand = 5_000,
    KreditLimit = 50_000,
    Schule = "Käthe Kollwitz Oberschule,"
};


Stream stream = null;


#region Binary-Formatter
//schreiben
//BinaryFormatter binary = new BinaryFormatter();
//stream = File.OpenWrite("Person.bin");
//binary.Serialize(stream, person);
//stream.Close(); 

////lesen
//stream = File.OpenRead("Person.bin");
//Person geladenePerson = (Person)binary.Deserialize(stream);
//stream.Close();
#endregion

#region XML Serialiser

//Schreiben
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
stream = File.OpenWrite("Person.xml");
xmlSerializer.Serialize(stream, person);
stream.Close();

//Lesen
stream = File.OpenRead("Person.xml");
Person xmlPerson = (Person)xmlSerializer.Deserialize(stream);
stream.Close();
#endregion

#region JSON
string jsonString = JsonConvert.SerializeObject(person);
File.WriteAllText("Person.json", jsonString);

string readedJsonString = File.ReadAllText("Person.json");
Person readedJSONPerson = JsonConvert.DeserializeObject<Person>(readedJsonString);
#endregion

#region CSV-Parser
person.Speichern("Person.csv");

Person secondPerson = new();
secondPerson.Laden("Person.csv");


Console.WriteLine($"{secondPerson.Vornamen} - {secondPerson.Nachname}");
#endregion

//[Serializable]
public class Person
{
    public string Vornamen { get; set; }
    public string Nachname { get; set; }
    public int Alter { get; set; }

    public string Schule { get; set; }


    //[field:NonSerialized]
    //[XmlIgnore]

    [JsonIgnore]
    public decimal Kontostand { get; set; }


    //[field: NonSerialized] //Tipp: JSON -> field:NonSerialized würde bei public Variablen auch bei JSON funktionieren
    //[XmlIgnore]

    [JsonIgnore] //JSON-Atttribute kommen von Newtonsoft-JSON, sind aber jetzt auch im Syste.Text.Json Serilaizier vorhanden
    public decimal KreditLimit;
}
