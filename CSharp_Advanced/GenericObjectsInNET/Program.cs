// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<string> strList = new List<string>();
strList.Add("Hallo");

//Methoden die von der IList kommt
IList<string> strList2 = new List<string>();

//Dictionaries sind Typsicher
Dictionary<int, string> dictionary = new Dictionary<int, string>();
dictionary.Add(0, "Eintrag 1");

//Schleifen durchlauf mit KeyValuePair
foreach (KeyValuePair<int, string> currentEntry in dictionary)
{
    //Lass eine MEthode aufrufen und wir fügen das KeyValuePair als Parameter in einer andere Dictionary
    InsertEntryInNewDictionary(currentEntry);
}



void InsertEntryInNewDictionary(KeyValuePair<int, string> parameter)
{
    //Variante 1
    Dictionary<int, string> otherDictionary = new Dictionary<int, string>();
    otherDictionary.Add(parameter.Key, parameter.Value);

    //Variante 2
    IDictionary<int, string> otherDictionary2 = new Dictionary<int, string>();
    otherDictionary2.Add(parameter);
}


