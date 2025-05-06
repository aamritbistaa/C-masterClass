
//dynamic form of array

List<string> names=new List<string>() { "sample"};

names.Add("Ram");
names.Add("Amrit");

foreach (var item in names)
{
    Console.WriteLine(item);
}

string data = "Hello,Ramasd,AISJDasd,asdhhaskdhjasd,asmd";

List<string> dynamicData = data.Split(',').ToList();
dynamicData.Add("New data");

foreach (var item in dynamicData)
{
    Console.WriteLine(item);
}
Console.WriteLine(dynamicData);