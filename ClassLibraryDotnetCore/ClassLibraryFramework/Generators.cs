using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFramework
{
    public class Generators
    {
        public string WelcomeMessage(string prefix, string lastName)
        {
            return $"Welcome to our demo application {prefix} {lastName}";

        }

        public string FarewellMessage(string prefix, string lastName)
        {
            return $"I hope you enjoyed your time with us {prefix} {lastName}. Visit us again.";
        }
    }
}
