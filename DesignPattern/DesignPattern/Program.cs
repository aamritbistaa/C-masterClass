
using DesignPattern.FactoryPattern;
using DesignPattern.SingletonPattern;
using DesignPattern.FacadePattern;



#region Singleton
var obj1 = ThreadSafeLazySingletonClass.Instance();
obj1.CacheInformation();

var obj2 = ThreadSafeLazySingletonClass.Instance();
Console.WriteLine(obj1 == obj2);
#endregion

