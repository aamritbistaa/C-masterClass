
using System.Collections.Specialized;

for (int i=0; i < 5; i++)
{
    Console.WriteLine($"Hello{i}");
}
string data = "Ramesh,is,good,but,shyam,is,not";

var dataInArray = data.Split(',').ToList();

for(int i = 0; i < dataInArray.Count; i++)
{
    Console.WriteLine(dataInArray[i]);
}

List<decimal> charges = new();
charges.Add(23.14M);
charges.Add(4M);
charges.Add(23M);

decimal Sum = 0;
for(int i=0; i<charges.Count; i++)
{
    Sum = Sum + charges[i]; 
}

Console.WriteLine(Sum);