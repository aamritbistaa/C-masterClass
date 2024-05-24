using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_Exceptions
{
    internal class Program
    {
        static int value = 0;

        static void Main(string[] args)
        {
            Program ob= new Program();
            try
            {
                //ob.SimpleMethod();
                ob.DifferentMethod();

            }
            catch(InvalidOperationException ex)//Specific exception
            {
                Console.WriteLine("Invalid operation exception");
                Console.WriteLine(ex.Message);
            }
            catch(NotImplementedException ex)
            {
                Console.WriteLine("Method is not Complete");
                Console.WriteLine(ex);
            }
            
            catch (Exception ex) when (value > 5)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("This block runs always");
            }
            Console.ReadKey();
        }
        public void SimpleMethod()
        {
            value = 50;
            throw new InvalidOperationException("This is under construction");
        }
        public void DifferentMethod()
        {
            throw new NotImplementedException();
        }
    }
}
