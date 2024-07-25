
using DesignPattern.FactoryPattern;
using DesignPattern.SingletonPattern;

BottleFactory obj = new BottleFactory("Metal", 200);


var obj1 = ThreadSafeLazySingletonClass.Instance();
obj1.CacheInformation();

var obj2 = ThreadSafeLazySingletonClass.Instance();
Console.WriteLine(obj1 == obj2);