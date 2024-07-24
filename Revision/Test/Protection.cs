using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class GrandParent
    {
        public abstract void Greet();
    }
    public class Parent: GrandParent
    {
        public sealed override void Greet()
        {
            Console.WriteLine("Hello world from parent");
        }
    }
    public class Child :Parent
    {
        public void Greet()
        {
            Console.WriteLine("Hello world from Child");
        }
    }
    internal class Protection
    {
        public void MainFunction()
        {
            Child obj = new Child();
            obj.Greet();
            ((Parent)obj).Greet();        
        }
    }
}
