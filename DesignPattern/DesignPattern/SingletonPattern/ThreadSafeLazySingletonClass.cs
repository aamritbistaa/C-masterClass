using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SingletonPattern
{
    sealed class ThreadSafeLazySingletonClass
    {
        private static ThreadSafeLazySingletonClass instance;
        private static readonly object _lock = new object();
        private ThreadSafeLazySingletonClass() { }

        public static ThreadSafeLazySingletonClass Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeLazySingletonClass();
                    }
                }
            }
            return instance;
        }
        public void CacheInformation()
        {
            Console.WriteLine("Cached");
        }
    }
}
