using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SingletonPattern
{
    sealed class LazySingletonClass
    {
        private static LazySingletonClass instance;
        private LazySingletonClass() { }
        public static LazySingletonClass Instance()
        {
            if (instance == null)
            {
                instance = new LazySingletonClass();
            }
            return instance;
        }
        public void CacheInformation()
        {
            Console.WriteLine("Cached");
        }
    }
}
