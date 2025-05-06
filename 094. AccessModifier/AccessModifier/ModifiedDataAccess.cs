using System;
using TestLibrary;

namespace AccessModifier
{
    public class ModifiedDataAccess : DataAccess
    {
        public void GetUnsecuredConnection()
        {
            Console.WriteLine(GetConnectionString());
        }
    }
}
//private protected are available to the class and the children of class
//protected internal are available to the project or assembly and also the child of class in the assembly
//internal are available to the project or assembly they are created on
//private are limited to the class
//protected are available to derived class too
//public can be used from anywhere
