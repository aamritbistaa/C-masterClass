// See https://aka.ms/new-console-template for more information
//using ClassLibraryFramework;

using ClassLibraryCore;

Console.WriteLine("Hello, World!");

Generators generators = new Generators();
PersonModel person = new PersonModel {Prefix="Mr.",FirstName="Amrit", LastName="Bista" };



var message =generators.WelcomeMessage("Mr.", "Bista");
Console.WriteLine(message);

var message1 = generators.WelcomeMessage(person.Prefix,person.LastName);
Console.WriteLine(message1);

Console.ReadLine();