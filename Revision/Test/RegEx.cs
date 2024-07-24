using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    internal class RegEx
    {
        public void MainFunction()
        {
            


            string pattern = "Tim";
            Console.WriteLine("Tim: " + Regex.IsMatch("Tim", pattern));
            Console.WriteLine("SomeTim: " + Regex.IsMatch("SomeTim", pattern));

            string pattern1 = "[Tt]im";

            Console.WriteLine("Tim or tim: " + Regex.IsMatch("tim", pattern1));
            Console.WriteLine("Tim or tim: " + Regex.IsMatch("Tim", pattern1));
            Console.WriteLine("Sometimes: " + Regex.IsMatch("Sometimes", pattern1));
            Console.WriteLine("SomeTimes: " + Regex.IsMatch("Sometimes", pattern1));

            string pattern2 = @"\sTim";
            Console.WriteLine(" Tim: "+ Regex.IsMatch(" Tim",pattern2)); //True
            Console.WriteLine("Tim: "+ Regex.IsMatch("Tim",pattern2)); //False
            
            string pattern3 = @"\sTim\s";
            Console.WriteLine(" Tim: "+ Regex.IsMatch(" Tim ",pattern3)); //True
            Console.WriteLine("This is Tim Corey: " + Regex.IsMatch("This is Tim Corey",pattern3)); //True
            Console.WriteLine("Tim: "+ Regex.IsMatch("Tim",pattern3)); //False
            
            //Start with white space or
            //letter
            string pattern4 = @"(\s|^)Tim\s";
            Console.WriteLine(" Tim: "+ Regex.IsMatch(" Tim ",pattern4)); //True
            Console.WriteLine("This is Tim Corey: " + Regex.IsMatch("This is Tim Corey",pattern4)); //True
            Console.WriteLine("Tim: "+ Regex.IsMatch("Tim asdasd",pattern4));


            string toSearch = File.ReadAllText("D:\\source\\repos\\TechnofexTest\\Test\\TextFile1.txt");
            string pattern5 = @"\d{3}"; //3digit pattern
            string pattern6 = @"\d{2}-\d{1}-\d{7}";  //25-1-1234567
            string pattern7 = @"\d{2}-?\d{1}-\d{7}";  //25-1-1234567  251-1234567
            string pattern8 = @"\d{2}(-|.)\d{1}(-|.)\d{7}";  //25-1-1234567  25.1.1234567


            var match = Regex.Matches(toSearch,pattern8); //Match all
            foreach(var itemMatch in match)
            {
                Console.WriteLine(itemMatch);
            }

        }
    }
}
