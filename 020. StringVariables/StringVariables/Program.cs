


string firstname=string.Empty;
string lastname=string.Empty;
firstname = "Amrit";
lastname = "Bista";


Console.WriteLine(firstname+" "+ lastname);

//String Interpolation
Console.WriteLine("{0} {1}", firstname, lastname);
Console.WriteLine($"{firstname} {lastname}");


string filepath = string.Empty;
filepath = @"C:\Temp\File \n";  //here @ symbol declares dont use as special character
//filepath = "C:\\Temp\\File";
Console.WriteLine(filepath);

string newVariable = "Ramesh";
Console.WriteLine(@$"The detail of {newVariable} is located in D:\PersonalFiles");