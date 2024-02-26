

string[] names = new string[5];

names[0] = "amrit bista";
names[1] = "another person";
names[4] = "Ramesh";
int i = 0;
while (i < 5)
{
    Console.WriteLine(names[i]);
    i++;
}

string data ="ram,shyam,hari,ramesh,sita";
string[] firstName = data.Split(',');

int lastIndex = firstName.Length-1;
Console.WriteLine(firstName[4]);

string[] lastName = new string[] { "Bista", "Khadka", "Shrestha" };

int[] nas = new int[] { 1, 23, 11, 42 };