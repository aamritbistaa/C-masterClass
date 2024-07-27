using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SingletonPattern
{
    sealed class EagerSingletonClass
    {
        private static EagerSingletonClass instance = new EagerSingletonClass();
        private EagerSingletonClass() { }
        public static EagerSingletonClass Instance()
        {
            return instance;
        }
        public void CacheInformation()
        {
            Console.WriteLine("Cached");
        }
    }
}
