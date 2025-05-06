
using Method;

SampleMethod.SayHi();
SampleMethod.SayHi("Amrit");



Sample2Method obj = new Sample2Method();

obj.SayHi();

Mathematics.Add(10, 20);
Mathematics.Difference(10, 20);

//DRY - Don't Repeat Yourself
//SOLID - SRP - Single Responsibility Principle



double[] values = new double[] { 2, 3, 123, 12, 90, 29 };
Console.WriteLine($"The total of values is {Mathematics.SumOfArray(values)}");


(string firstName, string lastName) fullName = SampleMethod.GetFullName();

Console.WriteLine($"First Name is {fullName.firstName}");
Console.WriteLine($"Last Name is {fullName.lastName}");


//(string firstName, string lastName)  = SampleMethod.GetFullName();

//Console.WriteLine($"First Name is {firstName}");
//Console.WriteLine($"Last Name is {lastName}");



// Discard Character (_)
(string firstName,_) = SampleMethod.GetFullName();

Console.WriteLine($"First Name is {firstName}");


string ageText = "43";
bool isValidAge = int.TryParse(ageText, out int age);